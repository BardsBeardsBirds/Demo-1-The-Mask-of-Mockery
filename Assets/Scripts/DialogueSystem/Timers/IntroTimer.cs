using UnityEngine;
using System.Collections;

public class IntroTimer
{
    private float _timer = 0;
    public static float AudioClipLength = 0f;


    public void Start()
    {
        AudioClipLength = 0f;
    }
    public void Awake()
    {
//        Instance = this;
    }

    public void SetDialogueTimerLength(float timerLength)
    {
        AudioClipLength = timerLength;
        _timer = timerLength;
    }

    public void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {

                if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.TalkingLastLine)
                {

                    DialoguePlayback.Instance.HideDialogueLines();
                    TimeManager.Instance.DialogueIsPlaying = false;

                    Debug.Log("END TALKING STATE from intro");
                    CharacterControllerLogic.Instance.EndTalkingState();
                    DialogueManager.ThisDialogueType = DialogueType.None;

                    GameManager.Instance.UICanvas.IntroScreen.GetComponent<IntroScreen>().PanelOpen = true; // open panel

                    IntroMode.FinishIntro();
                    Debug.Log("This is the end of the intro timer " + CharacterControllerLogic.Instance.State + " " + GameManager.GamePlayingMode);
                }
            }

        }
    }
}

