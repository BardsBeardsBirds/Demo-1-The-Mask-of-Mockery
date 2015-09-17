using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueTimer
{
    public static DialogueTimer Instance;
    public static float AudioClipLength = 0f;
    public static int ChosenOptionID;

    public static bool LineFinished = false;

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
        LineFinished = false;
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
                        DialoguePlayback.DialogueNumberToSituation(ChosenOptionID);

                        Debug.Log("to another situation");

                        TimeManager.Instance.DialogueIsPlaying = false;
                        DialoguePlayback.Instance.HideDialogueLines();
                        DialogueManager.NPCToListeningState(DialogueManager.CurrentDialogueNPC);
                        DialogueMenu.ShowDialogueOptions();
                    }
                }
         //       Debug.Log("Do we do something at the end?" + DialoguePlayback.CurrentLineID);

                DoSomethingAtEnd(DialoguePlayback.CurrentLineID);

                LineFinished = true;
            }
        }       
    }

    private static void DoSomethingAtEnd(int id)
    {
        if (id == 3025) //drink the roughneck shot after this one
        {
            for (int i = 0; i < GameManager.Instance.MyInventory.Items.Count; i++)
            {
                Debug.Log(GameManager.Instance.MyInventory.Items[i].IType);
                if (GameManager.Instance.MyInventory.Items[i].IType == ItemType.RoughneckShot)
                {
                    GameManager.Instance.MyInventory.MakeSlotEmpty(i);
                    break;
                }
            }
        }
    }
}