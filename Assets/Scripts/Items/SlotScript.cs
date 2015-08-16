using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IDragHandler 
{
    public Item IItem;
    public int SlotNumber;
    public Image ItemImage;
    public static Inventory IInventory;
    public Text ItemAmountTxt;

    private MouseClickOnObject mouseClickOnObject;
    private Text _descriptionText;

    private GameObject _investigateButton;
    private GameObject _interactionButton;
    private ActionPanel _actionPanel;

    void Start()
    {
        ItemAmountTxt = gameObject.transform.GetChild(1).GetComponent<Text>();
        IInventory = GameManager.Instance.MyInventory;
        ItemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        _actionPanel = new ActionPanel();
        _descriptionText = GameManager.Instance.UICanvas.ObjectDescriptionText;
    }

    void Update()
    {
        if (IInventory.Items[SlotNumber].ItemName != null)
        {
            ItemAmountTxt.enabled = false;
            ItemImage.enabled = true;
            ItemImage.sprite = IInventory.Items[SlotNumber].ItemIcon;

            if(IInventory.Items[SlotNumber].IClass == Item.ItemClass.Consumable)
            {
                if (IInventory.Items[SlotNumber].ItemAmount > 0)
                {
                    ItemAmountTxt.enabled = true;
                    ItemAmountTxt.text = "" + IInventory.Items[SlotNumber].ItemAmount;
                }
                else
                {
                    // amount of consumable = 0
                    ItemImage.enabled = false;
                    IInventory.Items[SlotNumber] = new Item();
                    IInventory.HideTooltip();
                }
            }
        }
        else
        {
            ItemImage.enabled = false;
        }
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (GameManager.GamePlayingMode == GameManager.GameMode.Paused) // don't show if paused.
            return;

        if (data.button == PointerEventData.InputButton.Left && IInventory.Items[SlotNumber].ItemName != null)
        {
            if (UIDrawer.IsDraggingItem)
            {
                bool tryCombine = false;
                tryCombine = GameManager.Instance.IIventoryItemWithObject.CombineItems(UIDrawer.DraggingItem, IInventory.Items[SlotNumber]);
                if (tryCombine)
                    Debug.LogWarning("We can combine these two!!");
            }
            else
            {
                ItemImage.enabled = false;
                ActionPanel.ThisItem = IInventory.Items[SlotNumber];

                _actionPanel.MoveActionPanelToClickedObject(ActionPanel.ItemInteractionType.InventoryItemInteraction);
            }
        }
        if (data.button == PointerEventData.InputButton.Right)
        {
            if (IInventory.Items[SlotNumber].ItemName == null && UIDrawer.IsDraggingItem)
            {
                IInventory.Items[SlotNumber] = IInventory.TheDraggedItem;
                IInventory.HideDraggedItem();
            }
            else if (UIDrawer.IsDraggingItem && IInventory.Items[SlotNumber].ItemName != null)
            {
                IInventory.Items[IInventory.IndexOfDraggedItem] = IInventory.Items[SlotNumber];   //go to the slot where the mouse is on 
                IInventory.Items[SlotNumber] = IInventory.TheDraggedItem;
                IInventory.HideDraggedItem();
            }
        }
    }

    public void OnPointerEnter(PointerEventData data)   //hovering
    {
        if (GameManager.GamePlayingMode == GameManager.GameMode.Paused) // don't show if paused.
            return;

        GameManager.Instance.UICanvas.Hovering = MainCanvas.Hoverings.MouseInInventory;

        if (IInventory.Items[SlotNumber].ItemName != null && !UIDrawer.IsDraggingItem)  // there is an item in the slot we are hov
        {
            IInventory.ShowTooltip(IInventory.SlotList[SlotNumber].GetComponent<RectTransform>().localPosition, IInventory.Items[SlotNumber]);

            _descriptionText.enabled = true;

            _descriptionText.text = IInventory.Items[SlotNumber].ItemName;
        }
        else if (IInventory.Items[SlotNumber].ItemName != null && UIDrawer.IsDraggingItem)
        {
            _descriptionText.enabled = true;

            _descriptionText.text = "Combine " + IInventory.TheDraggedItem.ItemName + " with " + IInventory.Items[SlotNumber].ItemName;

        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        _actionPanel.PlayActionPanelForClickedObject(IInventory.Items[SlotNumber], SlotNumber);
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (IInventory.Items[SlotNumber].ItemName != null)
           IInventory.HideTooltip();

        if (UIDrawer.IsDraggingItem)
        {
            _descriptionText.text = UIDrawer.DraggingItem.ItemName;
            GameManager.Instance.UICanvas.Hovering = MainCanvas.Hoverings.MouseInWorld;
        }
        else
        {
            GameManager.Instance.UICanvas.HideObjectDescriptionText();
            GameManager.Instance.UICanvas.Hovering = MainCanvas.Hoverings.MouseInWorld;
        }
    }

    public void OnDrag(PointerEventData data)
    {
        if (data.button == PointerEventData.InputButton.Right)
        {
            if(IInventory.Items[SlotNumber].ItemName != null)
            {
                UIDrawer.DraggingFromSlotNo = SlotNumber;
                UIDrawer.DraggingItem = IInventory.Items[SlotNumber];
                IInventory.ShowDraggedItem(IInventory.Items[SlotNumber], SlotNumber);

                Debug.Log("dragging: " + IInventory.TheDraggedItem.ItemName);

                IInventory.Items[SlotNumber] = new Item();

                ItemAmountTxt.enabled = false;

                _descriptionText.enabled = true;
            }
        }
    }

    public void MakeSlotEmpty()
    {
        if(ItemImage != null)
            ItemImage.enabled = false;

        IInventory.Items[SlotNumber] = new Item();
        IInventory.HideTooltip();
    }
}

