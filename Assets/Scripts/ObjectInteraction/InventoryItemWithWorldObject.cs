using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemWithWorldObject
{
    public static int LastLineID = 0;
    public static int CurrentID = 0;

    private static bool _canMakeCombination = false;

    public static List<int> CurrentDialogueIDs = new List<int>();

    int[] randomNos = new int[] { 9001, 9002, 9003, 9004, 9005 };

    public static Dictionary<int, string> CombineItemLines = new Dictionary<int, string>()
    {
        {9001, "No."},
        {9002, "No."},
        {9003, "No."},
        {9004, "That is impossible."},

        {9005, "I can't do that."},

        
        {9008, "This rabbit doesn't eat carrots."},
        {9009, "Would you like a carrot?"},
        {9010, "Are you trying to bribe me?"},
        {9011, "Never mind."},

        {9013, "I don't think he would like that."},
        {9014, "I rather keep this for myself."},
        {9015, "He doesn't deserve that!"},

       // {9016, "Okay, here I go.."},

    };

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
        if (inventoryItem.IType == Item.ItemType.RoughneckShot)
        {
            if (worldObject == ObjectsInLevel.Sentinel)
            {
                _canMakeCombination = true;
                //GameManager.Instance.MyInventory.EndDragging(UIDrawer.DraggingFromSlotNo);
        //        IInventory.EndDragging(SlotNumber);
            }
        }
        else if (inventoryItem.IType == Item.ItemType.MaskOfMockery)
        {
            if (worldObject == ObjectsInLevel.AyTheTearCollector || worldObject == ObjectsInLevel.BennyTwospoons)
                _canMakeCombination = true;
        }
        else if(inventoryItem.IType == Item.ItemType.Carrot)
        {
            if(worldObject == ObjectsInLevel.Rabbit)
            {
                _canMakeCombination = true;
            }
        }

        return _canMakeCombination;
    }

    public bool CombineItems(Item inventoryItem, Item subjectedItem)            //inventory items with other inventory items
    {
        _canMakeCombination = false;
        Debug.Log("try to use " + inventoryItem.ItemName + " with " + subjectedItem.ItemName);
        DialoguePlayback.Instance.PlaybackCombineItemsWithWorld(inventoryItem, subjectedItem);
        TryMakeComination(inventoryItem, subjectedItem);

        return _canMakeCombination;
    }

    private bool TryMakeComination(Item inventoryItem, Item subjectedItem)
    {
        return _canMakeCombination;
    }

    public IEnumerator CombineItemRoutine(Item inventoryItem, ObjectsInLevel worldObject)    //inventory items with world
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.InventoryCommentary;    //the tiype of dialogue will be overwritten later if the combination triggers the start of an npc dialogue
        FindLines(inventoryItem, worldObject);
        CharacterControllerLogic.Instance.GoToTalkingState();

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;

            DialoguePlayback.SetCurrentDialogueLine(CombineItemLines[id]);

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
        FindLines(inventoryItem, subjectedItem);
        CharacterControllerLogic.Instance.GoToTalkingState();
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.InventoryCommentary;

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;

            DialoguePlayback.SetCurrentDialogueLine(CombineItemLines[id]);

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

    private void FindLines(Item inventoryItem, ObjectsInLevel worldObject) // inventory with world
    {
        int randomNo = RandomNo();

        switch (inventoryItem.IType)
        {
            case Item.ItemType.RoughneckShot:
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
            case Item.ItemType.Carrot:
                {
                    if (worldObject == ObjectsInLevel.Rabbit)
                        CurrentDialogueIDs.Add(9008);
                    else if(worldObject == ObjectsInLevel.Sentinel)
                    {
                        CurrentDialogueIDs.Add(9009);
                        CurrentDialogueIDs.Add(9010);
                        CurrentDialogueIDs.Add(9011);
                    }
                    else if(worldObject == ObjectsInLevel.BennyTwospoons || worldObject == ObjectsInLevel.AyTheTearCollector)
                        CurrentDialogueIDs.Add(9013);
                    else
                        CurrentDialogueIDs.Add(randomNo);
                }
                break;
            case Item.ItemType.MaskOfMockery:
                {
                    if (worldObject == ObjectsInLevel.Sentinel)
                        CurrentDialogueIDs.Add(9015);
                    else if (worldObject == ObjectsInLevel.AyTheTearCollector)
                    {
                        AyTheTearCollector.Instance.StartDialogue();
                    }
                    else if (worldObject == ObjectsInLevel.BennyTwospoons)
                    {
                        BennyTwospoons.Instance.StartDialogue();

                    }
                    else
                        CurrentDialogueIDs.Add(randomNo);
                }
                break;
            default:
                break;
        }
    }

    private void FindLines(Item inventoryItem, Item subjectedItem)  //inventory with inventory
    {
        int randomNo = RandomNo();

        switch (inventoryItem.IType)
        {
            case Item.ItemType.RoughneckShot:
                {
                    CurrentDialogueIDs.Add(randomNo);
                }
                break;
            case Item.ItemType.Carrot:
                {
                    CurrentDialogueIDs.Add(randomNo);
                }
                break;
            case Item.ItemType.MaskOfMockery:
                {
                    CurrentDialogueIDs.Add(randomNo);
                }
                break;
            default:
                break;
        }
    }

    private void ClearDialogueList()
    {
        CurrentDialogueIDs.Clear();
    }

    public int CheckUniqueAudio(int id)
    {
        if (id == 9001)  // no
            id = 2043;
        else if (id == 9002)  // no
            id = 2049;
        else if (id == 9004)  // that is impossible
            id = 2042;
        return id;
    }

    public int RandomNo()
    {
        int random = UnityEngine.Random.Range(0, randomNos.Length);
        return randomNos[random];
    }
}
