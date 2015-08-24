using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionPanel
{
    public enum ItemInteractionType { ObjectInWorld, InventoryItemInteraction};
    public ItemDatabase Database;

    private GameObject _investigateButton;
    private GameObject _interactionButton;
    private GameObject _actionPanelGO;

    public static ItemInteractionType InteractionType;
    public static Item ThisItem;

    public static ObjectsInLevel LastHoveredObject;

    public void MoveActionPanelToClickedObject(ItemInteractionType itemInteractionType) // move action panel
    {
        InteractionType = itemInteractionType;

        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Talking || CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.TalkingLastLine)
            return;

        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.None;

        if (GameObject.Find("InteractionButton") != null)
            return;


        if(itemInteractionType == ItemInteractionType.ObjectInWorld)
            _actionPanelGO = GameObject.Find("ActionPanelObjects");
        else
            _actionPanelGO = GameObject.Find("ActionPanelInventory");

        SetUpActionPanel();
    }

    public void PlayActionPanelForClickedObject(ObjectsInLevel naam, Transform trans)   //Objects in world.
    {
        if (MouseClickOnObject.MouseIsOnInvestigateButton)
            InvestigateObject(naam);
        else if (MouseClickOnObject.MouseIsOnInteractionButton)
        {
            bool inRange = CalculateDistanceWitNPC(naam, trans);
            if (inRange)
                InteractWithObject(naam);
            else
            {
                DialogueManager.ThisDialogueType = DialogueManager.DialogueType.ObjectInteraction;
                DialoguePlayback.Instance.PlaybackCommentary();
            }
        }

        GameManager.Destroy("InteractionButton");
        GameManager.Destroy("InvestigateButton");

        MouseClickOnObject.MouseIsOnInvestigateButton = false;
        MouseClickOnObject.MouseIsOnInteractionButton = false;
    }

    public void PlayActionPanelForClickedObject(Item item, int slotNumber)  //Inventory
    {
        if (MouseClickOnObject.MouseIsOnInvestigateButton)
            InvestigateItem(item);
        else if (MouseClickOnObject.MouseIsOnInteractionButton)
        {
            InteractWithItem(item, slotNumber);
        }

        GameManager.Destroy("InteractionButton");
        GameManager.Destroy("InvestigateButton");

        MouseClickOnObject.MouseIsOnInvestigateButton = false;
        MouseClickOnObject.MouseIsOnInteractionButton = false;
    }

    public static void HideActionPanel()
    {
        GameManager.Destroy("InteractionButton");
        GameManager.Destroy("InvestigateButton");

        MouseClickOnObject.MouseIsOnInvestigateButton = false;
        MouseClickOnObject.MouseIsOnInteractionButton = false;
    }

    public void InvestigateObject(ObjectsInLevel naam)
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.ObjectInteraction;
        MyConsole.WriteToConsole("Start Investigation of " + MouseClickOnObject.ObjectLines[naam]);
        DialoguePlayback.Instance.PlaybackCommentary(SpeechType.Investigation, naam);
    }

    public void InvestigateItem(Item item)
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.ObjectInteraction;
        MyConsole.WriteToConsole("Start Investigation of " + item.ItemName);
        DialoguePlayback.Instance.PlaybackCommentary(SpeechType.Investigation, item);
        GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }

    public void InteractWithObject(ObjectsInLevel naam) //items in the world
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.ObjectInteraction;
        MyConsole.WriteToConsole("Start Interaction with " + MouseClickOnObject.ObjectLines[naam]);
        DialoguePlayback.Instance.PlaybackCommentary(SpeechType.Interaction, naam); //SOUND
    }

    public void InteractWithItem(Item item, int SlotNumber) //items in the inventory
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.ObjectInteraction;
        MyConsole.WriteToConsole("Start Interaction with " + item.ItemName);
        if(item.IClass == Item.ItemClass.Consumable)
        {
            //Consume the item
            GameManager.Instance.MyInventory.Items[SlotNumber].ItemAmount--;
        }

        DialoguePlayback.Instance.PlaybackCommentary(SpeechType.Interaction, item); //SOUND
        GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }

    public bool CalculateDistanceWitNPC(ObjectsInLevel naam, Transform trans)
    {
        float distance = Vector3.Distance(trans.position, GameManager.Player.transform.position);
       // Debug.Log("Distance: " + distance);

        if (naam == ObjectsInLevel.BennyTwospoons || naam == ObjectsInLevel.AyTheTearCollector || naam == ObjectsInLevel.Sentinel)
            if (distance > 8)
                return false;

        return true;
    }

    public static void ShowHoverInteractionLine()
    {
        if (InteractionType == ItemInteractionType.ObjectInWorld)
        {
            GameManager.Instance.UICanvas.ObjectDescriptionText.text = MouseClickOnObject.ObjectInteractionLines[MouseClickOnObject.CurrentObject];
            GameManager.Instance.UICanvas.NewObjectDescription();
        }
        else
        {
            int id = InventoryCommentary.FindInteractionHoverLines(ThisItem);
            GameManager.Instance.UICanvas.ObjectDescriptionText.text = InventoryCommentary.InteractionHoverLines[id];
            GameManager.Instance.UICanvas.NewObjectDescription();
        }
    }

    public static void ShowHoverInvestigationLine()
    {
        if (InteractionType == ItemInteractionType.ObjectInWorld)
        {
            GameManager.Instance.UICanvas.ObjectDescriptionText.text = MouseClickOnObject.ObjectInvestigationLines[MouseClickOnObject.CurrentObject];
            GameManager.Instance.UICanvas.NewObjectDescription();
        }
        else
        {
            int id = InventoryCommentary.FindInvestigationHoverLines(ThisItem);
            GameManager.Instance.UICanvas.ObjectDescriptionText.text = InventoryCommentary.InvestigationHoverLines[id];
            GameManager.Instance.UICanvas.NewObjectDescription();
        }
    }

    private void SetUpActionPanel()
    {
        _interactionButton = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InteractionButton")) as GameObject;
        _interactionButton.gameObject.name = "InteractionButton";
        _interactionButton.transform.SetParent(_actionPanelGO.transform);
        _interactionButton.transform.position = new Vector3(Input.mousePosition.x + 22, Input.mousePosition.y + 22, 0);

        _investigateButton = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/InvestigateButton")) as GameObject;
        _investigateButton.gameObject.name = "InvestigateButton";
        _investigateButton.transform.SetParent(_actionPanelGO.transform);
        _investigateButton.transform.position = new Vector3(Input.mousePosition.x - 22, Input.mousePosition.y - 22, 0);
    }

}

