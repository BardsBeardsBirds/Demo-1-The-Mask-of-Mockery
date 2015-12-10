using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroMode
{
    public static SpokenLine CurrentSpokenLine;

    public static List<int> CurrentTextIDs = new List<int>();

    public void StartIntro()
    {
        GameManager.Instance.GameStateToIntro();

        StartIntroText();
    }

    public void StartIntroText()
    {
        CharacterControllerLogic.Instance.GoToTalkingState();

        DialoguePlayback.Instance.PlaybackIntro();
    }

    public IEnumerator IntroTextRoutine()
    {
        AddLines();
        DialogueManager.ThisDialogueType = DialogueType.Intro;

        //ThirdPersonCamera.Instance.CameraToIntroPosition(GameManager.IntroDialogue[CurrentTextIDs[0]]);


        for (int i = 0; i < CurrentTextIDs.Count; i++)
        {
            CurrentSpokenLine = GameManager.IntroDialogue[CurrentTextIDs[i]];

            DialoguePlayback.Instance.SetCurrentDialogueLine(CurrentSpokenLine.Text);

            ThirdPersonCamera.Instance.IntroDialoguePosition.GetComponent<DialogueCamera>().FindAngle(ThirdPersonCamera.Instance.MyCamera, CurrentSpokenLine);

            DialoguePlayback.Instance.ShowDialogueLines();

            string audioFile = "IntroOutro/" + CurrentSpokenLine.ID;
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            // at the end
            if (i + 1 == CurrentTextIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                ClearTextList();
            }

            int timerLength = (int)IntroTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }
    }

    public static void FinishIntro()
    {
        GameManager.Instance.GameStateToRunning();
    }

    private void AddLines()
    {
        CurrentTextIDs.Add(4000);
        CurrentTextIDs.Add(4001);
        CurrentTextIDs.Add(4002);
        CurrentTextIDs.Add(4003);
        CurrentTextIDs.Add(4004);
        CurrentTextIDs.Add(4005);
    }

    private static void ClearTextList()
    {
        CurrentTextIDs.Clear();
    }
}
