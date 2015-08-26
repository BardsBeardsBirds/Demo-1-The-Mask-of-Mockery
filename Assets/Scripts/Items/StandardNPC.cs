using System;
using System.Collections.Generic;
using UnityEngine;


public class StandardNPC : MonoBehaviour
{
    public static int CharacterSituation = 1;
    public static StandardNPC Instance;
    public SphereCollider ThisCollider;

    public Animator Animator;

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
   //     DialogueManager.ThisDialogueType = DialogueType.;
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

