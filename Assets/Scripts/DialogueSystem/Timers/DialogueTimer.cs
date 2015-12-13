using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueTimer
{
    public static DialogueTimer Instance;
    public static float AudioClipLength = 0f;
    public static int ChosenOptionID;

    public static bool IsTyping;
    public static bool AudioFinished = false;

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
                }
                else
                {
                    if (DialoguePlayback.LastLineOfTheBlock)
                    {
                        DialoguePlayback.DialogueNumberToSituation(ChosenOptionID);
                        Debug.LogWarning(CharacterControllerLogic.Instance.State);
                        Debug.Log("to another situation");

                        TimeManager.Instance.DialogueIsPlaying = false;
                        DialoguePlayback.Instance.HideDialogueLines();
                        DialogueManager.EverybodyWaitForDialogueChoice(DialogueManager.CurrentDialogueNPC);
                        DialogueMenu.ShowDialogueOptions();
                    }
                }
                //       Debug.Log("Do we do something at the end?" + DialoguePlayback.CurrentLineID);
                CameraAngles.StopMovingCamera();

                DoSomethingAtEnd(DialoguePlayback.CurrentSpokenLine);
            }
        }       
    }

    private void DoSomethingAtEnd(SpokenLine spokenLine)
    {
        if(spokenLine.ID == 2108)
        {
            AddRoughneckShot();
        }
        else if (spokenLine.ID == 3022) 
        {
            EndRoughneckShotEffect();
        }
        else if (spokenLine.ID == 3025) //drink the roughneck shot after this one
        {
            DrinkRoughNeckShot();
        }
        else if (spokenLine.ID == 1093)
        {
            EndGameManager endGameManager = new EndGameManager();
            endGameManager.EndingSequence();
        }
    }

    public void DrinkRoughNeckShot()
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
        ArrangeParticleSystems.LoadRoughneckShotEffect();
    }

    public void EndRoughneckShotEffect()
    {
        ArrangeParticleSystems.DeleteRoughneckShotEffect();
    }

    public void AddRoughneckShot()
    {
        WorldEvents.EmmonHasRoughneckShot = true;
        ItemManager.AddItem(ItemType.RoughneckShot);
    }
}