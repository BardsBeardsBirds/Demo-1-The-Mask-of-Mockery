using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueTimer
{
    public static DialogueTimer Instance;
    public static float AudioClipLength = 0f;
    public static int IDlast;

    private float _timer = 0;
    

    public void Start()
    {
        AudioClipLength = 0f;
    }

    public void Awake()
    {
        Instance = this;
    }

    public void SetDialogueTimesLength(float timerLength)
    {
        AudioClipLength = timerLength;
        _timer = timerLength;
    }

    public void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
          //  Debug.Log("Timer " + _timer);

            if (_timer <= 0)
            {
                if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.TalkingLastLine)
                {
                    Debug.Log("exit the dialogue");

                    TimeManager.Instance.DialogueIsPlaying = false;

                    DialogueManager.EndDialogueState(DialogueManager.CurrentDialogueNPC);
                    if (WorldEvents.MissionAccomplished)
                    {
                        EndGameManager endGameManager = new EndGameManager();
                        endGameManager.EndingSequence();

                    }
                }
                else
                {
                    if (DialoguePlayback.LastLineOfTheBlock)
                    {
                        DialoguePlayback.DialogueNumberToSituation(IDlast);

                        Debug.Log("to another situation");

                        TimeManager.Instance.DialogueIsPlaying = false;
                        DialoguePlayback.Instance.HideDialogueLines();
                        DialogueManager.NPCToListeningState(DialogueManager.CurrentDialogueNPC);
                        DialogueMenu.ShowDialogueOptions();
                    }
                }
            }
        }       
    }
}