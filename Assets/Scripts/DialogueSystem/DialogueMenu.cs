using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueMenu : MonoBehaviour
{
    /// <summary>
    /// To do: changing DialogueOptions into their own object class. This is faster than working with strings.
    /// 
    /// To do: putting all the text in spread sheet instead of in the c# scripts
    /// </summary>
    public static int NumberOfOptions = 4;

    public static string[] CurrentDialogueOptions = new string[]
    {
        "option1",
        "option2",
        "option3",
        "option4",
        "option5",
    };

    public static List<int> CurrentDialogueOptionsID = new List<int>();

    public static void ShowDialogueOptions()
    {
        int numberOfOptions = CurrentDialogueOptionsID.Count;

        for (int i = 0; i < numberOfOptions; i++)
        {
            string goName = "DialogueOption" + (i + 1);
            GameObject dialogueOption = GameObject.Find(goName);
            dialogueOption.GetComponent<Image>().enabled = true;
            dialogueOption.GetComponent<Button>().enabled = true;
            Text Optiontext = dialogueOption.GetComponentInChildren<Text>();
            Optiontext.text = CurrentDialogueOptions[i];
        }
    }

    public static void HideDialogueOptions()
    {
        for (int i = 0; i < 5; i++)
        {
            string goName = "DialogueOption" + (i + 1);
            GameObject dialogueOption = GameObject.Find(goName);
            dialogueOption.GetComponent<Image>().enabled = false;
            dialogueOption.GetComponent<Button>().enabled = false;
            Text Optiontext = dialogueOption.GetComponentInChildren<Text>();
            Optiontext.text = "";
        }
    }

    public static void AddToDialogueOptions(int dialogueOptionID)
    {
        Debug.Log("Requested option: " + dialogueOptionID + ". In the list are " + DialogueMenu.CurrentDialogueOptionsID.Count);

        switch (DialoguePlayback.NPC)
        {
            case NPCEnum.NPCs.AyTheTearCollector:
                if (AyTheTearCollector.DialogueOptions[dialogueOptionID] != "")
                {
                    DialogueMenu.CurrentDialogueOptionsID.Add(dialogueOptionID);
                    Debug.Log("Adding option: " + dialogueOptionID + ". In the list are " + DialogueMenu.CurrentDialogueOptionsID.Count);
                }
                break;
            case NPCEnum.NPCs.BennyTwospoons:
                if (BennyTwospoons.DialogueOptions[dialogueOptionID] != "")
                {
                    DialogueMenu.CurrentDialogueOptionsID.Add(dialogueOptionID);
                    Debug.Log("Adding option: " + dialogueOptionID + ". In the list are " + DialogueMenu.CurrentDialogueOptionsID.Count);
                }
                break;
            case NPCEnum.NPCs.Sentinel:
                if (Sentinel.DialogueOptions[dialogueOptionID] != "")
                {
                    DialogueMenu.CurrentDialogueOptionsID.Add(dialogueOptionID);
                    Debug.Log("Adding option: " + dialogueOptionID + ". In the list are " + DialogueMenu.CurrentDialogueOptionsID.Count);
                }
                break;
            default: //in all other dialogue options
                Debug.LogError("I don't know this dialogue situation: Situation " + DialoguePlayback.NPC);
                break;
        }
    }

    public static void FindDialogueOptionText()
    {
        switch (DialoguePlayback.NPC)
        {
            case NPCEnum.NPCs.AyTheTearCollector:
                for (int i = 0; i < CurrentDialogueOptionsID.Count; i++)
                {
                    CurrentDialogueOptions[i] = AyTheTearCollector.DialogueOptions[CurrentDialogueOptionsID[i]];
                }
                break;
            case NPCEnum.NPCs.BennyTwospoons:
                for (int i = 0; i < CurrentDialogueOptionsID.Count; i++)
                {
                    CurrentDialogueOptions[i] = BennyTwospoons.DialogueOptions[CurrentDialogueOptionsID[i]];
                }
                break;
            case NPCEnum.NPCs.Sentinel:
                for (int i = 0; i < CurrentDialogueOptionsID.Count; i++)
                {
                    CurrentDialogueOptions[i] = Sentinel.DialogueOptions[CurrentDialogueOptionsID[i]];
                }
                break;  
            default: //in all other dialogue options
                Debug.LogError("I don't know this dialogue situation: Situation " + DialoguePlayback.NPC);
                break;
        }
    }

    public static void ClearDialogueOptionList()
    {
        CurrentDialogueOptionsID.Clear();
    }
}

