using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialoguePlayback : MonoBehaviour
{
    public static Character NPC;
    public static DialoguePlayback Instance;

    public static bool EndingDialogue = false;
    public static bool LastLineOfTheBlock = false;
    public static int DeleteLineID = 0;
    public static int LastLineID = 0;
    public static int CurrentLineID = 0;

    public static List<int> CurrentDialogueIDs = new List<int>();

    private static string _currentDialogueLine;

    private List<char> _autoWriteChars = new List<char>();
    
    public void Awake()
    {
        _currentDialogueLine = "";
        Instance = this;
    }

    public void PlaybackDialogue(int dialogueOptionID)
    {
        DialoguePlayback.TriggerDialogue(dialogueOptionID); //starts loading all the lines
            Debug.Log("We chose option id " + dialogueOptionID + ". The last lineID was: " + DialoguePlayback.LastLineID);

        StartCoroutine(DialogueRoutine());

        DialogueMenu.HideDialogueOptions();
        ShowDialogueLines();
    }

    public void PlaybackDialogueWithoutOptions(int dialogueOptionID)
    {
        DialoguePlayback.TriggerDialogue(dialogueOptionID); //starts loading all the lines

        StartCoroutine(DialogueRoutine());

        ShowDialogueLines();

    }

    public void SetCurrentDialogueLine(string currentDialogueLine)
    {
        _currentDialogueLine = currentDialogueLine;

        Text lineText = GameManager.Instance.UICanvas.DialogueLineImage.GetComponentInChildren<Text>();
        lineText.text = "";
        lineText.enabled = true;
        _autoWriteChars.Clear();

        StartCoroutine(AutoType(lineText));
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        Debug.LogWarning("Laten we deze dialoog spelen: " + dialogueOptionID);

        if (NPC == Character.Ay)
            AyTheTearCollector.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.Benny)
            BennyTwospoons.TriggerDialogue(dialogueOptionID);
        else if (NPC == Character.Sentinel)
            Sentinel.TriggerDialogue(dialogueOptionID);
    }

    public static IEnumerator DialogueRoutine()
    {
        for (int i = 0; i < DialoguePlayback.CurrentDialogueIDs.Count; i++)
        {
            var id = DialoguePlayback.CurrentDialogueIDs[i];

            LastLineOfTheBlock = false;

            SpokenLine spokenLine = GameManager.CharacterDialogueLists[NPC][id];

            SetTextColour(id);

            Instance.SetCurrentDialogueLine(spokenLine.Text);

            CurrentLineID = id;

            Debug.Log("currently going over : " + GameManager.NPCs[NPC].gameObject.name + "/" + id);

            string audioFile = GameManager.NPCs[NPC].gameObject.name + "/" + id;
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            //animation
            SetTalkingListening(id);

            if (i + 1 == DialoguePlayback.CurrentDialogueIDs.Count)
            {
                LastLineOfTheBlock = true;
                DialoguePlayback.LastLineID = id;
                DialoguePlayback.ClearDialogueList();
                DialogueMenu.ClearDialogueOptionList();
                Debug.LogWarning("last line! " + id);
                DialogueTimer.ChosenOptionID = id;

                if (EndingDialogue)
                {
                    CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                    Debug.LogWarning("BEINDIG" + CharacterControllerLogic.Instance.State);
                    EndingDialogue = false;

                    if (id == 3003) //The Sentinel makes the hero turn back
                    {
                        TimeManager.Instance.CreateRotator(GameManager.Player.transform, GameObject.Find("Pushed Back Target").transform, 50f, 3f);

                        Sentinel.PushBack = true;
                    }
                }
            }
            float timerLength = (float)DialogueTimer.AudioClipLength;

            yield return new WaitForSeconds((float)timerLength);  
        }
    }

    public void ShowDialogueLines()
    {
        Text lineText = GameManager.Instance.UICanvas.DialogueLineImage.GetComponentInChildren<Text>();
        lineText.enabled = true;
    }

    public void HideDialogueLines()
    {
        Text lineText = GameManager.Instance.UICanvas.DialogueLineImage.GetComponentInChildren<Text>();
        lineText.text = "";
        lineText.enabled = false;
    }

    private static void SetTextColour(int id)
    {
        Text lineText = GameManager.Instance.UICanvas.DialogueLineImage.GetComponentInChildren<Text>();
        SpokenLine spokenLine = GameManager.CharacterDialogueLists[NPC][id];

        if (spokenLine.Speaker == NPC)
        {
            switch (NPC)
            {
                case Character.Ay:
                    lineText.color = new Color(1f, .75f, .62f);
                    break;
                case Character.Benny:
                    lineText.color = new Color(.24f, .64f, .60f);
                    break;
                case Character.Sentinel:
                    lineText.color = new Color(.67f, .829f, .96f);
                    break;
                default:
                    break;
            }
        }
        else
            lineText.color = new Color(.95f, .95f, .95f);
    }

    private static void SetTalkingListening(int id)
    {
        SpokenLine spokenLine = GameManager.CharacterDialogueLists[NPC][id];

        if (spokenLine.Speaker == NPC)
        {
            GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Listening", false);
            GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Talking", true);
        }
        else
        {
            GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Listening", true);
            GameManager.NPCs[NPC].GetComponent<Animator>().SetBool("Talking", false);
        }
    }

    public static void AddToDialogue(int dialogueID)
    {
        CurrentDialogueIDs.Add(dialogueID);
        DeleteLine(DeleteLineID); 
    }

    public static void DeleteLine(int deleteLineID)
    {
        DialogueManager.AddToPassedDialogueLines(deleteLineID);
    }

    public static void DialogueNumberToSituation(int id)
    {
        switch (NPC)
        {
            case Character.Ay:
                    AyTheTearCollector.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.Benny:
                    BennyTwospoons.Instance.DialogueLineNumberToSituation(id);
                break;
            case Character.Sentinel:
                    Sentinel.Instance.DialogueLineNumberToSituation(id);
                break;

            default: //in all other dialogue options
                Debug.LogError("I don't know this dialogue situation: Situation " + NPC);
                break;
        }
    }

    public static void ClearDialogueList()
    {
        CurrentDialogueIDs.Clear();
    }

    #region ObjectCommentary
    public void PlaybackCommentary(DialogueType dialogueType, ObjectsInLevel objectInLevel)
    {
        Debug.LogWarning(dialogueType + " " + objectInLevel);
        StartCoroutine(ObjectCommentary.CommentaryRoutine(dialogueType, objectInLevel));
    }

    public void PlaybackCommentary(DialogueType dialogueType, Item inventoryItem)
    {
        StartCoroutine(InventoryCommentary.InventoryCommentaryRoutine(dialogueType, inventoryItem));
    }

    public void PlaybackCommentary()
    {
        MyConsole.WriteToConsole("Lets get closer");
        StartCoroutine(ObjectCommentary.LetsGetCloserRoutine());
    }

    public void PlaybackCombineItemsWithWorld(Item inventoryItem, ObjectsInLevel worldObject)
    {
        StartCoroutine(GameManager.Instance.IIventoryItemWithObject.CombineItemRoutine(inventoryItem, worldObject));
    }

    public void PlaybackCombineItemsInventory(Item inventoryItem, Item subjectedInventoryItem)
    {
        StartCoroutine(GameManager.Instance.IIventoryItemWithObject.CombineItemRoutine(inventoryItem, subjectedInventoryItem));
    }

    IEnumerator AutoType(Text lineText)
    {
        DialogueTimer.LineFinished = false;

        foreach (char letter in _currentDialogueLine.ToCharArray())
        {
            _autoWriteChars.Add(letter);
        }

        for (int i = 0; i < _autoWriteChars.Count; i++)
        {
            if (DialogueTimer.LineFinished)
                break;

            lineText.text += _autoWriteChars[i];
            yield return new WaitForSeconds(.015f);       
        }
    }

    #endregion

    #region Intro Outro

    public void PlaybackIntro()
    {
        IntroMode introManager = new IntroMode();
        StartCoroutine(introManager.IntroTextRoutine());
    }
    #endregion
}