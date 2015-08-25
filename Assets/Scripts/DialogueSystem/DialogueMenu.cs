using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DialogueMenu : MonoBehaviour
{
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

        if (!DialogueManager.IsDialoguePassed(dialogueOptionID))
        {
            DialogueMenu.CurrentDialogueOptionsID.Add(dialogueOptionID);
            Debug.Log("Adding option: " + dialogueOptionID + ". In the list are " + DialogueMenu.CurrentDialogueOptionsID.Count);
        }
    }

    public static void FindDialogueOptionText()
    {
        for (int i = 0; i < CurrentDialogueOptionsID.Count; i++)
        {
            CurrentDialogueOptions[i] = SpokenLineLoader.Instance.GetLine(CurrentDialogueOptionsID[i]);
        }
    }

    public static void ClearDialogueOptionList()
    {
        CurrentDialogueOptionsID.Clear();
    }
}

