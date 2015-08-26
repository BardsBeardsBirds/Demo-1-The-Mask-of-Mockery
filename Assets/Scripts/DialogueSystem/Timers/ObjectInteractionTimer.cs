using UnityEngine;
using System.Collections;

public class ObjectInteractionTimer
{
    public static float AudioClipLength = 0f;

    private float _timer = 0;

    public void Start()
    {
        AudioClipLength = 0f;
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
            //Debug.Log(_timer);
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.TalkingLastLine)
                {
                    TimeManager.Instance.DialogueIsPlaying = false;
                    DialoguePlayback.Instance.HideDialogueLines();
                    DoSomethingAtEnd(ObjectCommentary.CurrentID);
                    DialogueManager.ThisDialogueType = DialogueType.None;
                    CharacterControllerLogic.Instance.GoToIdleState();

                    //if(ObjectCommentary.ChangeIndex != 0)
                    //{
                    //    ChangeLineInDictionary();
                    //}
                }
            }
        }
    }

    private static void DoSomethingAtEnd(int id)
    {
        if(id == 2054) //pick up the mask of Mockery
        {
            InGameObjectManager.Instance.TurnOffObject(GameObject.Find("MaskOfMockery"));
        }
    }

    //private void ChangeLineInDictionary()
    //{
    //    var firstDigit = ObjectCommentary.ChangeIndex.ToString().Substring(0, 1);
    //    if (firstDigit == "1")
    //        ObjectCommentary.InvestigationLines[ObjectCommentary.ChangeIndex] = ObjectCommentary.ChangeLine;
    //    else if (firstDigit == "2")
    //        ObjectCommentary.InteractionLines[ObjectCommentary.ChangeIndex] = ObjectCommentary.ChangeLine;

    //    ObjectCommentary.ChangeIndex = 0;
    //    ObjectCommentary.ChangeLine = "";
    //}
}

