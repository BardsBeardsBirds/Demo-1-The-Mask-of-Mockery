using UnityEngine;
using System.Collections;

public class SpokenLineLoader : MonoBehaviour
{
    public static SpokenLineLoader Instance;
    public const string path = "Xml/spokenLines"; //in resources folder

    void Start()
    {
        Instance = this; 

        SpokenLineLoader.Instance.GetAllLines(DialogueType.AyDialogue);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.BennyDialogue);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.SentinelDialogue);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.ObjectInvestigation);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.ObjectInteraction);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.InventoryInvestigation);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.InventoryInteraction);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.InventoryCombination);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.ItemWorldCombination);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.RandomNo);
        SpokenLineLoader.Instance.GetAllLines(DialogueType.Intro);
    }

    public void GetAllLines(DialogueType dialogueType)
    {
        SpokenLineContainer ic = SpokenLineContainer.Load(path);

        foreach (SpokenLine spokenLine in ic.spokenLines)
        {
            switch (dialogueType)
            {
                case DialogueType.AyDialogue:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.AyDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.BennyDialogue:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.BennyDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.SentinelDialogue:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.SentinelDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.ObjectInvestigation:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.ObjectInvestigationDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.ObjectInteraction:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.ObjectInteractionDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.InventoryInvestigation:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.InventoryInvestigationDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.InventoryInteraction:
                    if (spokenLine.DialogueType == dialogueType)
                    {
                        GameManager.InventoryInteractionDialogue.Add(spokenLine.ID, spokenLine);
                    }
                    break;
                case DialogueType.InventoryCombination:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.InventoryCombinationDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.ItemWorldCombination:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.ItemWorldCombinationDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.RandomNo:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.RandomNoDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.Intro:
                    if (spokenLine.DialogueType == dialogueType)
                        GameManager.IntroDialogue.Add(spokenLine.ID, spokenLine);
                    break;
                case DialogueType.None:
                    break;
            }
        }
    }
}
