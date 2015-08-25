using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Don't forget to arrange the order of the scripts in Unity: First ItemDatabase, then Inventory and then SlotScript
// pos: -178, 217
public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public List<GameObject> SlotList = new List<GameObject>();
    public List<Item> Items = new List<Item>();
    public List<int> InitialiseInventoryItems = new List<int>();
    public GameObject Slots;
    public GameObject Tooltip;
    public GameObject DraggedItemGameObject;
    public ItemDatabase Database;
    public Item TheDraggedItem;
    public int IndexOfDraggedItem;

    public int SlotsLoaded = 0;

    public void Awake()
    {
        Instance = GameManager.Instance.MyInventory;

        Database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        InitialiseInventoryItems.Clear();
        ResetAmounts();

    //////////////    ResetAmounts(); // moved to other place
        Debug.Log("cleared inventory list");
       
        Instance.Slots = Resources.Load("Prefabs/UI/InventoryWindow/Slot") as GameObject;
        Instance.Tooltip = Resources.Load("Prefabs/UI/InventoryWindow/Tooltip") as GameObject;
        
        foreach (GameObject slot in SlotList)
        {
            Items.Add(new Item());
        }
    }

    public void Start()
    {
        Instance = this;
        
        Database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

        //////////////////////////
        /// This is here Items are added before the start of the game
        //////////////////////////
        //AddItem(3); //mask
        //AddItem(1); //roughneck shot
        //AddItem(2); //carrot


    //    Debug.Log(Items[0].ItemName);
   //     Debug.Log(Items[1].ItemName);

        if (GameManager.MyGameType != GameManager.GameType.NewGame && 
            GameManager.MyGameType != GameManager.GameType.None)
        {
            SaveAndLoadGame load = new SaveAndLoadGame();
            load.LoadInventoryItemsFromMainMenu();
        }

    }

    public void Update()
    {
        if (UIDrawer.IsDraggingItem)
        {
            Vector3 mousePos = (Input.mousePosition - GameManager.Instance.UICanvas.InventoryCanvasGO.GetComponent<RectTransform>().localPosition);
            //previous problems with the mouse location were solved by distracting screen / 2.
            DraggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(mousePos.x + 15 - (Screen.width / 2), mousePos.y + 15 - (Screen.height / 2), mousePos.z);

            if (Input.GetMouseButtonDown(1))
            {
                HideDraggedItem();
                GameManager.Instance.MyInventory.Items[UIDrawer.DraggingFromSlotNo] = GameManager.Instance.MyInventory.TheDraggedItem;
             //   IInventory.Items[SlotNumber] = IInventory.TheDraggedItem;
            }
        }
    }

    public void ShowTooltip(Vector3 toolPosition, Item item)
    {
        Tooltip.SetActive(true);
        Tooltip.GetComponent<RectTransform>().localPosition = new Vector3(toolPosition.x + 360, toolPosition.y, toolPosition.z);

        Tooltip.transform.GetChild(0).GetComponent<Text>().text = item.ItemName;
        Tooltip.transform.GetChild(2).GetComponent<Text>().text = item.ItemDescription;
    }

    public void HideTooltip()
    {
        Tooltip.SetActive(false);
    }

    public void ShowDraggedItem(Item item, int slotNumber)
    {
        IndexOfDraggedItem = slotNumber;
        HideTooltip();
        DraggedItemGameObject.SetActive(true);
        TheDraggedItem = item;
        UIDrawer.IsDraggingItem = true;
        DraggedItemGameObject.GetComponent<Image>().sprite = item.ItemIcon;
    }

    public void EndDragging(int slotNumber)
    {
        Items[slotNumber] = TheDraggedItem;
        HideDraggedItem();
    }

    public void HideDraggedItem()
    {
        UIDrawer.IsDraggingItem = false;
        DraggedItemGameObject.SetActive(false);
    }

    public void CheckIfItemExists(int itemID, Item item)
    {
        Debug.LogWarning("check if exists: " + item.ItemName);

        for (int i = 0; i < Items.Count; i++)
        {
            if(Items[i].ItemID == itemID)
            {
      //          Debug.LogWarning(Items[i].ItemID + " and " + itemID);
                Items[i].ItemAmount = Items[i].ItemAmount + 1;
                break;
            }
            else if(i == Items.Count - 1)
            {
                Debug.LogWarning("add item at empty slot: " + item.ItemName);

                AddItemAtEmptySlot(item);
            }
        }
    }

    public void AddItem(int id)
    {
     //   Debug.Log("we now add item " + id);
        for (int i = 0; i < Database.Items.Count; i++)
        {
            if(Database.Items[i].ItemID == id)
            {
         //       Debug.Log("found the right item");
                Item item = Database.Items[i];

                if(Database.Items[i].IClass == Item.ItemClass.Consumable)
                {
                    CheckIfItemExists(id, item);
                    break;
                }
                else
                {
                    Debug.Log("add at empty slot: " + item);
                    AddItemAtEmptySlot(item);
                }
                break;
            }
        }
    }

    public void AddItemAtEmptySlot(Item item)
    {
        for (int i = 0; i < Items.Count; i++)
        {
            if(Items[i].ItemName == null)
            {
                if(item.ItemAmount == 0)    // added this later
                    item.ItemAmount = item.ItemAmount + 1;  // added this later
                
    //            Debug.Log(Items[i].IType + " is null. Item amount is: " + item.ItemAmount);
                Items[i] = item;
                break;
            }
        }
    }

    public void MakeAllSlotsEmpty()
    {

        Debug.Log("empty all slots");
        for (int i = 0; i < Items.Count; i++)
        {
            MakeSlotEmpty(i);
        }
    }

    public void MakeSlotEmpty(int slotNumber)
    {
        //Debug.Log("empty slot");
        Items[slotNumber] = new Item();
        HideTooltip();
    }

    public void LoadItemsFromSave()
    {
      //  Debug.Log(InitialiseInventoryItems.Count);
        for (int i = 0; i < InitialiseInventoryItems.Count; i++)
        {
            Debug.Log("Add to inventory" + InitialiseInventoryItems[i]);

            AddItem(InitialiseInventoryItems[i]);
        }
    }

    public void ResetAmounts()
    {
        for (int i = 0; i < Items.Count; i++)
        {
            Item item = Items[i];
            item.ItemAmount = 0;
        }
    }
}

