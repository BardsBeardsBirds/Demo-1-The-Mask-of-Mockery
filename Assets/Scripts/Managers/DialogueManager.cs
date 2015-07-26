using System;
using UnityEngine;

public class DialogueManager
{
    public enum DialogueType { NPCDialogue, ObjectInteraction, InventoryCommentary, Intro, None };

    public static DialogueType ThisDialogueType = DialogueType.None;
    public static NPCEnum.NPCs CurrentDialogueNPC;

   // public static string CurrentDialoguePartner = "";

    public static void StartDialogueState(NPCEnum.NPCs NPC)
    {

        CurrentDialogueNPC = NPC;
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.NPCDialogue;

        GameManager.Instance.UICanvas.ShowDialogueOptionsUI();

        CharacterControllerLogic.Instance.GoToTalkingState();
      //  CharacterController
        TimeManager.Instance.CreateRotator(GameManager.Player.transform, GameManager.NPCs[NPC], 4, 2);
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("DialogueState", true);

        switch (NPC)
        {
            case NPCEnum.NPCs.AyTheTearCollector:
                DialoguePlayback.NPC = NPC;
       //         CurrentDialoguePartner = "Ay";
                DialogueSituationSelector.LoadAySituations();
                break;
            case NPCEnum.NPCs.BennyTwospoons:
                DialoguePlayback.NPC = NPC;
            //    DialoguePlayback.NPC = "Benny Twospoons";
            //    CurrentDialoguePartner = "Benny Twospoons";
                DialogueSituationSelector.LoadBennyTwospoonsSituations();
                break;
            case NPCEnum.NPCs.Sentinel:
                DialoguePlayback.NPC = NPC;
         //       CurrentDialoguePartner = "Sentinel";
                DialogueSituationSelector.LoadSentinelSituations();
                break;
            default:
                Debug.LogError("Who is this conversation partner?");
                break;
        }
    }

    public static void EndDialogueState(NPCEnum.NPCs NPC)
    {
        DialogueMenu.HideDialogueOptions();
        DialoguePlayback.Instance.HideDialogueLines();

        DialoguePlayback.ClearDialogueList();

        DialogueMenu.ClearDialogueOptionList();
  //      GameManager.InCutScene = false;
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.None;

        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("DialogueState", false);
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Talking", false);
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Listening", false);

        GameManager.Instance.UICanvas.HideDialogueOptionsUI();

        if (!Sentinel.PushBack)
            CharacterControllerLogic.Instance.GoToIdleState();
    }
    

    public static void NPCToListeningState(NPCEnum.NPCs NPC)
    {
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Talking", false);
        GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Listening", true);
        //switch (CurrentDialoguePartner)
        //{
        //    case "Ay":
        //AyTheTearCollector.Instance.Animator.SetBool("Talking", false);
        //AyTheTearCollector.Instance.Animator.SetBool("Listening", true);
        //        break;
        //    case "Benny Twospoons":
        //BennyTwospoons.Instance.Animator.SetBool("Talking", false);
        //BennyTwospoons.Instance.Animator.SetBool("Listening", true);
        //        break;
        //    case "Sentinel":
        //Sentinel.Instance.Animator.SetBool("Talking", false);
        //Sentinel.Instance.Animator.SetBool("Listening", true);
        //        break;
        //    default:
        //        Debug.LogError("Who is this conversation partner?");
        //        break;
        //}
    }
}
