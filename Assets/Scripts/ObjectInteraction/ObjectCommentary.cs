using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class ObjectCommentary
{
  //  public static int LastLineID = 0;
    public static int CurrentID = 0;
    public static bool AskingLute = false;
  //  public static Inventory IInventory;
    public static int ChangeIndex = 0;
    public static string ChangeLine = "";

    public static List<int> CurrentDialogueIDs = new List<int>();

    #region Lines
    public static Dictionary<int, string> InvestigationLines = new Dictionary<int, string>()
    {
        {1001, "I don’t expect too many jokes from him."},
        {1002, "Grumpy old Benny Twospoons."},
        {1003, "A peculiar figure."},
        {1004, "Unwavering."},
        {1005, "Dangerous and hairy. Useful to scare children away on a late night party."},
        {1006, "This is a very strange costume. I wonder if this intriguing outfit is popular."},
        {1007, "A lute! It looks nice. It's a bit out of tune though."},
        {1008, "It is Ay, the town's tear collector."},
        {1009, "An antique brass cash register."},
        {1010, "Big red clown noses, indispensable assets to turn someone into a clown."},
        {1011, "A box of cachoo sneeze powder™. I have not seen that since my 6th birthday."},
        {1012, "A picture of the owner, or maybe a close associate."},
        {1013, "I wonder what face is concealed behind the thick layers of paint."},
        {1014, "Pretty Avant Garde, isn’t it?"},
        {1015, "The heydays of the circus."},
        {1016, "I heard a rumour that these wigs are made of the beards of the unfaithful bards."},
        {1017, "I wonder what the clown has hidden away down there."},
        {1018, "It looks handmade."},
        {1020, "This is to acknowledge that Benny Twospoons successfully entertained the Longshoe Clown Association of Mindolum."},
        {1021, "Squirting lapel flowers. Such an old-fashioned joke."},
        {1022, "Exploding candles."},
        {1023, "That’s right. Exploding birthday cake candles. You can choose how many candles you want, depending on what anniversary you’re celebrating."},
        {1025, "investigate rocking horse"},
        {1026, "The owner must be proud of his credentials."},
        {1030, "The Two Spoons."},
        {1033, "It looks delicious."},
        {1034, "The skull blends in nicely with the overall creepiness of this place."},

        {1035, "I hope it is filled with booty"},////////////////////////**********
        {1036, "I think it wants me to go out"},

        {1040, "The gate looks solid and ornamented."},
        {1041, "Ancient drawings depicting the Drenchy Flood."},
        {1042, "The deity looks a bit confused about what’s going on."},
        {1043, "People desperately hold on to their raft while a scary looking deity stares at them in apathy."},
        {1044, "It is a scene from the Anchorian Flooding Myth."},
        {1045, "The Anchorians have found a place safe from the devastating ocean and beg their god for help. He only seems to mock them."},
        {1046, "Hedonists."},
        {1048, "The illustration shows how the Anchorians recovered from the Drenchy Flood and thanked their mysterious deities."},
        {1049, "This must be the famous Citadel of Doubt, dedicated to the old Anchorian god of Cynicism."},
        {1050, "It is the god of Cynicism, watching the progress on his tower."},
        {1051, "This looks like the Museum of Mockery, exactly this place, drawn hundreds of years ago!"},
        {1052, "They seem to worship a deity of the most ridiculous kind. Probably the Idol of Indifference."},
        {1053, "To what other treasures this door might lead?"},
        {1054, "Hm.. the wall here seems damaged."},
        {1055, "This must be the famous mask of Mockery!"},
        {1060, "Hm.. All sides of the wheel have different colours."},
    };

    public static Dictionary<int, string> InteractionLines = new Dictionary<int, string>()
    {
        {10001, "Let's get closer."},
        {10002, "Let's get closer."},
        {2001, "Interact with the Grumpy Clown."},
        {2002, "Interact with Benny."},
        {2003, "Interact with Ay."},
        {2004, "Interact with the Sentinel."},
        {2005, "No thanks. I prefer my human form."},
        {2006, "Never!"},
        {2007, "Benny won't give the lute for free."},
        {2008, "I don’t think the clown would appreciate me messing with his administration."},
        {2009, "I would rather paint mine."},
        {2010, "No, that would make me sneeze."},
        {2011, "I don’t want to carry a portrait of a clown around."},
        {2012, "I don’t want to carry a portrait of a clown around."},
        {2013, "No, here it looks just right."},
        {2014, "I think the clown wouldn’t like me to touch it."},
        {2015, "I don’t need a wig."},
        {2016, "It is locked"},
        {2017, "It is too high."},
        {2019, "I am a minstrel, I have no ambition to take up a job as clown on the side."},
        {2020, "These clowns just never grow up."},
        {2022, "Interact with exploding candles"},
        
        {2030, "How?"},
        {2032, "Nah, that is silly."},
        {2033, "You never know.."},
        {2034, "No, I need the Mask of Mockery."},
        {2035, "I already plundered it."},  

        {2036, "That would confuse fellow travelers."},
        {2037, "That would confuse fellow travelers."},

        {2040, "Open sesame!"},
        {2041, "I better leave it alone."},
        {2042, "That is impossible."},
        {2043, "No."},
        {2044, "That is impossible."},
        {2045, "That seems hopeless."},
        {2046, "I don’t think so."},
        {2047, " "},
        {2048, "No, no, no!"},
        {2049, "No."},
        {2050, "No."},
        {2051, "I better leave it alone."},
        {2052, "Nah, I’ll save that for another adventure."},
        {2053, "Nah, I’ll save that for another adventure."},
        {2054, "Finally!"},  //mask of mockery
        {2060, " "},    
    };

    #endregion Lines

    public static IEnumerator LetsGetCloserRoutine()
    {
        DialogueManager.ThisDialogueType = DialogueManager.DialogueType.ObjectInteraction;

        int id = 10001;
        DialoguePlayback.SetCurrentDialogueLine(InteractionLines[id]);

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
            if(speechType == SpeechType.Investigation)
                DialoguePlayback.SetCurrentDialogueLine(InvestigationLines[id]);
            else if(speechType == SpeechType.Interaction)
                DialoguePlayback.SetCurrentDialogueLine(InteractionLines[id]);

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
                    CurrentDialogueIDs.Add(1001);
                else
                    CurrentDialogueIDs.Add(1002);
                break;
            case ObjectsInLevel.AyTheTearCollector:
                if (InvestigationLines[1003] == "")
                {
                    CurrentDialogueIDs.Add(1008);
                }
                else
                {
                    CurrentDialogueIDs.Add(1003);
                    ChangeLine = "";
                    ChangeIndex = 1003;
                }
                break;
            case ObjectsInLevel.Sentinel:
                CurrentDialogueIDs.Add(1004);
                break;
            case ObjectsInLevel.Gorilla:
                CurrentDialogueIDs.Add(1005);
                break;
            case ObjectsInLevel.ArmadilloCostume:
                CurrentDialogueIDs.Add(1006);
                break;
            case ObjectsInLevel.Lute:
                CurrentDialogueIDs.Add(1007);
                break;
            case ObjectsInLevel.CashMachine:
                CurrentDialogueIDs.Add(1009);
                break;
            case ObjectsInLevel.ClownNoses:
                CurrentDialogueIDs.Add(1010);
                break;
            case ObjectsInLevel.SneezePowder:
                CurrentDialogueIDs.Add(1011);
                break;
            case ObjectsInLevel.TwoSpoonsPainting1:
                CurrentDialogueIDs.Add(1012);
                break;
            case ObjectsInLevel.TwoSpoonsPainting2:
                CurrentDialogueIDs.Add(1013);
                break;
            case ObjectsInLevel.TwoSpoonsPainting3:
                CurrentDialogueIDs.Add(1014);
                break;
            case ObjectsInLevel.TwoSpoonsWallPainting:
                CurrentDialogueIDs.Add(1015);
                break;
            case ObjectsInLevel.Wigs:
                CurrentDialogueIDs.Add(1016);
                break;
            case ObjectsInLevel.Hatch:
                CurrentDialogueIDs.Add(1017);
                break;
            case ObjectsInLevel.Marionet:
                CurrentDialogueIDs.Add(1018);
                break;
            case ObjectsInLevel.ClownCertificate:
                if (InvestigationLines[1020] == "")
                {
                    CurrentDialogueIDs.Add(1026);
                }
                else
                {
                    CurrentDialogueIDs.Add(1020);
                    ChangeLine = "";
                    ChangeIndex = 1020;
                }
                break;
            case ObjectsInLevel.LapelFlowers:
                CurrentDialogueIDs.Add(1021);
                break;
            case ObjectsInLevel.ExplodingCandles:
                CurrentDialogueIDs.Add(1022);
                CurrentDialogueIDs.Add(1023);
                break;
            case ObjectsInLevel.RockingHorse:
                CurrentDialogueIDs.Add(1025);
                break;
            case ObjectsInLevel.TheTwoSpoonsSign:
                CurrentDialogueIDs.Add(1030);
                break;
            case ObjectsInLevel.BeehiveHut:
                CurrentDialogueIDs.Add(1032);
                break;
            case ObjectsInLevel.Carrot:
                CurrentDialogueIDs.Add(1033);
                break;
            case ObjectsInLevel.TearCollectorSkull:
                CurrentDialogueIDs.Add(1034);
                break;
            case ObjectsInLevel.TreasureChest:
                CurrentDialogueIDs.Add(1035);
                break;
            case ObjectsInLevel.CaveSign:
                CurrentDialogueIDs.Add(1036);
                break;
            case ObjectsInLevel.MuseumDoor:
                CurrentDialogueIDs.Add(1040);
                break;
            case ObjectsInLevel.MuseumLeftPanel:
                CurrentDialogueIDs.Add(1041);
                break;
            case ObjectsInLevel.ApathyHead:
                CurrentDialogueIDs.Add(1042);
                break;
            case ObjectsInLevel.MuseumMiddlePanelLeft:
                CurrentDialogueIDs.Add(1043);
                break;
            case ObjectsInLevel.MuseumMiddlePanelMiddle:
                CurrentDialogueIDs.Add(1044);
                CurrentDialogueIDs.Add(1045);
                break;
            case ObjectsInLevel.MuseumMiddlePanelRight:
                CurrentDialogueIDs.Add(1046);
                break;
            case ObjectsInLevel.MuseumRightPanel:
                CurrentDialogueIDs.Add(1047);
                break;
            case ObjectsInLevel.MuseumRightPanelTower:
                CurrentDialogueIDs.Add(1049);
                break;
            case ObjectsInLevel.MuseumRightPanelCynicism:
                CurrentDialogueIDs.Add(1050);
                break;
            case ObjectsInLevel.MuseumRightPanelCrater:
                CurrentDialogueIDs.Add(1051);
                break;            
            case ObjectsInLevel.MuseumRightPanelOffering:
                CurrentDialogueIDs.Add(1052);
                break;
            case ObjectsInLevel.SideDoor:
                CurrentDialogueIDs.Add(1053);
                break;
            case ObjectsInLevel.DamagedWall:
                CurrentDialogueIDs.Add(1054);
                break;
            case ObjectsInLevel.MaskOfMockery:
                CurrentDialogueIDs.Add(1055);
                break;
            case ObjectsInLevel.Wheel1:
                CurrentDialogueIDs.Add(1060);
                break;
            case ObjectsInLevel.Wheel2:
                CurrentDialogueIDs.Add(1060);
                break;
            case ObjectsInLevel.Wheel3:
                CurrentDialogueIDs.Add(1060);
                break;
            case ObjectsInLevel.Wheel4:
                CurrentDialogueIDs.Add(1060);
                break;
            case ObjectsInLevel.Wheel5:
                CurrentDialogueIDs.Add(1060);
                break;
            case ObjectsInLevel.Wheel6:
                CurrentDialogueIDs.Add(1060);
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
                Sentinel.Instance.StartDialogue();
                break;
            case ObjectsInLevel.Gorilla:
                CurrentDialogueIDs.Add(2005);
                break;
            case ObjectsInLevel.ArmadilloCostume:
                CurrentDialogueIDs.Add(2006);
                break;
            case ObjectsInLevel.Lute:
                AskingLute = true;
                if (!WorldEvents.EmmonSawTheLute)
                {
                    WorldEvents.EmmonSawTheLute = true;
                    BennyTwospoons.Instance.StartDialogue();
                }
                else
                    CurrentDialogueIDs.Add(2007);
                break;
            case ObjectsInLevel.CashMachine:
                CurrentDialogueIDs.Add(2008);
                break;
            case ObjectsInLevel.ClownNoses:
                CurrentDialogueIDs.Add(2009);
                break;
            case ObjectsInLevel.SneezePowder:
                CurrentDialogueIDs.Add(2010);
                break;
            case ObjectsInLevel.TwoSpoonsPainting1:
                CurrentDialogueIDs.Add(2011);
                break;
            case ObjectsInLevel.TwoSpoonsPainting2:
                CurrentDialogueIDs.Add(2012);
                break;
            case ObjectsInLevel.TwoSpoonsPainting3:
                CurrentDialogueIDs.Add(2013);
                break;
            case ObjectsInLevel.TwoSpoonsWallPainting:
                CurrentDialogueIDs.Add(2014);
                break;
            case ObjectsInLevel.Wigs:
                CurrentDialogueIDs.Add(2015);
                break;
            case ObjectsInLevel.Hatch:
                CurrentDialogueIDs.Add(2016);
                break;
            case ObjectsInLevel.Marionet:
                CurrentDialogueIDs.Add(2017);
                break;
            case ObjectsInLevel.ClownCertificate:
                CurrentDialogueIDs.Add(2019);
                break;
            case ObjectsInLevel.LapelFlowers:
                CurrentDialogueIDs.Add(2020);
                break;
            case ObjectsInLevel.ExplodingCandles:
                CurrentDialogueIDs.Add(2022);
                break;
            case ObjectsInLevel.TheTwoSpoonsSign:
                CurrentDialogueIDs.Add(2030);
                break;
            case ObjectsInLevel.BeehiveHut:
                CurrentDialogueIDs.Add(2032);
                break;
            case ObjectsInLevel.Carrot: // pickup carrot
                CurrentDialogueIDs.Add(2033);
                ItemManager.AddItem(2);
                InGameObjectManager.PickedUpCarrot = true;
                InGameObjectManager.Instance.TurnOffObject(GameObject.Find("Carrot"));
                AudioManager.PickUpAudio();
                break;
            case ObjectsInLevel.TearCollectorSkull:
                CurrentDialogueIDs.Add(2034);
                break;
            case ObjectsInLevel.TreasureChest:
                GameObject chest = GameManager.Instance.InGameObjectM.TreasureChests[0];
                if(!chest.GetComponentInChildren<ButtonPush>().ChestIsOpen)
                    chest.GetComponentInChildren<ButtonPush>().ChestIsOpen = true;
                else
                CurrentDialogueIDs.Add(2035);   // if already open
                break;
            case ObjectsInLevel.CaveSign:
                CurrentDialogueIDs.Add(2036);
                break;
            case ObjectsInLevel.MuseumDoor:
                CurrentDialogueIDs.Add(2040);
                break;
            case ObjectsInLevel.MuseumLeftPanel:
                CurrentDialogueIDs.Add(2041);
                break;
            case ObjectsInLevel.ApathyHead:
                CurrentDialogueIDs.Add(2042);
                break;
            case ObjectsInLevel.MuseumMiddlePanelLeft:
                CurrentDialogueIDs.Add(2043);
                break;
            case ObjectsInLevel.MuseumMiddlePanelMiddle:
                CurrentDialogueIDs.Add(2044);
                break;
            case ObjectsInLevel.MuseumMiddlePanelRight:
                CurrentDialogueIDs.Add(2045);
                break;
            case ObjectsInLevel.MuseumRightPanel:
                CurrentDialogueIDs.Add(2046);
                break;
            case ObjectsInLevel.MuseumRightPanelTower:
                CurrentDialogueIDs.Add(2048);
                break;
            case ObjectsInLevel.MuseumRightPanelCynicism:
                CurrentDialogueIDs.Add(2049);
                break;
            case ObjectsInLevel.MuseumRightPanelCrater:
                CurrentDialogueIDs.Add(2050);
                break;
            case ObjectsInLevel.MuseumRightPanelOffering:
                CurrentDialogueIDs.Add(2051);
                break;
            case ObjectsInLevel.SideDoor:
                CurrentDialogueIDs.Add(2052);
                break;
            case ObjectsInLevel.DamagedWall:
                CurrentDialogueIDs.Add(2053);
                break;
            case ObjectsInLevel.MaskOfMockery:
                CurrentDialogueIDs.Add(2054);
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
            default:
                break;
        }
    }
#endregion

    public static int CheckUniqueAudio(int id)
    {
        if (id == 2012)
            id = 2011;
        else if (id == 2036)
            id = 2037;
        else if (id == 2044)
            id = 2042;
        else if (id == 2050)
            id = 2049;
        else if (id == 2053)
            id = 2052;

        return id;
    }
}

