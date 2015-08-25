using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class ObjectCommentary
{
    public static int CurrentID = 0;
    public static bool AskingLute = false;
    public static int ChangeIndex = 0;
    public static string ChangeLine = "";

    public static List<int> CurrentDialogueIDs = new List<int>();

    public static IEnumerator LetsGetCloserRoutine()
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.ObjectInteraction;

        int id = 7078;
        DialoguePlayback.SetCurrentDialogueLine(SpokenLineLoader.Instance.GetLine(id));

        DialoguePlayback.Instance.ShowDialogueLines();

        string audioFile = "ObjectInteraction/" + id;
        AudioManager.Instance.PlayDialogueAudio(audioFile);

        EndObjectCommentary();
        CharacterControllerLogic.Instance.GoToTalkingLastLineState();

        float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
        yield return new WaitForSeconds(timerLength);   
    }

    public static IEnumerator CommentaryRoutine(SpeechType speechType, ObjectsInLevel objectInLevel)
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.ObjectInteraction;

        FindLines(speechType, objectInLevel);

        for (int i = 0; i < CurrentDialogueIDs.Count; i++)
        {
            var id = CurrentDialogueIDs[i];
            CurrentID = id;

            DialoguePlayback.SetCurrentDialogueLine(SpokenLineLoader.Instance.GetLine(id));
            //if(speechType == SpeechType.Investigation)
            //    DialoguePlayback.SetCurrentDialogueLine(InvestigationLines[id]);
            //else if(speechType == SpeechType.Interaction)
            //    DialoguePlayback.SetCurrentDialogueLine(InteractionLines[id]);

            DialoguePlayback.Instance.ShowDialogueLines();


            int audioId = CheckUniqueAudio(id);
            string audioFile = "ObjectInteraction/" + audioId;
            AudioManager.Instance.PlayDialogueAudio(audioFile);

            if (i + 1 == ObjectCommentary.CurrentDialogueIDs.Count)
            {
                CharacterControllerLogic.Instance.GoToTalkingLastLineState();
                EndObjectCommentary();
            }

            float timerLength = (float)ObjectInteractionTimer.AudioClipLength;
            yield return new WaitForSeconds(timerLength);
        }
    }

    public static void FindLines(SpeechType speechType, ObjectsInLevel objectInLevel)
    {
        if (speechType == SpeechType.Investigation)
            FindInvestigationLines(objectInLevel);
        else if (speechType == SpeechType.Interaction)
            FindInteractionLines(objectInLevel);     
    }

    private static void ClearDialogueList()
    {
        CurrentDialogueIDs.Clear();
    }

    private static void EndObjectCommentary()
    {
        ClearDialogueList();
    }

    #region ObjectLines
    private static void FindInvestigationLines(ObjectsInLevel objectInLevel)
    {
        switch (objectInLevel)
        {
            case ObjectsInLevel.Null:
                Debug.Log("this object is null");
                break;
            case ObjectsInLevel.BennyTwospoons:
                if(!WorldEvents.EmmonKnowsBenny)
                    CurrentDialogueIDs.Add(6001);
                else
                    CurrentDialogueIDs.Add(6002);
                break;
            case ObjectsInLevel.AyTheTearCollector:
                if (DialogueManager.IsDialoguePassed(6003))
                {
                    CurrentDialogueIDs.Add(6008);
                }
                else
                {
                    CurrentDialogueIDs.Add(6003);
                    DialogueManager.AddToPassedDialogueLines(6003);
                }
                break;
            case ObjectsInLevel.Sentinel:
                CurrentDialogueIDs.Add(6004);
                break;
            case ObjectsInLevel.Gorilla:
                CurrentDialogueIDs.Add(6005);
                break;
            case ObjectsInLevel.ArmadilloCostume:
                CurrentDialogueIDs.Add(6006);
                break;
            case ObjectsInLevel.Lute:
                CurrentDialogueIDs.Add(6007);
                break;
            case ObjectsInLevel.CashMachine:
                CurrentDialogueIDs.Add(6009);
                break;
            case ObjectsInLevel.ClownNoses:
                CurrentDialogueIDs.Add(6010);
                break;
            case ObjectsInLevel.SneezePowder:
                CurrentDialogueIDs.Add(6011);
                break;
            case ObjectsInLevel.TwoSpoonsPainting1:
                CurrentDialogueIDs.Add(6012);
                break;
            case ObjectsInLevel.TwoSpoonsPainting2:
                CurrentDialogueIDs.Add(6013);
                break;
            case ObjectsInLevel.TwoSpoonsPainting3:
                CurrentDialogueIDs.Add(6014);
                break;
            case ObjectsInLevel.TwoSpoonsWallPainting:
                CurrentDialogueIDs.Add(6015);
                break;
            case ObjectsInLevel.Wigs:
                CurrentDialogueIDs.Add(6016);
                break;
            case ObjectsInLevel.Hatch:
                CurrentDialogueIDs.Add(6017);
                break;
            case ObjectsInLevel.Marionet:
                CurrentDialogueIDs.Add(6018);
                break;
            case ObjectsInLevel.ClownCertificate:
                if (DialogueManager.IsDialoguePassed(6020))
                {
                    CurrentDialogueIDs.Add(6026);
                }
                else
                {
                    CurrentDialogueIDs.Add(6020);////////////////TODO
                    DialogueManager.AddToPassedDialogueLines(6020);
                 //   ChangeLine = "";
                 //   ChangeIndex = 6020;
                }
                break;
            case ObjectsInLevel.LapelFlowers:
                CurrentDialogueIDs.Add(6021);
                break;
            case ObjectsInLevel.ExplodingCandles:
                CurrentDialogueIDs.Add(6022);
                CurrentDialogueIDs.Add(6023);
                break;
            case ObjectsInLevel.RockingHorse:
                CurrentDialogueIDs.Add(6025);
                break;
            case ObjectsInLevel.TheTwoSpoonsSign:
                CurrentDialogueIDs.Add(6030);
                break;
            case ObjectsInLevel.BeehiveHut:
                CurrentDialogueIDs.Add(6032);
                break;
            case ObjectsInLevel.Carrot:
                CurrentDialogueIDs.Add(6033);
                break;
            case ObjectsInLevel.TearCollectorSkull:
                CurrentDialogueIDs.Add(6034);
                break;
            case ObjectsInLevel.TreasureChest:
                CurrentDialogueIDs.Add(6035);
                break;
            case ObjectsInLevel.CaveSign:
                CurrentDialogueIDs.Add(6036);
                break;
            case ObjectsInLevel.MuseumDoor:
                CurrentDialogueIDs.Add(6040);
                break;
            case ObjectsInLevel.MuseumLeftPanel:
                CurrentDialogueIDs.Add(6041);
                break;
            case ObjectsInLevel.ApathyHead:
                CurrentDialogueIDs.Add(6042);
                break;
            case ObjectsInLevel.MuseumMiddlePanelLeft:
                CurrentDialogueIDs.Add(6043);
                break;
            case ObjectsInLevel.MuseumMiddlePanelMiddle:
                CurrentDialogueIDs.Add(6044);
                CurrentDialogueIDs.Add(6045);
                break;
            case ObjectsInLevel.MuseumMiddlePanelRight:
                CurrentDialogueIDs.Add(6046);
                break;
            case ObjectsInLevel.MuseumRightPanel:
                CurrentDialogueIDs.Add(6047);
                break;
            case ObjectsInLevel.MuseumRightPanelTower:
                CurrentDialogueIDs.Add(6049);
                break;
            case ObjectsInLevel.MuseumRightPanelCynicism:
                CurrentDialogueIDs.Add(6050);
                break;
            case ObjectsInLevel.MuseumRightPanelCrater:
                CurrentDialogueIDs.Add(6051);
                break;            
            case ObjectsInLevel.MuseumRightPanelOffering:
                CurrentDialogueIDs.Add(6052);
                break;
            case ObjectsInLevel.SideDoor:
                CurrentDialogueIDs.Add(6053);
                break;
            case ObjectsInLevel.DamagedWall:
                CurrentDialogueIDs.Add(6054);
                break;
            case ObjectsInLevel.MaskOfMockery:
                CurrentDialogueIDs.Add(6055);
                break;
            case ObjectsInLevel.Wheel1:
                CurrentDialogueIDs.Add(6060);
                break;
            case ObjectsInLevel.Wheel2:
                CurrentDialogueIDs.Add(6060);
                break;
            case ObjectsInLevel.Wheel3:
                CurrentDialogueIDs.Add(6060);
                break;
            case ObjectsInLevel.Wheel4:
                CurrentDialogueIDs.Add(6060);
                break;
            case ObjectsInLevel.Wheel5:
                CurrentDialogueIDs.Add(6060);
                break;
            case ObjectsInLevel.Wheel6:
                CurrentDialogueIDs.Add(6060);
                break;
            case ObjectsInLevel.Rabbit:
                CurrentDialogueIDs.Add(6061);   //TODO: Needs its own description!
                break;
            default:
                break;
        }
    }

    private static void FindInteractionLines(ObjectsInLevel objectInLevel)
    {
        switch (objectInLevel)
        {
            case ObjectsInLevel.Null:
                Debug.Log("this object is null");
                break;
            case ObjectsInLevel.BennyTwospoons:
                BennyTwospoons.Instance.StartDialogue();
                break;
            case ObjectsInLevel.AyTheTearCollector:
                AyTheTearCollector.Instance.StartDialogue();
                break;
            case ObjectsInLevel.Sentinel:
                if(!WorldEvents.EmmonHasPassedTheSentinel)
                    Sentinel.Instance.StartDialogue();
                else
                    CurrentDialogueIDs.Add(7061);
                break;
            case ObjectsInLevel.Gorilla:
                CurrentDialogueIDs.Add(7005);
                break;
            case ObjectsInLevel.ArmadilloCostume:
                CurrentDialogueIDs.Add(7006);
                break;
            case ObjectsInLevel.Lute:
                AskingLute = true;
                if (!WorldEvents.EmmonSawTheLute)
                {
                    WorldEvents.EmmonSawTheLute = true;
                    BennyTwospoons.Instance.StartDialogue();
                }
                else
                    CurrentDialogueIDs.Add(7007);
                break;
            case ObjectsInLevel.CashMachine:
                CurrentDialogueIDs.Add(7008);
                break;
            case ObjectsInLevel.ClownNoses:
                CurrentDialogueIDs.Add(7009);
                break;
            case ObjectsInLevel.SneezePowder:
                CurrentDialogueIDs.Add(7010);
                break;
            case ObjectsInLevel.TwoSpoonsPainting1:
                CurrentDialogueIDs.Add(7011);
                break;
            case ObjectsInLevel.TwoSpoonsPainting2:
                CurrentDialogueIDs.Add(7012);
                break;
            case ObjectsInLevel.TwoSpoonsPainting3:
                CurrentDialogueIDs.Add(7013);
                break;
            case ObjectsInLevel.TwoSpoonsWallPainting:
                CurrentDialogueIDs.Add(7014);
                break;
            case ObjectsInLevel.Wigs:
                CurrentDialogueIDs.Add(7015);
                break;
            case ObjectsInLevel.Hatch:
                CurrentDialogueIDs.Add(7016);
                break;
            case ObjectsInLevel.Marionet:
                CurrentDialogueIDs.Add(7017);
                break;
            case ObjectsInLevel.ClownCertificate:
                CurrentDialogueIDs.Add(7019);
                break;
            case ObjectsInLevel.LapelFlowers:
                CurrentDialogueIDs.Add(7020);
                break;
            case ObjectsInLevel.ExplodingCandles:
                CurrentDialogueIDs.Add(7022);
                break;
            case ObjectsInLevel.RockingHorse:
                CurrentDialogueIDs.Add(7022);
                break;
            case ObjectsInLevel.TheTwoSpoonsSign:
                CurrentDialogueIDs.Add(7030);
                break;
            case ObjectsInLevel.BeehiveHut:
                CurrentDialogueIDs.Add(7032);
                break;
            case ObjectsInLevel.Carrot: // pickup carrot
                CurrentDialogueIDs.Add(7033);
                ItemManager.AddItem(2);
                InGameObjectManager.PickedUpCarrot = true;
                InGameObjectManager.Instance.TurnOffObject(GameObject.Find("Carrot"));
                AudioManager.PickUpAudio();
                break;
            case ObjectsInLevel.TearCollectorSkull:
                CurrentDialogueIDs.Add(7034);
                break;
            case ObjectsInLevel.TreasureChest:
                GameObject chest = GameManager.Instance.InGameObjectM.TreasureChests[0];
                if(!chest.GetComponentInChildren<ButtonPush>().ChestIsOpen)
                    chest.GetComponentInChildren<ButtonPush>().ChestIsOpen = true;
                else
                CurrentDialogueIDs.Add(7035);   // if already open
                break;
            case ObjectsInLevel.CaveSign:
                CurrentDialogueIDs.Add(7036);
                break;
            case ObjectsInLevel.MuseumDoor:
                CurrentDialogueIDs.Add(7040);
                break;
            case ObjectsInLevel.MuseumLeftPanel:
                CurrentDialogueIDs.Add(7041);
                break;
            case ObjectsInLevel.ApathyHead:
                CurrentDialogueIDs.Add(7042);
                break;
            case ObjectsInLevel.MuseumMiddlePanelLeft:
                CurrentDialogueIDs.Add(7043);
                break;
            case ObjectsInLevel.MuseumMiddlePanelMiddle:
                CurrentDialogueIDs.Add(7044);
                break;
            case ObjectsInLevel.MuseumMiddlePanelRight:
                CurrentDialogueIDs.Add(7045);
                break;
            case ObjectsInLevel.MuseumRightPanel:
                CurrentDialogueIDs.Add(7046);
                break;
            case ObjectsInLevel.MuseumRightPanelTower:
                CurrentDialogueIDs.Add(7048);
                break;
            case ObjectsInLevel.MuseumRightPanelCynicism:
                CurrentDialogueIDs.Add(7049);
                break;
            case ObjectsInLevel.MuseumRightPanelCrater:
                CurrentDialogueIDs.Add(7050);
                break;
            case ObjectsInLevel.MuseumRightPanelOffering:
                CurrentDialogueIDs.Add(7051);
                break;
            case ObjectsInLevel.SideDoor:
                CurrentDialogueIDs.Add(7052);
                break;
            case ObjectsInLevel.DamagedWall:
                CurrentDialogueIDs.Add(7053);
                break;
            case ObjectsInLevel.MaskOfMockery:
                CurrentDialogueIDs.Add(7054);
                ItemManager.AddItem(3); //Add mask of mockery to inventory
                InGameObjectManager.PickedUpMaskOfMockery = true;
                AudioManager.PickUpAudio();
                break;
            case ObjectsInLevel.Wheel1:
                GateWheel.ChooseWheelNumber(1);
                break;
            case ObjectsInLevel.Wheel2:
                GateWheel.ChooseWheelNumber(2);
                break;
            case ObjectsInLevel.Wheel3:
                GateWheel.ChooseWheelNumber(3);
                break;
            case ObjectsInLevel.Wheel4:
                GateWheel.ChooseWheelNumber(4);
                break;
            case ObjectsInLevel.Wheel5:
                GateWheel.ChooseWheelNumber(5);
                break;
            case ObjectsInLevel.Wheel6:
                GateWheel.ChooseWheelNumber(6);
                break;
            case ObjectsInLevel.Rabbit:
                CurrentDialogueIDs.Add(7049);
                break;
            default:
                break;
        }
    }
#endregion

    public static int CheckUniqueAudio(int id)
    {
        if (id == 7012)
            id = 7011;
        else if (id == 7036)
            id = 7037;
        else if (id == 7044)
            id = 7042;
        else if (id == 7050)
            id = 7049;
        else if (id == 6061)
            id = 7041;
        else if (id == 7053)
            id = 7052;

        return id;
    }
}