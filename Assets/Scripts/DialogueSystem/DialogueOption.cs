using System;
using UnityEngine;


public class DialogueOption : MonoBehaviour
{
    DialogueOption Instance;

    public void Awake()
    {
        Instance = this;
    }
    public void ChooseDialogueOption()
    {
        string lastCharacter = Instance.gameObject.name.Substring(Instance.gameObject.name.Length - 1, 1);
        Debug.LogWarning("we chose option number " + lastCharacter);
        int i = Convert.ToInt32(lastCharacter);
        DialoguePlayback.Instance.PlaybackDialogue(DialogueMenu.CurrentDialogueOptionsID[i - 1]);   //the text dispayed
    }
}

