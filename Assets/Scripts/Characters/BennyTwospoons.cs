using System.Collections.Generic;
using UnityEngine;

public class BennyTwospoons : MonoBehaviour
{
    public static int CharacterSituation;
    public static BennyTwospoons Instance;
    public Animator Animator;
 //   public SphereCollider ThisCollider;

    #region NPCTalkingIDs
    public static List<int> NPCTalkingIDs = new List<int>()
        {
            1001,
            1002,
            1004,
            1007,
            1009,
            1011,
            1012,
            1014,
            1016,
            1019,
            1021,
            1023,
            1024,
            1029,
            1030,
            1031,
            1036,
            1038,
            1040,
            1042,
            1044,
            1045,
            1047,
            1048,
            1050,
            1051,
            1053,
            1056,
            1058,
            1062,
            1064,
            1066,
            1071,
            1073,
            1077,
            1079,
            1081,
            1084,
            1086,
            1088,
            1089,
            1091,
            1092,
            1093,
            1095,
        };
    #endregion NPCTalkingIDs

    #region DialogueOptions

    public static Dictionary<int, string> DialogueOptions = new Dictionary<int, string>() 
    {
        {0, "0"},
        {1000, "Hello!"},
        {1003, "You don't happen to have a musical instrument, do you?"},
        {1006, "I see you found clothes to wear that form a nice addition to your store."},
        {1010, "So you are a clown?"},
        {1013, "You take your former profession still very seriously!"},
        {1017, "Bye Benny."},
        {1018, "Hey, is that a real lute that you got there?"},
        {1025, "I am a collector of instruments for the Outside-In Art Gallery. Your lute would greatly enhance our collection."},
        {1026, "I need a lute to play my devastating songs that will overthrow an evil conspiracy at the royal court!"},
        {1027, "I want to bring an ode to Olivia, my secret love. I need the lute to accompany me and obscure my failing voice."},
        {1028, "No, of course I don’t need this lute. But your lute might be infected by vicious woodworm. I love your shop and want to take the lute in order to prevent the worms from eating your precious costumes."},
        {1032, "You went to the forest and looked for the tallest tree."},
        {1033, "You made it entirely out of candy."},
        {1034, "You tried to make a violin, but instead you ended up with a lute."},
        {1035, "You used dark magic to give it soporific power."},
        {1043, "What do you want for this lute? Maybe we can make a deal."},
        {1054, "I'm back"},
        {1055, "I feel I'm getting closer to the Mask of Mockery!"},
        {1060, "About this mask..."},
        {1061, "Do you know anything about this Tear Collector person?"},
        {1063, "About this mask..."},
        {1067, "Apparently the king thinks I would hurt myself when going on a journey like this."},
        {1068, "Apparently the king is afraid that I would steal away all the ancient relics, putting a whole generation of adventurers out of business."},
        {1069, "Apparently the king is handing out obstruction quota's, giving every sentinel a fixed amount of people they have to stop before the end of "},
        {1070, "Apparently the king is testing the loyalty of his servants by giving them completely arbitrary orders."},
        {1074, "Maybe some of the articles in your shop can be of use…"},
        {1075, "Maybe I could use some of your sneeze powder?"},
        {1078, "Maybe one of your excellent costumes can help me convince the guard that I have come to relieve him from his post."},
        {1080, "That gorilla costume seems pretty mean, could I borrow it for a moment?"},
        {1082, "On second thought, I’m not sure how you could help me (return to main dialogue menu)"},
        {1083, "That sentinel was no match for me. He’s sleeping with the fishes."},
        {1087, "This will make your day: I found you The Mask Of Mockery."},
        {1094, "What did you say you want for this lute?"},

    };
    #endregion

    #region SpeakingLines
    public static Dictionary<int, string> SpeakingLines = new Dictionary<int, string>() 
    { 
        {1000, "Hello!"},/////////////////////////////
        {1001, "Hi there, I am Benny Twospoons and you are visiting party shop The Two Spoons."},
        {1002, "Here you can find any attribute you could ever want to start a party with: we have costumes, fake noses, masks, garlands, candles, balloons, ehh.. oh you know the drill."},
        {1003, "You don't happen to have a musical instrument, do you?"},
        {1004, "No. This is a party shop, boy. Well, I guess I have that old lute over there.."},
        {1005, "Oh that could be exactly what I need!"},
        {1006, "I see you found clothes to wear that form a nice addition to your store."},
        {1007, "To be honest, I wear these clothes also outside work hours. They are my outfit day and night."},
        {1008, "Ooh!"},
        {1009, "You see, I used to be a circus clown for many years. I think this line of work thoroughly affects you. Once a clown, forever a clown... always."},
        {1010, "So you're a clown?"},
        {1011, "I used to work at the Jolly Fair. Even though those days are not over, I am still a clown by heart."},
        {1012, "And that’s not all: I might not be performing anymore, but I still want to reach out to my fellow buffoons and support their cause. Especially in these dark days clowns are very important."},
        {1013, "You take your former profession still very seriously!"},
        {1014, "Of course I do! Those were my best years. Success smiled upon me. The audience knew how to value my clownsmanship."},
        {1015, "What happened?"},
        {1016, "Och, didn’t you know that the Jolly Fair went bankrupt a long time ago? With the public, we clowns abandoned the place as well. "},
        {1017, "Bye Benny"},
        {1018, "Hey, is that a real lute that you got there?"},
        {1019, "That thing? Of course boy, never seen one before?"},
        {1020, "I mean, is it playable?"},
        {1021, "What do you mean is it playable? It's a lute, isn't it?"},
        {1022, "Oh that could be exactly what I need!"},
        {1023, "You need a lute? Honestly, that thing is just getting in the way. I guess you can take it if you want to."},
        {1923, "That is such good news! I feared I wouldn't be able to find a musical instrument"},
        {1024, "Wait a minute, what do you need this lute for?"},
        {1025, "I am a collector of instruments for the Outside-In Art Gallery. Your lute would greatly enhance our collection."},
        {1026, "I need a lute to play my devestating songs that will overthrow an evil conspiracy at the Royal Court!"},
        {1027, "I want to bring an ode to Olivia, my secret love. I need the lute to accompany me and obscure my failing voice."},
        {1028, "No, of course I don’t need this lute. But your lute might be infected by vicious woodworm. I love your shop and want to take the lute in order to prevent the worms from eating your precious costumes. "},
        {1029, "Oh.. well.. in that case… Unfortunately I can’t give it to you. The lute. It is special to me. You see, when I just started down at the Jolly Fair, I was a young clown with no act. All the bigger clowns made fun of me. "},
        {1030, "As they were professional comedians, you can imagine how their clever jokes were hurting me. I decided I needed to add a special feature to my show that could amaze them. A song and dance act that would impress everyone."},
        {1031, "It was therefore that I started manufacturing this very instrument, single-handedly. You’ll never believe how I made it."},
        {1032, "You went to the forest and looked for the tallest tree."},
        {1033, "You made it entirely out of candy."},
        {1034, "You tried to make a violin, but instead you ended up with a lute."},
        {1035, "You used dark magic to give it soporific power."},
        {1036, "No, I went to the forest and looked for the tallest tree. And from this giant’s timber, I sawed long, mighty planks. Twelve feet, these beauties were!"},
        {1037, "Why was it necessary to have this kind of planks for a simple lute?"},
        {1038, "I am a clown, Emmon. I use these gimmicks to perform my arts."},
        {1039, "But this lute seems to be rather normally sized."},
        {1040, "Well… it just must have gotten smaller or something. You know how these things erode over time?"},
        {1041, "I don’t believe a word you are saying."},
        {1042, "Well, I am not giving the lute away for easy anyway. Benny wants something good in return."},
        {1043, "What do you want for this lute? Maybe we can make a deal."},
        {1044, "As you can see, my clown shop is near perfection. Rarely so much fun was brought together in one place."},
        {1045, "However, lately I have heard about an item, which is missing from my collection, that can make me a lot of money - I mean, an article that would refine this place as a house of fun."},
        {1046, "Tell me more."},
        {1047, "It is called the Mask of Mockery. A mask with an insultingly mocking smile. Imagine the face of unsuspecting customers when they see me, wearing this tremendous mask. It will baffle them!"},
        {1048, "Unfortunately the Mask of Mockery has been long lost. It is said the last wearer of the mask put it on and disappeared in the wilderness. But I am sure that it must be somewhere close!"},
        {1049, "I will find this mask for you if you give me that lute in return!"},
        {1050, "I like the sound of that."},
        {1051, "Hi."},
        {1052, "Hi!"},
        {1053, "Hi.."},
        {1054, "I'm back!"},
        {1055, "I feel I'm getting closer to the Mask of Mockery!"},
        {1056, "Are you?"},
        {1057, "I have been talking to your friend from the Tear Collector shop and he says the Mask of Mockery can be found in an ancient temple in the nearby valley."},
        {1058, "You better go get it then, boy."},
        {1059, "I guess I will!"},
        {1060, "About this mask..."},
        {1061, "Do you know anything about this Tear Collector person?"},
        {1062, "The Tear Collector? Oh don’t get me started. His lust for tears has spoiled many of my best jokes. Bad company at birthdays."},
        {1063, "About this mask..."},
        {1064, "Yes, the mask. Did you bring it?"},
        {1065, "There seems to be a slight problem… There is this royal sentinel you see, he doesn't want to let me pass.."},
        {1066, "You mean Wally the Watcher? He never makes any trouble. The king must have a good reason for keeping you here in town."},
        {1067, "Apparently the king thinks I would hurt myself when going on a journey like this."},
        {1068, "Apparently the king is afraid that I would steal away all the ancient relics, putting a whole generation of adventurers out of business."},
        {1069, "Apparently the king is handing out obstruction quotas, giving every sentinel a fixed amount of people they have to stop before the end of the month."},
        {1070, "Apparently the king is testing the loyalty of his servants by giving them completely arbitrary orders."},
        {1071, "Well, he must be very happy to finally have something to do. He always looks so bored."},
        {1072, "That does not help me though! Benny, if you sincerely want this mask of yours, please help me."},
        {1073, "What do you want me to do? I might have the laugh on my side, thanks to my excellent jokes, but I am no match for a full armed guardsman."},
        {1074, "Maybe some of the articles in your shop can be of use…"},
        {1075, "Maybe I could use some of your sneeze powder?"},
        {1076, "If Wally is sneezing I might just be able to sneak past him."},
        {1077, "You think make a royal guard sneeze is going to help you? I tell you, you don’t want to anger a guardsman of the king!"},
        {1078, "Maybe one of your excellent costumes can help me convince the guard that I have come to relieve him from his post."},
        {1079, "We are a joke shop sir, not a couture!"},
        {1080, "That gorilla costume seems pretty mean, could I borrow it for a moment?"},
        {1081, "I’m sorry, but I promised that costume to the Duke of Prunes. He wanted to use it for the graduation party of his son."},
        {1082, "On second thought, I’m not sure how you could help me "},
        {1083, "That sentinel was no match for me. He’s sleeping with the fishes."},
        {1084, "Good. Very good. But, did you find the mask?"},
        {1085, "As you know, in Baton nothing goes without a hitch. There are still some things I have to work out. "},
        {1086, "What are you waiting for then? Go back and find me that mask, you rascal!"},
        {1087, "This will make your day: I found you The Mask Of Mockery."},
        {1088, "Oh that is very good news indeed! You made a clown smile."},
        {1089, "And now, in order to complete the Mockery set, you will only have to find me the legendary Cloak of Mockery! I heard it is located in a gloomy swamp in the East and…"},
        {1090, "Benny stop joking around! I had to climb perilous mountains and drink gruesome potions to get the mask! Now give me the lute!"},
        {1091, "Argh, you win. I’ll give up the stupid lute alright. But let me warn you. If you believe that climbing a hill or taking hallucinogenic drugs is something to be proud of, you are a real rookie."},
        {1092, "I wandered about here for 55 years already and I can assure you: today you are struggling to get a lute, tomorrow you will get to deal with much more serious things,"},
        {1093, "And on your path you will encounter enemies that are going to make you long for that ludicrous sentinel again!"},
        {1094, "What did you say you want for this lute?"},
        {1095, "Maybe you can find me the precious Mask of Mockery to complete my clown shop."},

    };


    #endregion

    public void Start()
    {
        Instance = this;
 //       ThisCollider = GetComponent<SphereCollider>();
  //      ThisCollider.isTrigger = true;
        Animator = GetComponentInChildren<Animator>();
    }

    public void StartDialogue()
    {
     //   Animator.SetBool("DialogueState", true);

    //    TimeManager.NPCDialogueZoek = true;

        DialogueManager.StartDialogueState(NPCEnum.NPCs.BennyTwospoons);
    }

    //public void OnTriggerExit(Collider other)
    //{
    //    Animator.SetBool("DialogueState", false);
    //    Animator.SetBool("Talking", false);
    //    Animator.SetBool("Listening", false);

    //    DialogueManager.EndDialogueState();
    //}

    public void DialogueLineNumberToSituation(int lastLineID)   //the last line of dialogue determines which situation will follow
    {
        var characterSituation = CharacterSituation;
        if (!WorldEvents.EmmonSawTheLute && (lastLineID == 1002 || lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016 || lastLineID == 1054))
        {
            DialogueMenu.AddToDialogueOptions(1003);
        }

        if (lastLineID == 1002 || lastLineID == 1005 || lastLineID == 1042 || lastLineID == 1050 || lastLineID == 1054 || lastLineID == 1059 || lastLineID == 1062 || lastLineID == 1082 || lastLineID == 1095)
        {
            DialogueMenu.AddToDialogueOptions(1006);
        }

        if (DialogueOptions[1006] == "" &&
            (lastLineID == 1009 || lastLineID == 1009 || lastLineID == 1042 || lastLineID == 1050 || lastLineID == 1054 || lastLineID == 1059 || lastLineID == 1062 || lastLineID == 1082 || lastLineID == 1095))
        {
            DialogueMenu.AddToDialogueOptions(1010);
        }

        if (DialogueOptions[1010] == "" &&
            (lastLineID == 1012 || lastLineID == 1042 || lastLineID == 1050 || lastLineID == 1059 || lastLineID == 1054 || lastLineID == 1062 || lastLineID == 1082 || lastLineID == 1095))
        {
            DialogueMenu.AddToDialogueOptions(1013);
        }

        if (DialogueOptions[1018] == "" && (lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016))
        {
            DialogueMenu.AddToDialogueOptions(1018);
        }

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

        if ((DialogueOptions[1032] == "" || DialogueOptions[1033] == "" || DialogueOptions[1034] == "" || DialogueOptions[1035] == "") &&
            (lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016 || lastLineID == 1042 || lastLineID == 1054 || lastLineID == 1062))
        {
            DialogueMenu.AddToDialogueOptions(1043);
        }

        if (characterSituation > 2 && (lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016 || lastLineID == 1054 || lastLineID == 1062 || lastLineID == 1073 || lastLineID == 1082)) //I feel I'm getting closer to the Mask of Mockery!
        {
            DialogueMenu.AddToDialogueOptions(1055);
        }

        if (WorldEvents.EmmonKnowsAy == true && characterSituation > 2 && 
            (lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016 || lastLineID == 1042 || lastLineID == 1054 || lastLineID == 1059 || lastLineID == 1073 || lastLineID == 1082 || lastLineID == 1095))     //tear collector person
        {
            DialogueMenu.AddToDialogueOptions(1061);
        }

        if (characterSituation == 4 && (lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016 || lastLineID == 1054 || lastLineID == 1062)
            && DialogueOptions[1063] == "") ////about this mask
        {
            DialogueMenu.AddToDialogueOptions(1063);
        }

        if (lastLineID == 1066)
        {
            DialogueMenu.AddToDialogueOptions(1067);
            DialogueMenu.AddToDialogueOptions(1068);
            DialogueMenu.AddToDialogueOptions(1069);
            DialogueMenu.AddToDialogueOptions(1070);
        }

        if ((DialogueOptions[1067] == "" || DialogueOptions[1068] == "" || DialogueOptions[1069] == "" || DialogueOptions[1070] == "") &&
            (lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016 || lastLineID == 1054 || lastLineID == 1062 || lastLineID == 1073 || lastLineID == 1082))
        {
            DialogueMenu.AddToDialogueOptions(1074);
        }

        if (lastLineID == 1074 || lastLineID == 1077 || lastLineID == 1079 || lastLineID == 1081)
        {
            DialogueMenu.AddToDialogueOptions(1075);
        }

        if (lastLineID == 1074 || lastLineID == 1077 || lastLineID == 1079 || lastLineID == 1081)
        {
            DialogueMenu.AddToDialogueOptions(1078);
        }

        if (lastLineID == 1074 || lastLineID == 1077 || lastLineID == 1079 || lastLineID == 1081)
        {
            DialogueMenu.AddToDialogueOptions(1080);
        }

        if (lastLineID == 1074 || lastLineID == 1077 || lastLineID == 1079 || lastLineID == 1081)
        {
            DialogueMenu.AddToDialogueOptions(1082);
        }

        if (DialogueOptions[1043] == "" && characterSituation < 4 && (lastLineID == 1005 || lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016 || lastLineID == 1050 || lastLineID == 1054 || lastLineID == 1062 || lastLineID == 1073 || lastLineID == 1082 || lastLineID == 1095))
        {
            DialogueMenu.AddToDialogueOptions(1094);
        }

        if (lastLineID == 1002 || lastLineID == 1005 || lastLineID == 1009 || lastLineID == 1012 || lastLineID == 1016 || lastLineID == 1042 || lastLineID == 1050 || lastLineID == 1054 || lastLineID == 1062 || lastLineID == 1073 || lastLineID == 1082 || lastLineID == 1095)
        {
            DialogueMenu.AddToDialogueOptions(1017);    //exit option
        }

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
                    
                    DialoguePlayback.Instance.PlaybackDialogue(1000);
                }
                else // hi , hi , hi
                {
                    AddToDialogue(1051);
                    AddToDialogue(1052);
                    AddToDialogue(1053);
                    AddToDialogue(1054);
                    DialoguePlayback.Instance.PlaybackDialogue(1054);
                }
                break;
            case 2: //SITUATION 2 EmmonSeesTheLute

                DialoguePlayback.DeleteLineID = 1018;

                AddToDialogue(1018);
                AddToDialogue(1019);
                AddToDialogue(1020);
                AddToDialogue(1021);
                AddToDialogue(1022);
                AddToDialogue(1023);
                AddToDialogue(1923);
                AddToDialogue(1024);

                WorldEvents.EmmonKnowsBenny = true;
                MouseClickOnObject.ObjectLines[ObjectsInLevel.BennyTwospoons] = "Ex-clown Benny Twospoons";        

                ObjectCommentary.AskingLute = false;
                DialoguePlayback.Instance.PlaybackDialogue(1018);

                CharacterControllerLogic.Instance.ForceTurningAngle(0);
                TimeManager.Instance.CreateRotator(GameManager.Player.transform, this.transform, 2f, 3f);

                break;
            case 3://I'm back but EmmonKnowsMaskLocation
                AddToDialogue(1051);
                AddToDialogue(1052);
                AddToDialogue(1053);
                AddToDialogue(1054);
                DialoguePlayback.Instance.PlaybackDialogue(1054);
                break;
            case 4: //I'm back but EmmonWasBlockedBySentinel
                AddToDialogue(1051);
                AddToDialogue(1052);
                AddToDialogue(1053);
                AddToDialogue(1054);
                DialoguePlayback.Instance.PlaybackDialogue(1054);
                break;
            case 5: // That sentinel was no match for me. He’s sleeping with the fishes.
                AddToDialogue(1083);
                AddToDialogue(1084);
                AddToDialogue(1085);
                AddToDialogue(1086);
                DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogue(1083);
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
                DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogue(1087);
                break;
            case 999:
                DialogueMenu.FindDialogueOptionText();
                break;

            default: //in all other dialogue options
                DialogueMenu.FindDialogueOptionText();
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

        if (dialogueOptionID == 1060)
        {
            DialoguePlayback.DeleteLineID = 1060;

            AddToDialogue(1060);
        }

        if (dialogueOptionID == 1061)
        {
            DialoguePlayback.DeleteLineID = 1061;
            AddToDialogue(1061);
            AddToDialogue(1062);
        }

        if (dialogueOptionID == 1063)
        {
            AddToDialogue(1063);
            AddToDialogue(1064);
            AddToDialogue(1065);
            AddToDialogue(1066);

            DialoguePlayback.DeleteLineID = 1063;
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
}
