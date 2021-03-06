﻿using System.Collections.Generic;
using UnityEngine;

public class BennyTwospoons : MonoBehaviour
{
    public static int CharacterSituation;
    public static BennyTwospoons Instance;
    public Animator Animator;

    private static List<int> LastBefore1003 = new List<int>() { 1002, 1009, 1012, 1016, 1054 };
    private static List<int> LastBefore1006 = new List<int>() { 1002, 1005, 1042, 1050, 1054, 1059, 1062, 1082, 1095 };
    private static List<int> LastBefore1010 = new List<int>() { 1009, 1042, 1050, 1054, 1059, 1062, 1082, 1095 };
    private static List<int> LastBefore1013 = new List<int>() { 1012, 1042, 1050, 1054, 1059, 1062, 1082, 1095 };
    private static List<int> LastBefore1017 = new List<int>() { 1002, 1005, 1009, 1012, 1016, 1042, 1050, 1054, 1062, 1073, 1082, 1095 };
    private static List<int> LastBefore1018 = new List<int>() { 1009, 1012, 1016 };
    private static List<int> LastBefore1043 = new List<int>() { 1009, 1012, 1016, 1042, 1054, 1062 };
    private static List<int> LastBefore1055 = new List<int>() { 1009, 1012, 1016, 1054, 1062, 1073, 2067, 1082 };
    private static List<int> LastBefore1061 = new List<int>() { 1009, 1012, 1016, 1042, 1054, 1059, 1073, 1082, 1095 };
    private static List<int> LastBefore1063 = new List<int>() { 1009, 1012, 1016, 1054, 1062 };
    private static List<int> LastBefore1074 = new List<int>() { 1009, 1012, 1016, 1054, 1062, 1073, 1082 };
    private static List<int> LastBefore1075 = new List<int>() { 1074, 1077, 1079, 1081 };
    private static List<int> LastBefore1078 = new List<int>() { 1074, 1077, 1079, 1081 };
    private static List<int> LastBefore1080 = new List<int>() { 1074, 1077, 1079, 1081 };
    private static List<int> LastBefore1082 = new List<int>() { 1074, 1077, 1079, 1081 };
    private static List<int> LastBefore1094 = new List<int>() { 1005, 1009, 1012, 1016, 1050, 1054, 1062, 1073, 1082, 1095 };

    private static Dictionary<int, List<int>> LastLinesBeforeOption = new Dictionary<int, List<int>>()
    { 
        {1003, LastBefore1003},
        {1006, LastBefore1006},
        {1010, LastBefore1010},
        {1013, LastBefore1013},
        {1017, LastBefore1017},
        {1018, LastBefore1018},
        {1043, LastBefore1043},
        {1055, LastBefore1055},
        {1061, LastBefore1061},
        {1063, LastBefore1063},
        {1074, LastBefore1074},
        {1075, LastBefore1075},
        {1078, LastBefore1078},
        {1080, LastBefore1080},
        {1082, LastBefore1082},
        {1094, LastBefore1094},
    };

    public void Start()
    {
        Instance = this;

        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Benny, 0);
    }

    public void DialogueLineNumberToSituation(int lastLineID)   //the last line of dialogue determines which situation will follow
    {
        var characterSituation = CharacterSituation;
        if (IsLastBefore(lastLineID, 1003) && !WorldEvents.EmmonSawTheLute)
            DialogueMenu.AddToDialogueOptions(1003);

        if (IsLastBefore(lastLineID, 1006))
            DialogueMenu.AddToDialogueOptions(1006);

        if(DialogueManager.IsDialoguePassed(1006) &&
            IsLastBefore(lastLineID, 1010))
            DialogueMenu.AddToDialogueOptions(1010);

        if (DialogueManager.IsDialoguePassed(1010) &&
            IsLastBefore(lastLineID, 1013))
            DialogueMenu.AddToDialogueOptions(1013);

        if (IsLastBefore(lastLineID, 1018) && DialogueManager.IsDialoguePassed(1018))
            DialogueMenu.AddToDialogueOptions(1018);

        if (lastLineID == 1024)
        {
            DialogueMenu.AddToDialogueOptions(1025);
            DialogueMenu.AddToDialogueOptions(1026);
            DialogueMenu.AddToDialogueOptions(1027);
            DialogueMenu.AddToDialogueOptions(1028);
        }

        if (lastLineID == 1031)
        {
            DialogueMenu.AddToDialogueOptions(1032);
            DialogueMenu.AddToDialogueOptions(1033);
            DialogueMenu.AddToDialogueOptions(1034);
            DialogueMenu.AddToDialogueOptions(1035);
        }

        if (IsLastBefore(lastLineID, 1043) && (DialogueManager.IsDialoguePassed(1032) || DialogueManager.IsDialoguePassed(1033) || DialogueManager.IsDialoguePassed(1034) || DialogueManager.IsDialoguePassed(1035)))
            DialogueMenu.AddToDialogueOptions(1043);

        if (IsLastBefore(lastLineID, 1055) && characterSituation > 2) //I feel I'm getting closer to the Mask of Mockery!
            DialogueMenu.AddToDialogueOptions(1055);

        if (IsLastBefore(lastLineID, 1061) && WorldEvents.EmmonKnowsAy == true && characterSituation > 2)     //tear collector person
            DialogueMenu.AddToDialogueOptions(1061);

        if (IsLastBefore(lastLineID, 1063) && characterSituation == 4) ////about this mask
            DialogueMenu.AddToDialogueOptions(1063);

        if (lastLineID == 1066)
        {
            DialogueMenu.AddToDialogueOptions(1067);
            DialogueMenu.AddToDialogueOptions(1068);
            DialogueMenu.AddToDialogueOptions(1069);
            DialogueMenu.AddToDialogueOptions(1070);
        }

        if (IsLastBefore(lastLineID, 1074) && (DialogueManager.IsDialoguePassed(1067) || DialogueManager.IsDialoguePassed(1068) || DialogueManager.IsDialoguePassed(1069) || DialogueManager.IsDialoguePassed(1070)))
            DialogueMenu.AddToDialogueOptions(1074);

        if (IsLastBefore(lastLineID, 1075))
            DialogueMenu.AddToDialogueOptions(1075);

        if (IsLastBefore(lastLineID, 1078))
            DialogueMenu.AddToDialogueOptions(1078);

        if (IsLastBefore(lastLineID, 1080))
            DialogueMenu.AddToDialogueOptions(1080);

        if (IsLastBefore(lastLineID, 1082))
            DialogueMenu.AddToDialogueOptions(1082);

        if (IsLastBefore(lastLineID, 1094) && DialogueManager.IsDialoguePassed(1043) && characterSituation < 4)
            DialogueMenu.AddToDialogueOptions(1094);

        if (IsLastBefore(lastLineID, 1017))
            DialogueMenu.AddToDialogueOptions(1017);    //exit option

        switch (lastLineID)
        {
            //opening options
            case 1:
                FindDialogueSituation(1);
                break;
            case 2:
                FindDialogueSituation(2);
                break;
            case 3:
                FindDialogueSituation(3);
                break;
            case 4:
                FindDialogueSituation(4);
                break;
            case 5:
                FindDialogueSituation(5);
                break;
            case 6:
                FindDialogueSituation(6);
                break;
            default:
                FindDialogueSituation(999);
                break;
        }
    }

    public void FindDialogueSituation(int dialogueSituation)
    {
        CharacterControllerLogic.Instance.GoToTalkingState();

        switch (dialogueSituation)
        {
            case 1: //SITUATION 1
                if (!WorldEvents.EmmonKnowsBenny)
                {
                    AddToDialogue(1000);
                    AddToDialogue(1001);
                    AddToDialogue(1002);
                    WorldEvents.EmmonKnowsBenny = true;
                    MouseClickOnObject.ObjectLines[ObjectsInLevel.BennyTwospoons] = "Ex-clown Benny Twospoons";
                    MouseClickOnObject.ObjectInvestigationLines[ObjectsInLevel.BennyTwospoons] = "Investigate Benny Twospoons";
                    MouseClickOnObject.ObjectInteractionLines[ObjectsInLevel.BennyTwospoons] = "Talk to Benny Twospoons";

                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(1000);
                }
                else // hi
                {
                    AddToDialogue(1052);
                    AddToDialogue(1051);
                    //AddToDialogue(1053);
                    AddToDialogue(1054);
                    DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(1054);
                }
                break;
            case 2: //SITUATION 2 EmmonSeesTheLute
                DialoguePlayback.DeleteLineID = 1018;

                AddToDialogue(1018);
                AddToDialogue(1019);
                AddToDialogue(1020);
                AddToDialogue(1021);
                AddToDialogue(1022);    //could be exactly what I need!
                AddToDialogue(1023);
                AddToDialogue(1923);
                AddToDialogue(1024);

                WorldEvents.EmmonKnowsBenny = true;
                MouseClickOnObject.ObjectLines[ObjectsInLevel.BennyTwospoons] = "Ex-clown Benny Twospoons";        

                ObjectCommentary.AskingLute = false;
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(1018);

            //    CharacterControllerLogic.Instance.ForceTurningAngle(0);
                TimeManager.Instance.CreateRotator(GameManager.Player.transform, this.transform, 2f, 3f);

                break;
            case 3://I'm back but EmmonKnowsMaskLocation
                AddToDialogue(1051);
                AddToDialogue(1052);
                AddToDialogue(1053);
                AddToDialogue(1054);
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(1054);
                break;
            case 4: //I'm back but EmmonWasBlockedBySentinel
                AddToDialogue(1051);
                AddToDialogue(1052);
                AddToDialogue(1053);
                AddToDialogue(1054);
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(1054);
                break;
            case 5: // That sentinel was no match for me. He’s sleeping with the fishes.
                AddToDialogue(1083);
                AddToDialogue(1084);
                AddToDialogue(1085);
                AddToDialogue(1086);
                DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(1083);
                break;
            case 6: // This will make your day: I found you The Mask Of Mockery.
                AddToDialogue(1087);
                AddToDialogue(1088);
                AddToDialogue(1089);
                AddToDialogue(1090);
                AddToDialogue(1091);
                AddToDialogue(1092);
                AddToDialogue(1093);    // end of the level

                WorldEvents.MissionAccomplished = true;
           //     DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(1087);
                break;
            case 999:
                DialogueMenu.FindDialogueOptionText(Character.Benny);
                break;

            default: //in all other dialogue options
                DialogueMenu.FindDialogueOptionText(Character.Benny);
                Debug.LogError("I don't know this dialogue situation: Situation " + dialogueSituation);
                break;
        }
    }

    public static void TriggerDialogue(int dialogueOptionID)
    {
        if (dialogueOptionID == 1003)
        {
            DialoguePlayback.DeleteLineID = 1003;
            WorldEvents.EmmonSawTheLute = true;

            AddToDialogue(1003);
            AddToDialogue(1004);
            AddToDialogue(1005);
            AddToDialogue(1023);
            AddToDialogue(1923);
            AddToDialogue(1024);
        }

        if (dialogueOptionID == 1006)
        {
            DialoguePlayback.DeleteLineID = 1006;

            AddToDialogue(1006);
            AddToDialogue(1007);
            AddToDialogue(1008);
            AddToDialogue(1009);
        }
        
        if (dialogueOptionID == 1010)
        {
            DialoguePlayback.DeleteLineID = 1010;

            AddToDialogue(1010);
            AddToDialogue(1011);
            AddToDialogue(1012);
        }

        if (dialogueOptionID == 1013)
        {
            DialoguePlayback.DeleteLineID = 1013;

            AddToDialogue(1013);
            AddToDialogue(1014);
            AddToDialogue(1015);
            AddToDialogue(1016);
        }

        if (dialogueOptionID == 1025)
        {
            DialoguePlayback.DeleteLineID = 1025;

            AddToDialogue(1025);
            AddToDialogue(1029);
            AddToDialogue(1030);
            AddToDialogue(1031);
        }

        if (dialogueOptionID == 1026)
        {
            DialoguePlayback.DeleteLineID = 1025;

            AddToDialogue(1026);
            AddToDialogue(1029);
            AddToDialogue(1030);
            AddToDialogue(1031);
        }

        if (dialogueOptionID == 1027)
        {
            DialoguePlayback.DeleteLineID = 1025;

            AddToDialogue(1027);
            AddToDialogue(1029);
            AddToDialogue(1030);
            AddToDialogue(1031);
        }

        if (dialogueOptionID == 1028)
        {
            DialoguePlayback.DeleteLineID = 1025;

            AddToDialogue(1028);
            AddToDialogue(1029);
            AddToDialogue(1030);
            AddToDialogue(1031);
        }

        if (dialogueOptionID == 1032)
        {
            DialoguePlayback.DeleteLineID = 1032;

            AddToDialogue(1032);
            AddToDialogue(1036);
            AddToDialogue(1037);
            AddToDialogue(1038);
            AddToDialogue(1039);
            AddToDialogue(1040);
            AddToDialogue(1041);
            AddToDialogue(1042);
        }

        if (dialogueOptionID == 1033)
        {
            DialoguePlayback.DeleteLineID = 1032;

            AddToDialogue(1033);
            AddToDialogue(1036);
            AddToDialogue(1037);
            AddToDialogue(1038);
            AddToDialogue(1039);
            AddToDialogue(1040);
            AddToDialogue(1041);
            AddToDialogue(1042);
        }

        if (dialogueOptionID == 1034)
        {
            DialoguePlayback.DeleteLineID = 1032;

            AddToDialogue(1034);
            AddToDialogue(1036);
            AddToDialogue(1037);
            AddToDialogue(1038);
            AddToDialogue(1039);
            AddToDialogue(1040);
            AddToDialogue(1041);
            AddToDialogue(1042);
        }

        if (dialogueOptionID == 1035)
        {
            DialoguePlayback.DeleteLineID = 1032;

            AddToDialogue(1035);
            AddToDialogue(1036);
            AddToDialogue(1037);
            AddToDialogue(1038);
            AddToDialogue(1039);
            AddToDialogue(1040);
            AddToDialogue(1041);
            AddToDialogue(1042);
        }

        if (dialogueOptionID == 1043)
        {
            DialoguePlayback.DeleteLineID = 1043;

            AddToDialogue(1043);
            AddToDialogue(1044);
            AddToDialogue(1045);
            AddToDialogue(1046);
            AddToDialogue(1047);
            AddToDialogue(1048);
            AddToDialogue(1049);
            AddToDialogue(1050);

            WorldEvents.BennyHasOfferedLute = true;
        }

        if (dialogueOptionID == 1055)
        {
            AddToDialogue(1055);
            AddToDialogue(1056);
            AddToDialogue(1057);
            AddToDialogue(1058);

            DialoguePlayback.EndingDialogue = true;
        }

        //if (dialogueOptionID == 1060)
        //{
        //    DialoguePlayback.DeleteLineID = 1060;

        //    AddToDialogue(1060);
        //}

        if (dialogueOptionID == 1061)
        {
            DialoguePlayback.DeleteLineID = 1061;
            AddToDialogue(1061);
            AddToDialogue(1062);
        }

        if (dialogueOptionID == 1063)
        {
            DialoguePlayback.DeleteLineID = 1063;
            
            AddToDialogue(1063);
            AddToDialogue(1064);
            AddToDialogue(1065);
            AddToDialogue(1066);

        }

        if (dialogueOptionID == 1067)
        {
            DialoguePlayback.DeleteLineID = 1067;
            DialoguePlayback.DeleteLineID = 1068;
            DialoguePlayback.DeleteLineID = 1069;
            DialoguePlayback.DeleteLineID = 1070;

            AddToDialogue(1067);
            AddToDialogue(1071);
            AddToDialogue(1072);
            AddToDialogue(1073);
        }

        if (dialogueOptionID == 1068)
        {
            DialoguePlayback.DeleteLineID = 1067;
            DialoguePlayback.DeleteLineID = 1068;
            DialoguePlayback.DeleteLineID = 1069;
            DialoguePlayback.DeleteLineID = 1070;

            AddToDialogue(1068);
            AddToDialogue(1071);
            AddToDialogue(1072);
            AddToDialogue(1073);
        }

        if (dialogueOptionID == 1069)
        {
            DialoguePlayback.DeleteLineID = 1067;
            DialoguePlayback.DeleteLineID = 1068;
            DialoguePlayback.DeleteLineID = 1069;
            DialoguePlayback.DeleteLineID = 1070;

            AddToDialogue(1069);
            AddToDialogue(1071);
            AddToDialogue(1072);
            AddToDialogue(1073);
        }

        if (dialogueOptionID == 1070)
        {
            DialoguePlayback.DeleteLineID = 1067;
            DialoguePlayback.DeleteLineID = 1068;
            DialoguePlayback.DeleteLineID = 1069;
            DialoguePlayback.DeleteLineID = 1070;

            AddToDialogue(1070);
            AddToDialogue(1071);
            AddToDialogue(1072);
            AddToDialogue(1073);
        }

        if (dialogueOptionID == 1074)
        {
            AddToDialogue(1074);
        }

        if (dialogueOptionID == 1075)
        {
            AddToDialogue(1075);
            AddToDialogue(1076);
            AddToDialogue(1077);
        }

        if (dialogueOptionID == 1078)
        {
            AddToDialogue(1078);
            AddToDialogue(1079);
        }

        if (dialogueOptionID == 1080)
        {
            AddToDialogue(1080);
            AddToDialogue(1081);
        }

        if (dialogueOptionID == 1082)
        {
            AddToDialogue(1082);
        }

        if (dialogueOptionID == 1094)
        {
            AddToDialogue(1094);
            AddToDialogue(1095);
        }

        if (dialogueOptionID == 1017)
        {
            AddToDialogue(1017);
            DialoguePlayback.EndingDialogue = true;   //bye benny
        }

    }

    private static void AddToDialogue(int dialogueID)
    {
        Debug.Log("Adding to dialogue: " + dialogueID);
        DialoguePlayback.AddToDialogue(dialogueID);
    }

    private bool IsLastBefore(int lastLine, int dialogueOptionID)
    {
        if (LastLinesBeforeOption[dialogueOptionID].Contains(lastLine))
            return true;

        return false;
    }
}
