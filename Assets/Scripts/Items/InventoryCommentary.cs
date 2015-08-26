using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryCommentary
{
    public static int LastLineID = 0;
    public static int CurrentID = 0;

    public static List<int> CurrentDialogueIDs = new List<int>();

    //public static Dictionary<int, string> InvestigationHoverLines = new Dictionary<int, string>()
    //{
    //    {5201, "Investigate Roughneck Shot"},
    //    {5202, "Investigate carrot"},
    //    {5203, "Investigate the Mask of Mockery"},

    //};

    //public static Dictionary<int, string> InteractionHoverLines = new Dictionary<int, string>()
    //{
    //    {5301, "Drink Roughneck Shot"},
    //    {5302, "Eat carrot"},
    //    {5303, "Put on the Mask of Mockery"},
    //};

    public static IEnumerator InventoryCommentaryRoutine(DialogueType dialogueType, Item inventoryItem)
    {
        FindLines(dialogueType, inventoryItem);
        CharacterControllerLogic.Instance.GoToTalkingState();
        DialogueManager.ThisDialogueType = dialogueType;

        for (int i = 0; i < InventoryCommentary.CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;

            if (dialogueType == DialogueType.InventoryInvestigation)
            {
                foreach (SpokenLine spokenLine in GameManager.InventoryInvestigationDialogue)
                {
                    if (spokenLine.ID == id)
                    {
                        DialoguePlayback.SetCurrentDialogueLine(spokenLine.Text);

                        break;
                    }
                }
            }
            else if (dialogueType == DialogueType.InventoryInteraction)
            {
                foreach (SpokenLine spokenLine in GameManager.InventoryInteractionDialogue)
                {
                    if (spokenLine.ID == id)
                    {
                        DialoguePlayback.SetCurrentDialogueLine(spokenLine.Text);

                        break;
                    }
                }
            }

            DialoguePlayback.Instance.ShowDialogueLines();

            string audioFile = "ObjectInteraction/" + id;
            AudioManager.Instance.PlayDialogueAudio(audioFile);


            if (i + 1 == InventoryCommentary.CurrentDialogueIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                InventoryCommentary.LastLineID = id;
                ClearDialogueList();
            }

            float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }
    }

    private static void FindLines(DialogueType dialogueType, Item inventoryItem)
    {
        if (dialogueType == DialogueType.InventoryInvestigation)
            FindInvestigationLines(inventoryItem);
        else if (dialogueType == DialogueType.InventoryInteraction)
            FindInteractionLines(inventoryItem);
    }

    private static void ClearDialogueList()
    {
        CurrentDialogueIDs.Clear();
    }

    #region ObjectLines
    private static void FindInvestigationLines(Item inventoryItem)
    {
        switch (inventoryItem.IType)
        {
            case Item.ItemType.RoughneckShot:
                CurrentDialogueIDs.Add(5001);
                break;
            case Item.ItemType.Carrot:
                CurrentDialogueIDs.Add(5002);
                break;
            case Item.ItemType.MaskOfMockery:
                CurrentDialogueIDs.Add(5003);
                break;
            default:
                break;
        }
    }

    private static void FindInteractionLines(Item inventoryItem)
    {
        switch (inventoryItem.IType)
        {
            case Item.ItemType.RoughneckShot:
                CurrentDialogueIDs.Add(5101);
                break;
            case Item.ItemType.Carrot:
                CurrentDialogueIDs.Add(5102);
                break;
            case Item.ItemType.MaskOfMockery:
                CurrentDialogueIDs.Add(5103);
                break;
            default:
                break;
        }
    }

    public static int FindInvestigationHoverLines(Item inventoryItem)
    {
        int id = 0;

        switch (inventoryItem.IType)
        {
            case Item.ItemType.RoughneckShot:
                id = 5201;
                break;
            case Item.ItemType.Carrot:
                id = 5202;
                break;
            case Item.ItemType.MaskOfMockery:
                id = 5203;
                break;
            default:
                break;
        }
        return id;
    }

    public static int FindInteractionHoverLines(Item inventoryItem)
    {
        int id = 0;

        switch (inventoryItem.IType)
        {
            case Item.ItemType.RoughneckShot:
                id = 5301;
                break;
            case Item.ItemType.Carrot:
                id = 5302;
                break;
            case Item.ItemType.MaskOfMockery:
                id = 5303;
                break;
            default:
                break;
        }
        return id;
    }
    #endregion
}
