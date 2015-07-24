using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;
    public bool DialogueIsPlaying = false;
    private DialogueTimer _dialogueTimer;
    private ObjectInteractionTimer _objectInteractionTimer;
    private IntroTimer _introTimer;

    public void Awake()
    {
        Instance = this;
        _dialogueTimer = new DialogueTimer();
        _introTimer = new IntroTimer();
        _objectInteractionTimer = new ObjectInteractionTimer();
    }

    public void Update()
    {
        if (DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueManager.DialogueType.NPCDialogue || DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueManager.DialogueType.NPCDialogue)
            _dialogueTimer.Update();
        else if (DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueManager.DialogueType.ObjectInteraction || DialogueIsPlaying && DialogueManager.ThisDialogueType == DialogueManager.DialogueType.InventoryCommentary)
        {
            _objectInteractionTimer.Update();
        }
        else if (DialogueManager.ThisDialogueType == DialogueManager.DialogueType.Intro)
            _introTimer.Update();
    }

    public void PlayDialogueTimer(float dialogueLength)
    {
        DialogueManager.DialogueType dialogueType = DialogueManager.ThisDialogueType;
       // Debug.Log(dialogueType + "length " + dialogueLength);
        switch (dialogueType)
        {
            case DialogueManager.DialogueType.NPCDialogue:
                _dialogueTimer.SetDialogueTimesLength(dialogueLength);//Made the dialogues shorter faster quicker sneller hier!!!!
                break;
            case DialogueManager.DialogueType.ObjectInteraction:
                _objectInteractionTimer.SetDialogueTimerLength(dialogueLength);
                break;
            case DialogueManager.DialogueType.InventoryCommentary:
                _objectInteractionTimer.SetDialogueTimerLength(dialogueLength);
                break;
            case DialogueManager.DialogueType.Intro:
                _introTimer.SetDialogueTimerLength(dialogueLength);
                break;
            default:
                break;
        }

        DialogueIsPlaying = true;
    }

    public void CreateRotator(Transform from, Transform target, float speed, float timerLength)
    {
        GameObject rotatorGO = new GameObject();
        RotateTowards rotateTowards = rotatorGO.AddComponent<RotateTowards>();
        rotateTowards.From = from;
        rotateTowards.Target = target;
        rotateTowards.Speed = speed;
        rotateTowards.Timer = timerLength;
    }

    public static IEnumerator WaitUntilEndOfClip(float clipLength)
    {
        yield return new WaitForSeconds((float)clipLength);
    }
}