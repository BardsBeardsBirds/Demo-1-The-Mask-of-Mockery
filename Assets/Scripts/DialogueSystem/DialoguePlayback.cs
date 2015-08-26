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

    public void Awake()
    {
        _currentDialogueLine = "";
        Instance = this;
    }

    public void ShowDialogueLines()
    {
        GameObject dialogueLineImage = GameManager.Instance.UICanvas.DialogueLineImage;
        dialogueLineImage.GetComponent<Image>().enabled = true;
        Text lineText = dialogueLineImage.GetComponentInChildren<Text>();
        lineText.text = _currentDialogueLine;
        lineText.enabled = true;
    }

    public void HideDialogueLines()
    {
        GameObject dialogueLineImage = GameManager.Instance.UICanvas.DialogueLineImage;
        dialogueLineImage.GetComponent<Image>().enabled = false;
        Text lineText = dialogueLineImage.GetComponentInChildren<Text>();
        lineText.text = "";
        lineText.enabled = false;
    }

    public static void SetCurrentDialogueLine(string currentDialogueLine)
    {
        _currentDialogueLine = currentDialogueLine;

        GameObject dialogueLineImage = GameManager.Instance.UICanvas.DialogueLineImage;
        Text lineText = dialogueLineImage.GetComponentInChildren<Text>();
        lineText.text = _currentDialogueLine;
    }

    //public static void ComposeDialogueList()
    //{
    //    for (int i = 0; i < CurrentDialogueIDs.Count; i++)
    //    {
    //        _currentDialogueLine = SpokenLineLoader.Instance.GetLine(CurrentDialogueIDs[i]).Text;
    //    }
    //}

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

    public void PlaybackDialogue(int dialogueOptionID)
    {
        DialoguePlayback.TriggerDialogue(dialogueOptionID); //starts loading all the lines
    //    Debug.Log("We chose option " + dialogueOption + " with option id " + dialogueOptionID + ". The last lineID was: " + DialoguePlayback.LastLineID);

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

    public static IEnumerator DialogueRoutine()
    {
     //   DialogueManager.ThisDialogueType = DialogueManager.DialogueType.NPCDialogue;

        Debug.Log(NPC);
        for (int i = 0; i < DialoguePlayback.CurrentDialogueIDs.Count; i++)
        {
            var id = DialoguePlayback.CurrentDialogueIDs[i];

            LastLineOfTheBlock = false;

            SpokenLine spokenLine = null;

            foreach (SpokenLine s in GameManager.CharacterDialogueLists[NPC])
            {
                if (s.ID == id)
                {
                    spokenLine = s;
                    break;
                }
            }

            DialoguePlayback.SetCurrentDialogueLine(spokenLine.Text);
//            DialoguePlayback.SetCurrentDialogueLine(SpokenLineLoader.Instance.GetLine(id).Text);

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
                DialogueTimer.IDlast = id;

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

    private static void SetTalkingListening(int id)
    {
        SpokenLine spokenLine = null;

        foreach (SpokenLine s in GameManager.CharacterDialogueLists[NPC])
        {
            if (s.ID == id)
            {
                spokenLine = s;
                break;
            }
        }

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

        //SpokenLine spokenLine = null;
        //switch (NPC)
        //{       
        //    case Character.Ay:
        //           //TODO: Make a GetSpokenLine(DialogueType type); in DialogueManager
        //        foreach (SpokenLine s in GameManager.AyDialogue)
        //        {
        //            if (s.ID == id)
        //            {
        //                spokenLine = s;
        //                break;
        //            }
        //        }

        //        if (spokenLine.Speaker == NPC)
        //        {
        //            AyTheTearCollector.Instance.Animator.SetBool("Listening", false);
        //            AyTheTearCollector.Instance.Animator.SetBool("Talking", true);
        //        }
        //        else
        //        {
        //            AyTheTearCollector.Instance.Animator.SetBool("Listening", true);
        //            AyTheTearCollector.Instance.Animator.SetBool("Talking", false);
        //        }
        //        break;
        //    case Character.Benny:
        //        foreach (SpokenLine s in GameManager.BennyDialogue)
        //        {
        //            if (s.ID == id)
        //            {
        //                spokenLine = s;
        //                break;
        //            }
        //        }

        //        if (spokenLine.Speaker == NPC)
        //        {
        //            BennyTwospoons.Instance.Animator.SetBool("Listening", false);
        //            BennyTwospoons.Instance.Animator.SetBool("Talking", true);
        //        }
        //        else
        //        {
        //            BennyTwospoons.Instance.Animator.SetBool("Listening", true);
        //            BennyTwospoons.Instance.Animator.SetBool("Talking", false);
        //        }
        //        break;
        //    case Character.Sentinel:
        //        foreach (SpokenLine s in GameManager.SentinelDialogue)
        //        {
        //            if (s.ID == id)
        //            {
        //                spokenLine = s;
        //                break;
        //            }
        //        }

        //        if (spokenLine.Speaker == NPC)
        //        {
        //            Sentinel.Instance.Animator.SetBool("Listening", false);
        //            Sentinel.Instance.Animator.SetBool("Talking", true);
        //        }
        //        else
        //        {
        //            Sentinel.Instance.Animator.SetBool("Listening", true);
        //            Sentinel.Instance.Animator.SetBool("Talking", false);
        //        }
        //        break;
        //    default:
        //        Debug.LogError("which npc is this?");
        //        break;
        //}
        //}
        //switch (NPC)
        //{
        //    case Character.Ay:
        //        if (AyTheTearCollector.NPCTalkingIDs.Contains(id))
        //        {
        //            AyTheTearCollector.Instance.Animator.SetBool("Listening", false);
        //            AyTheTearCollector.Instance.Animator.SetBool("Talking", true);
        //        }
        //        else
        //        {
        //            AyTheTearCollector.Instance.Animator.SetBool("Listening", true);
        //            AyTheTearCollector.Instance.Animator.SetBool("Talking", false);
        //        }
        //        break;
        //    case Character.Benny:
        //        if (BennyTwospoons.NPCTalkingIDs.Contains(id))
        //        {
        //            BennyTwospoons.Instance.Animator.SetBool("Listening", false);
        //            BennyTwospoons.Instance.Animator.SetBool("Talking", true);
        //        }
        //        else
        //        {
        //            BennyTwospoons.Instance.Animator.SetBool("Listening", true);
        //            BennyTwospoons.Instance.Animator.SetBool("Talking", false);
        //        }
        //        break;
        //    case Character.Sentinel:
        //        if (Sentinel.NPCTalkingIDs.Contains(id))
        //        {
        //            Sentinel.Instance.Animator.SetBool("Listening", false);
        //            Sentinel.Instance.Animator.SetBool("Talking", true);
        //        }
        //        else
        //        {
        //            Sentinel.Instance.Animator.SetBool("Listening", true);
        //            Sentinel.Instance.Animator.SetBool("Talking", false);
        //        }
        //        break;
        //    default:
        //        Debug.LogError("which npc is this?");
        //        break;
        //}
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

    #endregion

    #region Intro Outro

    public void PlaybackIntro()
    {
        IntroMode introManager = new IntroMode();
        StartCoroutine(introManager.IntroTextRoutine());
    }

    #endregion
}