using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    public static int CharacterSituation = 1;
    public static Sentinel Instance;
    public static bool PushBack = false;
    public Animator Animator;
    private SphereCollider _thisCollider;


    #region NPCTalkingIDs
    public static List<int> NPCTalkingIDs = new List<int>()
    {
        3001,
        3003,
        3005,
        3005,
        3008,
        3010,
        3011,
        3013,
        3015,
        3017,
        3021,
    };

    #endregion NPCTalkingIDs

    #region SpeakingLines
    public static Dictionary<int, string> SpeakingLines = new Dictionary<int, string>() 
    { 
        {3001, "Hold it there! No one can pass. King’s order."},
        {3002, "King’s order? But.."},
        {3003, "Shoo!"},
        {3004, "We bards have practised the art of storytelling for years. How about I tell you the most beautiful story you have every heard; a story so touching that it will make tears well in your eyes? … and then you let me pass?"},
        {3005, "You will tell me a story that will make me cry? And then you will surely take my tears to the tear collector, don’t you? No-o, I am not falling for that one."},
        {3006, "I just received a King’s order to make way for all bards in Baton! Please let me through..!"},
        {3007, "Ehm... Would you step aside..?"},
        {3008, "You didn’t think that was going to work, didn’t you?"},
        {3009, "Please let me pass?"},
        {3010, "Listen, wandering around in the wilderness ahead is very dangerous, and I have specific orders to look out for you, music boy. "},
        {3011, "The king is very worried you will get yourself in trouble again after you… hum.. well, we all know what happened at the castle… Look at yourself, you are so green.."},
        {3012, "No I’m not.."},
        {3013, "I am afraid I have to stop you right here."},
        {3014, "What can I do to make you change your mind?"},
        {3015, "As I told you, you just don’t seem to fit for going into the wild. I have been a royal guard since.., throughout this whole game, and I can tell by experience a scrag like you won’t last long out there. Make an impression on me and I might change me mind."},
        {3016, "What can I do to make you change your mind?"},
        {3017, "Make an impression on me and I might change me mind."},
        {3018, "I guess I will have to leave you for now. But this is not the end, rather a beginning!"},
        {3019, "Hello, my faithful but lonely servant, I’m back and I am going to be really clear with you this time:"},
        {3020, "I will not tolerate any more delay. You are obstructing this road, and consequently my journey has stagnated. This unfortunate situation has to end now. Stand aside!"},
        {3021, "It seems you learnt something in the meantime! With this attitude, I can’t do anything but granting you passage sir. King Archimedes must be proud of you."},
        {3022, "When a brave man takes a stand, the spines of others are often stiffened."},
        {3023, "I think we finished talking."},
        {3025, "Okay, here I go.."}
    };

    #endregion

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
        if (lastLineID == 3008 || lastLineID == 3013 || lastLineID == 3015 || lastLineID == 3017)
        {
            DialogueMenu.AddToDialogueOptions(3004);
        }

        if (lastLineID == 3005 || lastLineID == 3013 || lastLineID == 3015 || lastLineID == 3017)
        {
            DialogueMenu.AddToDialogueOptions(3006);
        }

        if ((DialogueManager.IsDialoguePassed(3004) || DialogueManager.IsDialoguePassed(3006)) &&
            (lastLineID == 3005 || lastLineID == 3008 || lastLineID == 3015 || lastLineID == 3017))
        {
            DialogueMenu.AddToDialogueOptions(3009);
        }

        if ((DialogueManager.IsDialoguePassed(3004) || DialogueManager.IsDialoguePassed(3006) || DialogueManager.IsDialoguePassed(3009)) &&
            (lastLineID == 3005 || lastLineID == 3008 || lastLineID == 3013 || lastLineID == 3017))
        {
            DialogueMenu.AddToDialogueOptions(3014);
        }

        if (DialogueManager.IsDialoguePassed(3014) && (lastLineID == 3005 || lastLineID == 3008 || lastLineID == 3013 || lastLineID == 3015 || lastLineID == 3017))
        {
            DialogueMenu.AddToDialogueOptions(3016);
        }

        if (lastLineID == 3005 || lastLineID == 3008 || lastLineID == 3013 || lastLineID == 3015 || lastLineID == 3017)
        {
            DialogueMenu.AddToDialogueOptions(3018);
        }

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

        Animator emmonAnimator = GameManager.Player.GetComponent<Animator>();

        switch (dialogueSituation)
        {
            case 1: //SITUATION 1
                Sentinel.Instance.HoldItThere();
                break;
            case 2: //SITUATION 2
                DialogueMenu.AddToDialogueOptions(3004);
                DialogueMenu.AddToDialogueOptions(3006);
                DialogueMenu.AddToDialogueOptions(3018);
                DialogueMenu.FindDialogueOptionText();
                break;
            case 3: //SITUATION 3  //player has a roughneck shot
                PassSentinelDialogue();
                break;
            case 4: //SITUATION 4   //we finished talking
                break;
            case 999:
                DialogueMenu.FindDialogueOptionText();
                break;
            default: //in all other dialogue options
                DialogueMenu.FindDialogueOptionText();
                Debug.LogError("I don't know this dialogue situation: Situation " + dialogueSituation);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 3001)   // hold it there
        {
            AddToDialogue(3001);
            AddToDialogue(3002);
            AddToDialogue(3003);

            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 3004)
        {
            DialoguePlayback.DeleteLineID = 3004;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(3005);
        }

        if (dialogueOptionID == 3006)
        {
            DialoguePlayback.DeleteLineID = 3006;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(3007);
            AddToDialogue(3008);
        }

        if (dialogueOptionID == 3009)
        {
            DialoguePlayback.DeleteLineID = 3009;

            AddToDialogue(dialogueOptionID);
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

    public void HoldItThere()
    {
        CharacterControllerLogic.Instance.GoToTalkingState();

        SentinelBlocker.IsBlocking = true;

        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.NPCDialogue;
        GameManager.NPCs[Character.Sentinel].GetComponent<Animator>().SetBool("DialogueState", true);

        DialoguePlayback.NPC = Character.Sentinel;
        Sentinel.CharacterSituation = 1;

        DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(3001); 

        WorldEvents.EmmonWasBlockedBySentinel = true;
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

        if (UIDrawer.IsDraggingItem && UIDrawer.DraggingItem.IType == Item.ItemType.RoughneckShot)    // we are holding the item
        {
            Debug.Log(UIDrawer.DraggingItem.IType);
        }
    }
}
