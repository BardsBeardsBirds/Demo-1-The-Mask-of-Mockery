using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    public static int CharacterSituation = 1;
    public static Sentinel Instance;
    public static bool PushBack = false;
    public Animator Animator;
    private SphereCollider _thisCollider;

    private static List<int> LastBefore3024 = new List<int>() { 3008, 3013, 3015, 3017 };
    private static List<int> LastBefore3006 = new List<int>() { 3005, 3013, 3015, 3017 };
    private static List<int> LastBefore3009 = new List<int>() { 3005, 3008, 3015, 3017 };
    private static List<int> LastBefore3014 = new List<int>() { 3005, 3008, 3013, 3017 };
    private static List<int> LastBefore3016 = new List<int>() { 3005, 3008, 3013, 3015, 3017 };
    private static List<int> LastBefore3018 = new List<int>() { 3005, 3008, 3013, 3015, 3017 };


    private static Dictionary<int, List<int>> LastLinesBeforeOption = new Dictionary<int, List<int>>()
    { 
        {3024, LastBefore3024},
        {3006, LastBefore3006},
        {3009, LastBefore3009},
        {3014, LastBefore3014},
        {3016, LastBefore3016},
        {3018, LastBefore3018},
    };

    public void Start()
    {
        Instance = this;
        _thisCollider = GetComponent<SphereCollider>();
        _thisCollider.isTrigger = true;
        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Sentinel);
    }

    public void DialogueLineNumberToSituation(int lastLineID)   //the last line of dialogue determines which situation will follow
    {

        if (IsLastBefore(lastLineID, 3006))
            DialogueMenu.AddToDialogueOptions(3006);

        if (IsLastBefore(lastLineID, 3009) && (DialogueManager.IsDialoguePassed(3024) || DialogueManager.IsDialoguePassed(3006)))
            DialogueMenu.AddToDialogueOptions(3009);

        if (IsLastBefore(lastLineID, 3014) && (DialogueManager.IsDialoguePassed(3024) || DialogueManager.IsDialoguePassed(3006) || DialogueManager.IsDialoguePassed(3009)))
            DialogueMenu.AddToDialogueOptions(3014);

        if (IsLastBefore(lastLineID, 3016) && DialogueManager.IsDialoguePassed(3014))
            DialogueMenu.AddToDialogueOptions(3016);

        if (IsLastBefore(lastLineID, 3024))
            DialogueMenu.AddToDialogueOptions(3024);

        if (IsLastBefore(lastLineID, 3018))
            DialogueMenu.AddToDialogueOptions(3018);    // exit

        switch (lastLineID)
        {
            //opening options
            case 1:
                FindDialogueSituation(1);
                break;
            case 2:
                FindDialogueSituation(2);
                break;
            case 3:
                FindDialogueSituation(3);
                break;
            case 4:
                FindDialogueSituation(4);
                break;
            default:
                FindDialogueSituation(999);
                break;
        }
    }

    public void FindDialogueSituation(int dialogueSituation)
    {
        CharacterControllerLogic.Instance.GoToTalkingState();

        switch (dialogueSituation)
        {
            case 1: //SITUATION 1
                //Sentinel.Instance.HoldItThere();
                Debug.Log("HOLD IT THERE");

                AddToDialogue(3001);
                AddToDialogue(3002);
                AddToDialogue(3003);

                DialoguePlayback.EndingDialogue = true;

                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(3001); 

                WorldEvents.EmmonWasBlockedBySentinel = true;

                SentinelBlocker.TryingToSneakPast = false;

                break;
            case 2: //SITUATION 2
                DialogueMenu.AddToDialogueOptions(3024);
                DialogueMenu.AddToDialogueOptions(3006);
                DialogueMenu.AddToDialogueOptions(3018);
                DialogueMenu.FindDialogueOptionText(Character.Sentinel);
                break;
            case 3: //SITUATION 3  //player has a roughneck shot
                PassSentinelDialogue();
                break;
            case 4: //SITUATION 4   //we finished talking
                break;
            case 999:
                DialogueMenu.FindDialogueOptionText(Character.Sentinel);
                break;
            default: //in all other dialogue options
                DialogueMenu.FindDialogueOptionText(Character.Sentinel);
                Debug.LogError("I don't know this dialogue situation: Situation " + dialogueSituation);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        //if (dialogueOptionID == 3001)   // hold it there
        //{
        //    AddToDialogue(3001);
        //    AddToDialogue(3002);
        //    AddToDialogue(3003);

        //    DialoguePlayback.EndingDialogue = true;
        //}

        if (dialogueOptionID == 3024)
        {
            DialoguePlayback.DeleteLineID = 3024;

            AddToDialogue(3004);
            AddToDialogue(3005);
        }

        if (dialogueOptionID == 3006)
        {
            DialoguePlayback.DeleteLineID = 3006;

            AddToDialogue(3006);
            AddToDialogue(3007);
            AddToDialogue(3008);
        }

        if (dialogueOptionID == 3009)
        {
            DialoguePlayback.DeleteLineID = 3009;

            AddToDialogue(3009);
            AddToDialogue(3010);
            AddToDialogue(3011);
            AddToDialogue(3012);
            AddToDialogue(3013);

            WorldEvents.EmmonKnowsWhatSentinelWants = true;//not sure about puting in this one
        }

        if (dialogueOptionID == 3014)
        {
            DialoguePlayback.DeleteLineID = 3014;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(3015);

            WorldEvents.EmmonKnowsWhatSentinelWants = true;
        }

        if (dialogueOptionID == 3016)
        {
            AddToDialogue(dialogueOptionID);
            AddToDialogue(3017);
        }

        if (dialogueOptionID == 3018)
        {
            AddToDialogue(dialogueOptionID);

            DialoguePlayback.EndingDialogue = true;

            if (WorldEvents.EmmonKnowsMaskLocation)
                DialogueManager.IsDialoguePassed(1055);
        }
    }

    private static void AddToDialogue(int dialogueID)
    {
        DialoguePlayback.AddToDialogue(dialogueID);
    }

    private bool IsLastBefore(int lastLine, int dialogueOptionID)
    {
        if (LastLinesBeforeOption[dialogueOptionID].Contains(lastLine))
            return true;

        return false;
    }

    public void PassSentinelDialogue()
    {
        AddToDialogue(3025);    //here I go..

        AddToDialogue(3019);
        AddToDialogue(3020);
        AddToDialogue(3021);
        AddToDialogue(3022);
        DialoguePlayback.EndingDialogue = true;
        WorldEvents.EmmonHasPassedTheSentinel = true;
        GameObject blockerGO = GameObject.Find("SentinelBlockade");
        GameManager.Destroy(blockerGO);

        DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(3019);

        if (UIDrawer.IsDraggingItem && UIDrawer.DraggingItem.IType == ItemType.RoughneckShot)    // we are holding the item
        {
            Debug.Log(UIDrawer.DraggingItem.IType);
        }
    }
}
