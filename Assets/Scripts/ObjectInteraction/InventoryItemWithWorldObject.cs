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

    int[] randomNos = new int[] { 9001, 9002, 9003 };

    public static Dictionary<int, string> CombineItemLines = new Dictionary<int, string>()
    {
        {9001, "No."},
        {9002, "No."},
        {9003, "That is impossible."},
    };

    public void CombineItems(Item inventoryItem, ObjectsInLevel worldObject)
    {
        Debug.Log("try to use " + inventoryItem.ItemName + " with " + worldObject);
        DialoguePlayback.Instance.PlaybackCombineItemsWithWorld(inventoryItem, worldObject);
    }

    public bool CombineItems(Item inventoryItem, Item subjectedItem)
    {
        _canMakeCombination = false;
        Debug.Log("try to use " + inventoryItem.ItemName + " with " + subjectedItem.ItemName);
        DialoguePlayback.Instance.PlaybackCombineItemsWithWorld(inventoryItem, subjectedItem);

        return _canMakeCombination;
    }

    public IEnumerator CombineItemRoutine(Item inventoryItem, ObjectsInLevel worldObject)    //inventory items with world
    {
        FindLines(inventoryItem, worldObject);
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
                    //if(subjectedItem.IType == Item.ItemType.MaskOfMockery)
                    //{
                    //    _canMakeCombination = true;
                    //    CurrentDialogueIDs.Add(9003);
                    //    break;
                    //}
                    CurrentDialogueIDs.Add(randomNo);

                }
                break;
            case Item.ItemType.MaskOfMockery:
                {
                    //if (subjectedItem.IType == Item.ItemType.Carrot)
                    //{
                    //    _canMakeCombination = true;
                    //    CurrentDialogueIDs.Add(9002);
                    //    break;
                    //}
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
        else if (id == 9003)  // that is impossible
            id = 2042;
        return id;
    }

    public int RandomNo()
    {
        int random = UnityEngine.Random.Range(0, randomNos.Length);
        Debug.Log("returning randon " + random);
        return randomNos[random];
    }
}
