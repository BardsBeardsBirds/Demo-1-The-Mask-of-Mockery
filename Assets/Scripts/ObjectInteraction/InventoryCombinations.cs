using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCombinations
{
    public static int LastLineID = 0;
    public static int CurrentID = 0;

    private static bool _canMakeCombination = false;

    public static List<int> CurrentDialogueIDs = new List<int>();

    int[] randomNos = new int[] { 9001, 9002, 9003, 9004, 9005 };

    public bool CombineItems(Item inventoryItem, ObjectsInLevel worldObject)    //inventory items with world
    {
        _canMakeCombination = false;

        Debug.Log("try to use " + inventoryItem.ItemName + " with " + worldObject);
        DialoguePlayback.Instance.PlaybackCombineItemsWithWorld(inventoryItem, worldObject);
        _canMakeCombination = TryMakeComination(inventoryItem, worldObject);

        return _canMakeCombination;
    }

    private bool TryMakeComination(Item inventoryItem, ObjectsInLevel worldObject)  //inventory items with world
    {
        if (inventoryItem.IType == ItemType.RoughneckShot)
        {
            if (worldObject == ObjectsInLevel.Sentinel)
                _canMakeCombination = true;
        }
        else if (inventoryItem.IType == ItemType.MaskOfMockery)
        {
            if (worldObject == ObjectsInLevel.AyTheTearCollector || worldObject == ObjectsInLevel.BennyTwospoons)
                _canMakeCombination = true;
        }
        else if(inventoryItem.IType == ItemType.Carrot)
        {
            if(worldObject == ObjectsInLevel.Rabbit)
                _canMakeCombination = true;
        }
        return _canMakeCombination;
    }

    public bool CombineItems(Item inventoryItem, Item subjectedItem)            //inventory items with other inventory items
    {
        _canMakeCombination = false;
        Debug.Log("try to use " + inventoryItem.ItemName + " with " + subjectedItem.ItemName);
        DialoguePlayback.Instance.PlaybackCombineItemsInventory(inventoryItem, subjectedItem);
        TryMakeComination(inventoryItem, subjectedItem);

        return _canMakeCombination;
    }

    private bool TryMakeComination(Item inventoryItem, Item subjectedItem)
    {
        return _canMakeCombination;
    }

    public IEnumerator CombineItemRoutine(Item inventoryItem, ObjectsInLevel worldObject)    //inventory items with world
    {
        DialogueManager.ThisDialogueType = DialogueType.ItemWorldCombination;    //the tiype of dialogue will be overwritten later if the combination triggers the start of an npc dialogue
        bool isRandomNo = FindLines(inventoryItem, worldObject);
        CharacterControllerLogic.Instance.GoToTalkingState();

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;
            if (isRandomNo)
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.RandomNoDialogue[id].Text);
            }
            else
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.ItemWorldCombinationDialogue[id].Text);
            }

            DialoguePlayback.Instance.ShowDialogueLines();

            int audioId = CheckUniqueAudio(id);
            string audioFile = "ObjectInteraction/" + audioId;
            Debug.Log(audioFile);
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            if (i + 1 == CurrentDialogueIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                LastLineID = id;
                ClearDialogueList();
            }

            float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }
    }

    public IEnumerator CombineItemRoutine(Item inventoryItem, Item subjectedItem)    //inventory items with other inventory items
    {
        DialogueManager.ThisDialogueType = DialogueType.InventoryCombination;
        bool isRandomNo = FindLines(inventoryItem, subjectedItem);
        CharacterControllerLogic.Instance.GoToTalkingState();

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;

            if (isRandomNo)
            {
                Debug.Log("is random " + id);
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.RandomNoDialogue[id].Text);
            }
            else
            {
                DialoguePlayback.Instance.SetCurrentDialogueLine(GameManager.InventoryCombinationDialogue[id].Text);
            }

            DialoguePlayback.Instance.ShowDialogueLines();

            int audioId = CheckUniqueAudio(id);
            string audioFile = "ObjectInteraction/" + audioId;
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            if (i + 1 == CurrentDialogueIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                LastLineID = id;
                ClearDialogueList();
            }

            float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }   
    }

    private bool FindLines(Item inventoryItem, ObjectsInLevel worldObject) // inventory with world
    {
        bool isRandomNo = false;
        switch (inventoryItem.IType)
        {
            case ItemType.RoughneckShot:
                {
                    if (worldObject == ObjectsInLevel.Sentinel)
                    {
                        GameManager.Instance.MyInventory.EndDragging(UIDrawer.DraggingFromSlotNo);

                        WorldEvents.EmmonHasRoughneckShot = true;
                        Sentinel.Instance.StartDialogue();
                    }
                    else
                        CurrentDialogueIDs.Add(9014);
                }
                break;
            case ItemType.Carrot:
                {
                    if (worldObject == ObjectsInLevel.Rabbit)
                        CurrentDialogueIDs.Add(9008);
                    else if(worldObject == ObjectsInLevel.Sentinel)
                    {
                        CurrentDialogueIDs.Add(9009);
                        CurrentDialogueIDs.Add(9010);
                        CurrentDialogueIDs.Add(9011);
                    }
                    else if (worldObject == ObjectsInLevel.BennyTwospoons || worldObject == ObjectsInLevel.AyTheTearCollector)
                        CurrentDialogueIDs.Add(9013);
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            case ItemType.MaskOfMockery:
                {
                    if (worldObject == ObjectsInLevel.Sentinel)
                        CurrentDialogueIDs.Add(9015);
                    else if (worldObject == ObjectsInLevel.AyTheTearCollector)
                        AyTheTearCollector.Instance.StartDialogue();
                    else if (worldObject == ObjectsInLevel.BennyTwospoons)
                        BennyTwospoons.Instance.StartDialogue();
                    else
                    {
                        GetRandomNo();
                        isRandomNo = true;
                    }
                }
                break;
            default:
                break;
        }
        return isRandomNo;
    }

    private bool FindLines(Item inventoryItem, Item subjectedItem)  //inventory with inventory
    {
        bool isRandomNo = false;

        switch (inventoryItem.IType)
        {
            case ItemType.RoughneckShot:
                {
                    GetRandomNo();
                    isRandomNo = true;
                }
                break;
            case ItemType.Carrot:
                {
                    GetRandomNo();
                    isRandomNo = true;
                }
                break;
            case ItemType.MaskOfMockery:
                {
                    GetRandomNo();
                    isRandomNo = true;
                }
                break;
            default:
                break;
        }
        return isRandomNo;
    }

    private void ClearDialogueList()
    {
        CurrentDialogueIDs.Clear();
    }

    public int CheckUniqueAudio(int id)
    {
        if (id == 9001)  // no
            id = 7043;
        else if (id == 9002)  // no
            id = 7049;
        else if (id == 9004)  // that is impossible
            id = 7042;
        return id;
    }

    private void GetRandomNo()
    {
        int randomNo = RandomNo();

        DialogueManager.ThisDialogueType = DialogueType.RandomNo;
        CurrentDialogueIDs.Add(randomNo);
    }

    private int RandomNo()
    {
        int random = UnityEngine.Random.Range(0, randomNos.Length);
        return randomNos[random];
    }
}
