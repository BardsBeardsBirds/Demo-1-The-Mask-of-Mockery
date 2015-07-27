using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryCommentary
{
    public static int LastLineID = 0;
    public static int CurrentID = 0;

    public static List<int> CurrentDialogueIDs = new List<int>();

    public static Dictionary<int, string> InvestigationLines = new Dictionary<int, string>()
    {
        {5001, "It is a roughneck shot. Ay prepared it."},
        {5002, "It is orange."},
        {5003, "What a beautiful mask!"},

    };

    public static Dictionary<int, string> InteractionLines = new Dictionary<int, string>()
    {
        {6001, "Let's drink it when we are going to pass the sentinel"},
        {6002, "Delicious!"},
        {6003, "I don't want to put on the mask."},

    };

    public static Dictionary<int, string> InvestigationHoverLines = new Dictionary<int, string>()
    {
        {7001, "Investigate Roughneck Shot"},
        {7002, "Investigate carrot"},
        {7003, "Investigate the Mask of Mockery"},

    };

    public static Dictionary<int, string> InteractionHoverLines = new Dictionary<int, string>()
    {
        {8001, "Drink Roughneck Shot"},
        {8002, "Eat carrot"},
        {8003, "Put on the Mask of Mockery"},
    };



    public static IEnumerator InventoryCommentaryRoutine(SpeechType speechtype, Item inventoryItem)
    {
        FindLines(speechtype, inventoryItem);
        CharacterControllerLogic.Instance.GoToTalkingState();
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.InventoryCommentary;

        for (int i = 0; i < InventoryCommentary.CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;
            if (speechtype == SpeechType.Investigation)
                DialoguePlayback.SetCurrentDialogueLine(InvestigationLines[id]);
            else if (speechtype == SpeechType.Interaction)
                DialoguePlayback.SetCurrentDialogueLine(InteractionLines[id]);

            DialoguePlayback.Instance.ShowDialogueLines();

            string audioFile = "ObjectInteraction/" + id;
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            Debug.Log(CharacterControllerLogic.Instance.State);
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

    private static void FindLines(SpeechType speechType, Item inventoryItem)
    {
        if (speechType == SpeechType.Investigation)
            FindInvestigationLines(inventoryItem);
        else if (speechType == SpeechType.Interaction)
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
                CurrentDialogueIDs.Add(6001);
                break;
            case Item.ItemType.Carrot:
                CurrentDialogueIDs.Add(6002);
                break;
            case Item.ItemType.MaskOfMockery:
                CurrentDialogueIDs.Add(6003);
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
                id = 7001;
                break;
            case Item.ItemType.Carrot:
                id = 7002;
                break;
            case Item.ItemType.MaskOfMockery:
                id = 7003;
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
                id = 8001;
                break;
            case Item.ItemType.Carrot:
                id = 8002;
                break;
            case Item.ItemType.MaskOfMockery:
                id = 8003;
                break;
            default:
                break;
        }
        return id;
    }
    #endregion
}
