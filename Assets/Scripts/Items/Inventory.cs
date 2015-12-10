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
    public Animator MyAnimator;
    public List<GameObject> SlotList = new List<GameObject>();
    public List<Item> Items = new List<Item>();
    public List<int> InitialiseInventoryItems = new List<int>();
    public GameObject Slots;
    public GameObject DraggedItemGameObject;
    public ItemDatabase Database;
    public Item TheDraggedItem;
    public int IndexOfDraggedItem;

    public int SlotsLoaded = 0;

    public void Awake()
    {
        Instance = GameManager.Instance.MyInventory;
        MyAnimator = this.GetComponent<Animator>();
        if (MyAnimator == null)
            Debug.LogError("Could not find the inventory animator");
        MyAnimator.SetBool("Open", false);

        Database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        InitialiseInventoryItems.Clear();
        ResetAmounts();

        Debug.Log("cleared inventory list");
       
        Instance.Slots = Resources.Load("Prefabs/UI/InventoryWindow/Slot") as GameObject;
     //   Instance.Tooltip = Resources.Load("Prefabs/UI/InventoryWindow/Tooltip") as GameObject;

        foreach (GameObject slot in SlotList)
        {
            Items.Add(new Item());
        }
    }

    public void Start()
    {
        Instance = this;

        MyAnimator.SetBool("Open", false);

        Database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

        //////////////////////////
        /// This is here Items are added before the start of the game
        //////////////////////////
        ItemManager.AddItem(ItemType.MaskOfMockery);
        //ItemManager.AddItem(ItemType.RoughneckShot);
        //ItemManager.AddItem(ItemType.AysSecretIngredients);
        //ItemManager.AddItem(ItemType.BookOfMusicalWildlife);
        //ItemManager.AddItem(ItemType.Carrot);
        //ItemManager.AddItem(ItemType.Carrot);
        //ItemManager.AddItem(ItemType.Carrot);


        if (GameManager.MyGameType != GameManager.GameType.NewGame && 
            GameManager.MyGameType != GameManager.GameType.None)
        {
            SaveAndLoadGame load = new SaveAndLoadGame();
            Debug.Log("TODO: load inventory function");
      //      load.LoadInventoryItemsFromMainMenu();
        }

    }

    public void Update()
    {
        if (UIDrawer.IsDraggingItem)
        {
            Vector3 mousePos = (Input.mousePosition - GameManager.Instance.UICanvas.InventoryCanvasGO.GetComponent<RectTransform>().localPosition);
            DraggedItemGameObject.GetComponent<RectTransform>().localPosition = new Vector3(mousePos.x + 15 - (Screen.width / 2), mousePos.y + 15 - (Screen.height / 2), mousePos.z);

            if (Input.GetMouseButtonDown(1))
            {
                HideDraggedItem();
                GameManager.Instance.MyInventory.Items[UIDrawer.DraggingFromSlotNo] = GameManager.Instance.MyInventory.TheDraggedItem;
            }
        }
    }

    public void ShowDraggedItem(Item item, int slotNumber)
    {
        IndexOfDraggedItem = slotNumber;
        DraggedItemGameObject.SetActive(true);
        TheDraggedItem = item;
        UIDrawer.IsDraggingItem = true;
        item.ItemIcon = item.FindIcon(item);
        DraggedItemGameObject.GetComponent<Image>().sprite = item.ItemIcon;
    }

    public void EndDragging(int slotNumber)
    {
        Items[slotNumber] = TheDraggedItem;
        HideDraggedItem();
    }

    public void HideDraggedItem()
    {
        Debug.Log("hide dragged item in inventory");

        UIDrawer.IsDraggingItem = false;
        DraggedItemGameObject.SetActive(false);
    }
    public void DeleteDraggedItem()
    {
        Debug.Log("delete dragged item in inventory");

        UIDrawer.IsDraggingItem = false;
        DraggedItemGameObject.SetActive(false);
        GameManager.Instance.MyInventory.Items[UIDrawer.DraggingFromSlotNo] = new Item();
        TheDraggedItem = new Item();

    }
    public void CheckIfItemExists(int itemID, Item item)
    {
        Debug.LogWarning("check if exists: " + item.IType);

        for (int i = 0; i < Items.Count; i++)
        {
            if(Items[i].ID == itemID)
            {
      //          Debug.LogWarning(Items[i].ItemID + " and " + itemID);
                Items[i].ItemAmount = Items[i].ItemAmount + 1;
                break;
            }
            else if(i == Items.Count - 1)
            {
                Debug.LogWarning("add item at empty slot: " + item.IType);

                AddItemAtEmptySlot(item);
            }
        }
    }

    public void AddItem(int id)
    {
        //Debug.Log("we now add item " + id);
        for (int i = 0; i < Database.Items.Count; i++)
        {
            if(Database.Items[i].ID == id)
            {
         //       Debug.Log("found the right item");
                Item item = Database.Items[i];

                if(Database.Items[i].Class == ItemClass.Consumable)
                {
                    CheckIfItemExists(id, item);
                    break;
                }
                else
                {
                    Debug.Log("add at empty slot: " + item.IType);
                    AddItemAtEmptySlot(item);
                }
                break;
            }
        }
    }

    public void RemoveItem(ItemType itemType)
    {
        for (int i = 0; i < GameManager.Instance.MyInventory.Items.Count; i++)
        {
            if (GameManager.Instance.MyInventory.Items[i].IType == itemType)
            {
                Debug.Log("remove " + i + " " + GameManager.Instance.MyInventory.Items[i].IType);
             //   SlotList[i].GetComponent<InventorySlot>().MakeSlotEmpty();
                GameManager.Instance.MyInventory.MakeSlotEmpty(i);
                return;
            }
        }

        Debug.LogWarning("Could not find " + itemType + " in the inventory!");
    }

    public void AddItemAtEmptySlot(Item item)
    {
        Debug.Log("add at empty slot: " + item);
        for (int i = 0; i < Items.Count; i++)
        {
            if(Items[i].IType == ItemType.Empty)
            {
                if (item.ItemAmount == 0)    // added this later
                {
                    item.ItemIcon = item.FindIcon(item);
                    Debug.LogWarning("add item " + item.ItemName + ". icon is: " + "Icons/Items/" + item.ItemName);
                    item.ItemAmount = item.ItemAmount + 1;  // added this later
                }               
                //Debug.Log(Items[i].IType + " is null. Item amount is: " + item.ItemAmount);
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
        Items[slotNumber] = new Item();
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

    public bool LookForItem(ItemType itemType)
    {
        bool isInInventory = false;

        for (int i = 0; i < Items.Count; i++)
        {
            Item item = Items[i];
            if(item.IType == itemType)
            {
                isInInventory = true;
                return isInInventory;
            }
        }
        return isInInventory;
    }
}

