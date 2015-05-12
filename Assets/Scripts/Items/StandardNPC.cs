using System;
using System.Collections.Generic;
using UnityEngine;


public class StandardNPC : MonoBehaviour
{
    public static int CharacterSituation = 1;
    public static StandardNPC Instance;
    public SphereCollider ThisCollider;

    public Animator Animator;

    #region NPCTalkingIDs
    public static List<int> NPCTalkingIDs = new List<int>()
    {
    };
    #endregion NPCTalkingIDs

    #region DialogueOptions
    public static Dictionary<int, string> DialogueOptions = new Dictionary<int, string>() 
    {
    };
    #endregion

    #region SpeakingLines
    public static Dictionary<int, string> SpeakingLines = new Dictionary<int, string>() 
    { 
    };
    #endregion

    void Start()
    {
        Instance = this;
        ThisCollider = GetComponent<SphereCollider>();
        ThisCollider.isTrigger = true;
    }

    //public void OnTriggerEnter(Collider other)
    //{

    //}

    public void StartDialogue()
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.NPCDialogue;
    }

    public void OnTriggerExit(Collider other)
    {
        DialogueManager.EndDialogueState(DialogueManager.CurrentDialogueNPC);
    }

    public void DialogueLineNumberToSituation(int lastLineID) 
    {
        int characterSituation = CharacterSituation;
    }

    public void FindDialogueSituation(int dialogueSituation)
    {
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
    }

    private static void AddToDialogue(int dialogueID)
    {
        DialoguePlayback.AddToDialogue(dialogueID);
    }
}

