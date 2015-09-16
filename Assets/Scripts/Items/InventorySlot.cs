using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IDragHandler 
{
    public Item IItem;
    public int SlotNumber;
    public Image ItemImage;
    public Text ItemAmountTxt;

    private MouseClickOnObject mouseClickOnObject;
    private Text _descriptionText;

    private GameObject _investigateButton;
    private GameObject _interactionButton;
    private ActionPanel _actionPanel;

    void Start()
    {
        ItemAmountTxt = gameObject.transform.GetChild(1).GetComponent<Text>();
        ItemImage = gameObject.transform.GetChild(0).GetComponent<Image>();
        _actionPanel = new ActionPanel();
        _descriptionText = GameManager.Instance.UICanvas.ObjectDescriptionText;
    }

    void Update()
    {
        if (GameManager.Instance.MyInventory.Items[SlotNumber].ItemName != null)
        {
            ItemAmountTxt.enabled = false;
            ItemImage.enabled = true;
         //   ItemImage.sprite = GameManager.Instance.MyInventory.Items[SlotNumber].ItemIcon;/////////////
            ItemImage.sprite = GameManager.Instance.MyInventory.Items[SlotNumber].FindIcon(GameManager.Instance.MyInventory.Items[SlotNumber]);/////////////

            if (GameManager.Instance.MyInventory.Items[SlotNumber].Class == ItemClass.Consumable)
            {
                if (GameManager.Instance.MyInventory.Items[SlotNumber].ItemAmount > 0)
                {
                    ItemAmountTxt.enabled = true;
                    ItemAmountTxt.text = "" + GameManager.Instance.MyInventory.Items[SlotNumber].ItemAmount;
                }
                else
                {
                    // amount of consumable = 0
                    ItemImage.enabled = false;
                    GameManager.Instance.MyInventory.Items[SlotNumber] = new Item();
                    GameManager.Instance.MyInventory.HideTooltip();
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

        if (data.button == PointerEventData.InputButton.Left && GameManager.Instance.MyInventory.Items[SlotNumber].ItemName != null)
        {
            if (UIDrawer.IsDraggingItem)
            {
                bool tryCombine = false;
                tryCombine = GameManager.Instance.IIventoryItemWithObject.CombineItems(UIDrawer.DraggingItem, GameManager.Instance.MyInventory.Items[SlotNumber]);
                if (tryCombine)
                {
                    Debug.LogWarning("We can combine these two!!");
                    GameManager.Instance.MyInventory.EndDragging(SlotNumber);
                }
            }
            else
            {
                ItemImage.enabled = false;
                ActionPanel.ThisItem = GameManager.Instance.MyInventory.Items[SlotNumber];

                ActionPanel.IsInInventory = true;
                _actionPanel.MoveActionPanelToClickedObject(true);
            }
        }
        else if (data.button == PointerEventData.InputButton.Left && GameManager.Instance.MyInventory.Items[SlotNumber].ItemName == null &&
            UIDrawer.IsDraggingItem)
        {
            GameManager.Instance.MyInventory.EndDragging(SlotNumber);
        }

        else if (data.button == PointerEventData.InputButton.Right)
        {
            if (GameManager.Instance.MyInventory.Items[SlotNumber].ItemName == null && UIDrawer.IsDraggingItem)
            {
                GameManager.Instance.MyInventory.EndDragging(SlotNumber);
            }
            else if (UIDrawer.IsDraggingItem && GameManager.Instance.MyInventory.Items[SlotNumber].ItemName != null)
            {

                GameManager.Instance.MyInventory.Items[GameManager.Instance.MyInventory.IndexOfDraggedItem] = GameManager.Instance.MyInventory.Items[SlotNumber];   //switch the dragged item with the item on the slot the mouse is on

                GameManager.Instance.MyInventory.EndDragging(SlotNumber);
                _descriptionText.text = GameManager.Instance.MyInventory.Items[SlotNumber].ItemName;
                GameManager.Instance.UICanvas.NewObjectDescription();
            }
        }
    }

    public void OnPointerEnter(PointerEventData data)   //hovering
    {
        if (GameManager.GamePlayingMode == GameManager.GameMode.Paused) // don't show if paused.
            return;

        GameManager.Instance.UICanvas.Hovering = MainCanvas.Hoverings.MouseInInventory;

        if (GameManager.Instance.MyInventory.Items[SlotNumber].ItemName != null && !UIDrawer.IsDraggingItem)  // there is an item in the slot we are hov
        {
            GameManager.Instance.MyInventory.ShowTooltip(GameManager.Instance.MyInventory.SlotList[SlotNumber].GetComponent<RectTransform>().localPosition, GameManager.Instance.MyInventory.Items[SlotNumber]);

            _descriptionText.enabled = true;
            _descriptionText.text = GameManager.Instance.MyInventory.Items[SlotNumber].ItemName;

            GameManager.Instance.UICanvas.NewObjectDescription();
        }
        else if (GameManager.Instance.MyInventory.Items[SlotNumber].ItemName != null && UIDrawer.IsDraggingItem)
        {
            _descriptionText.enabled = true;
            _descriptionText.text = "Combine " + GameManager.Instance.MyInventory.TheDraggedItem.ItemName + " with " + GameManager.Instance.MyInventory.Items[SlotNumber].ItemName;
            GameManager.Instance.UICanvas.NewObjectDescription();
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        _actionPanel.PlayActionPanelForClickedObject(GameManager.Instance.MyInventory.Items[SlotNumber], SlotNumber);
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (GameManager.Instance.MyInventory.Items[SlotNumber].ItemName != null)
            GameManager.Instance.MyInventory.HideTooltip();

        if (UIDrawer.IsDraggingItem)
        {
            _descriptionText.text = UIDrawer.DraggingItem.ItemName;
            GameManager.Instance.UICanvas.Hovering = MainCanvas.Hoverings.MouseInWorld;
            GameManager.Instance.UICanvas.NewObjectDescription();
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
            if (GameManager.Instance.MyInventory.Items[SlotNumber].ItemName != null)
            {
                UIDrawer.DraggingFromSlotNo = SlotNumber;
                UIDrawer.DraggingItem = GameManager.Instance.MyInventory.Items[SlotNumber];
                GameManager.Instance.MyInventory.ShowDraggedItem(GameManager.Instance.MyInventory.Items[SlotNumber], SlotNumber);

                Debug.Log("dragging: " + GameManager.Instance.MyInventory.TheDraggedItem.ItemName);

                GameManager.Instance.MyInventory.Items[SlotNumber] = new Item();

                ItemAmountTxt.enabled = false;

                _descriptionText.enabled = true;
            }
        }
    }

    public void MakeSlotEmpty()
    {
        if(ItemImage != null)
            ItemImage.enabled = false;

        GameManager.Instance.MyInventory.Items[SlotNumber] = new Item();
        GameManager.Instance.MyInventory.HideTooltip();
    }
}

