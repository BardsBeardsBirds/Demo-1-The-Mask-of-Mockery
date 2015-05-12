using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AyTheTearCollector : MonoBehaviour 
{
    public static int CharacterSituation = 1;
    public static AyTheTearCollector Instance;
    public Animator Animator;

    #region NPCTalkingIDs
    public static List<int> NPCTalkingIDs = new List<int>()
        {
            2005,
            2007,
            2009,
            2011,
            2013,
            2015,
            2017,
            2019,
            2021,
            2023,
            2025,
            2027,
            2028,
            2030,
            2031,
            2033,
            2034,
            2035,
            2036,
            2039,
            2041,
            2043,
            2045,
            2047,
            2049,
            2050,
            2051,
            2053,
            2054,
            2055,
            2057,
            2059,
            2060,
            2061,
            2062,
            2063,
            2066,
            2069,
            2071,
            2073,
            2075,
            2077,
            2078,
            2080,
            2082,
            2084,
            2087,
            2089,
            2091,
            2093,
            2095,
            2097,
            2098,
            2100,
            2101,
            2103,
            2104,
            2106,
            2108,
            2110,
            2113,
            2115,
            2117,
            2119,
            2121,
            2125,
        };
    #endregion NPCTalkingIDs

    #region DialogueOptions

    public static Dictionary<int, string> DialogueOptions = new Dictionary<int, string>() 
    {
        {0, "0"},
        {2001, "I am Emmon, bard of the Seven Kingdoms. I came to confiscate all your quiet moments!"},
        {2002, "Hi there, I am Emmon, the musical hero of this story!"},
        {2003, "Hello, my name is Emmon Tumblescream and I am new in town!"},
        {2004, "Hark and behold, here is a formidable man on a mission!"},
        {2014, "Do you want me to sing?"},
        {2026, "How did you lock yourself out of your shop?"},
        {2032, "Tear collector shop?"},
        {2038, "Keep your ears peeled, for I am going to sing!"},
        {2040, "I once sang at the Royal Palace. It made a lasting impression…"},
        {2042, "If you don’t give me the lute, I might accidentally hum a melody!"},
        {2044, "La.. la.. la.. "},
        {2046, "Do you know Benny Twospoons?"},
        {2065, "Where did you say that I can find the mask?"},
        {2068, "I don’t have the mask…"},
        {2079, "Can you not give it to me for free? We are friends now, right?"},
        {2081, "How much is it?"},
        {2083, "40 rupee is too much."},
        {2085, "Alright I want to buy your potion."},
        {2087, "That is not enough. Ay, I am sorry."},
        {2090, "If you give me the Roughneck Shot, I will reward you with a free massage."},
        {2096, "If you give me the Roughneck shot, you don’t have to reward me with the lute later on. I will get you the Mask of Mockery for free."},
        {2099, "Please Ay, don’t you see how disappointed I am? I love dangerous quests, but quests that fail make me sad. :("},
        {2102, "Think about all the things you can do with the mask once I find it for you!"},
        {2111, "You know what, let's talk about something else."},
        {2122, "I suddenly feel a great urge to go stand over there. Bye."},
        {2112, "Thanks for the potion, chief. I feel like I can compete with the heroes of our time!"},
        {2114, "So, I got the mask. Thanks, you helped me a lot."},
        {2120, "I am having such a great time with the mask, Ay. I occasionally wear it at parties."},
        {2123, "I am back! Rejoice!"},
        {2124, "Can you give me the roughneck shot?"},

    };
    #endregion

    #region SpeakingLines
    public static Dictionary<int, string> SpeakingLines = new Dictionary<int, string>() 
    { 
        {2001, "I am Emmon, bard of the Seven Kingdoms. I came to confiscate all your quiet moments!"},
        {2002, "Hi there, I am Emmon, the musical hero of this story!"},
        {2003, "Hello, my name is Emmon Tumblescream and I am new in town!"},
        {2004, "Hark and behold, here is a formidable man on a mission!"},
        {2005, "It is a pleasure to meet you. Ay!"},
        {2006, "Ay!"},
        {2007, "Yes?"},
        {2008, "Eh… I do not understand the way this conversation is going."},
        {2009, "Me neither. Let me start over: pleased to meet you. My name is Ay."},
        {2010, "Ah, now I get it. Pleased to meet you, Lord Ay."},
        {2011, "Aye!"},
        {2012, "No, you’re Ay!"},
        {2013, "Don’t be ridiculous, boy. Anyway… So, you’re a bard. Hmm. The first time I encounter a bard… I must admit, I imagined you would be less… tall.  You’re not going to sing, are you? "},
        {2014, "Do you want me to sing? "},
        {2015, "NO! By the ancient swamp dragon, don’t sing."},
        {2016, "I was not planning to.  I have more urgent things to do."},
        {2017, "What kind of things?"},
        {2018, "I’m looking for a lute. Do you happen to own a lute?"},
        {2019, "A LUTE?? Actuality, I do own a lute. But unfortunately I cannot give it to you right now."},
        {2020, "Why not, if I may ask? I mean, you don’t seem busy. What exactly are you doing at the moment?"},
        {2021, "What does it looks like I’m doing? I’m practicing the profession of being a Dark Lord. These mortals can be so silly sometimes. "},
        {2022, "Eh.. yes, I can see that, your Lordship. You are very… sinister and mysterious and all, but what I meant was: why are you practicing the profession of being a Dark Lord out on the street?"},
        {2023, "What do you mean ‘out on the street’?"},
        {2024, "Well, you are sitting on the doorstep before this… eh… mansion. To be honest, that seems a little odd for a wizard of your stature. "},
        {2025, "By the whiskers of Lazar Wichshard, you are right! The thing is, something terrible happened: I locked myself out of my tear collector shop."},
        {2026, "How did you lock yourself out of your shop?"},
        {2027, "I was busy categorizing my tears, when suddenly I thought I heard somebody cry outside.  You must know that I always desperately desire tears, and obviously, crying means tears."},
        {2028, "So I went outside, where I was confronted with two major disasters. First, there was nobody crying. Second, I realized I locked the door behind me, but left my keys inside what you prefer to call my mansion! "},
        {2029, "Ah, I see. That is an annoying... I mean terrible situation indeed! Can I perhaps help you to get inside your house again?"},
        {2030, "Nothing, there is nothing you can do! Don’t you see? If a powerful magician is not able to enter his own house, how can an ordinary human being ever help him? "},
        {2031, "You’re a bard for pity’s sake. Get lost boy. Let me concentrate on my misfortune."},
        {2032, "Tear collector shop?"},
        {2033, "Yes. It is a shop where I... No wait. I wrote a poem about it. I will read it to you."},
        {2034, "Tears of pleasure, tears of pain, are not so easy to obtain,"},
        {2035, "Tears of boredom, tears of hate, when you cry, I cannot wait,"},
        {2036, "I collect the tears you drop, That is why I own this shop."},
        {2037, "I see."},
        {2038, "Keep your ears peeled, for I am going to sing!"},
        {2039, "My dark lord’s vow forbids me to listen to such worldly matters, leave me out of this!"},
        {2040, "I once sang at the Royal Palace. It made a lasting impression…"},
        {2041, "Please! We don’t want to repeat that pandemonium!"},
        {2042, "If you don’t give me the lute, I might accidentally hum a melody!"},
        {2043, "If you don’t control yourself, I might accidentally hit you with this stick."},
        {2044, "La.. la.. la.."},
        {2045, "What was that..?!"},
        {2046, "Do you know Benny Twospoons?"},
        {2047, "That clown that has his shop across the street? Of course! He is nothing but trouble for me. You can imagine a jokester like him works against my… tear trade efficiency."},
        {2048, "He told me about some Mask of Mockery. He is willing to trade his lute for that mask."},
        {2049, "The Mask of Mockery?? That mask is part of the Three Masks of Displeasure. "},
        {2050, "There are the Mask of Mockery, the Hood of Apathy and the Guise of Cynicism. The last two I already got a hold of. "},
        {2051, "I desire that mask more than anything in the world – except for tears. Don’t give it to the clown. Give it to me! Ay!"},
        {2052, "Do you perhaps know where it is located?"},
        {2053, "I do! The Singing Dragon knows I do! However, I never have been able to overcome the various horrific obstacles that anyone who wants to acquire the mask has to deal with…"},
        {2054, "But I know something, maybe you are capable to overcome the obstacles. Like I said: I never met a bard. Perhaps your species will surprise me. "},
        {2055, "I will tell you where to find the Mask of Mockery. Bring me the mask and I will reward you handsomely."},
        {2056, "Twospoons offered me a lute. What do you offer me? "},
        {2057, "I told you I own a lute too. A very nice one. With strings made out of gallow rope. When I’m able to enter my shop again I will give it to you. We’ll figure something out."},
        {2058, "Okay, tell me where to find the mask."},
        {2059, "Oh finding the Mask of Mockery won’t be easy. In fact, I have written something on this. Let’s see.. hm.."},
        {2060, "Take the road out of the village, it’s the valley  we seek, The journey is risky: thou must not be weak,"},
        {2061, "Walk straight to the valley, be persistent and brave, Just climb up the hill and get into the cave,"},
        {2062, "Thou will find a platform with a transportation device, Get to the temple, the stronghold of the wise,"},
        {2063, "Open the gate where thou shalt find the mask, Bring it back to me  and.. well, that’s the end of your task - I mean THY task."},
        {2064, "Valley, cave, platform. Got it. "},
        {2065, "Where did you say that I can find the mask?"},
        {2066, "That poem is supposed to help you remember!"},
        {2067, "Oh wait, there was a valley, a cave and then a platform to the temple. I remember now."},
        {2068, "I don’t have the mask…"},
        {2069, "By the God of Fire! Why not?"},
        {2070, "Because I came across a very tight-fisted sentinel."},
        {2071, "Argh, that was not in my poem! Still… I’m afraid I know of whom you are speaking. Were you not able to convince this watcher to let you pass?"},
        {2072, "No. He seemed not to be impressed by my appearance in any way."},
        {2073, "Hmmm, I guess I know what you need to persuade him."},
        {2074, "And what would that be?"},
        {2075, "A Roughneck shot."},
        {2076, "A what?"},
        {2077, "A special potion that makes your level of toughness rise to an absolute maximum. When you drink it, I’m sure you will have no troubles convincing the sentinel – ‘cause you’ll be so excessively tough and all… "},
        {2078, "I know how to brew a Roughneck shot and always carry some with me. I can sell it to you if you want!"},
        {2079, "Can you not give it to me for free? We are friends now, right?"},
        {2080, "No, that is not an option, mister bard. We may be friends, and I may be a Dark Lord and a collector of tears, but I am also a merchant!"},
        {2081, "How much is it?"},
        {2082, "40 rupee."},
        {2083, "40 rupee is too much."},
        {2084, "That depends on how desperate you are."},
        {2085, "Alright I want to buy your potion."},
        {2086, "Oops, I am not that rich."},
        {2087, "That is not enough. Ay, I am sorry."},
        {2088, "Hey, I paid you! I was going to get the mask for you! Without a Roughneck shot, there will be no mask."},
        {2089, "Well, there was an 80 percent chance you would die during your journey to the mask, anyway. I cannot risk giving you the Roughneck shot for free and afterwards never see you again."},
        {2090, "If you give me the Roughneck Shot, I will reward you with a free massage."},
        {2091, "That actually sounds like a pretty good deal. I… But wait a minute. Are you a qualified masseur?"},
        {2092, "Yes."},
        {2093, "Show me your diploma!"},
        {2094, "It accidently fell in a well."},
        {2095, "Forget it. The deal is off."},
        {2096, "If you give me the Roughneck shot, you don’t have to reward me with the lute later on. I will get you the Mask of Mockery for free."},
        {2097, "Hmm. That sounds suspicious. Why would you fulfil such a dangerous quest without any reward?"},
        {2098, "I’m starting to think that you want to acquire the mask for your own benefit, and that you are not planning to give it to me at all!"},
        {2099, "Please Ay, don’t you see how disappointed I am? I really wanted to find that mask for you! You see, I love dangerous quests, but quests that fail make me sad. :("},
        {2100, "Your emotions don’t affect me at all: you forgot about my pact with the Forces of Evil."},
        {2101, "I never feel sorry for someone and I never get sentimental. That’s why I haven’t been able to collect my own tears, but that’s a whole nother story.."},
        {2102, "Think about all the things you can do with the mask once I find it for you!"},
        {2103, "Hmmm. Let me see. I already have Apathy and Cynicism. Once I possess the Mask of Mockery as well, I can get access to everlasting wisdom."},
        {2104, "This would make me the wisest and most powerful wizard of…well, at least of this block."},
        {2105, "I don’t know what you’re talking about, but being a powerful wizard sounds splendid. Give me a Roughneck shot and I will make it happen!"},
        {2106, "I’m still not convinced…"},
        {2107, "Only a tiny sip."},
        {2108, "Well, a real tiny one then. Because frankly I’m starting to like you… in a peculiar way. You are lucky I have a small bottle here with me. Most of my concoctions are locked inside my house. There you go."},
        {2109, "Thank you, your Lordship. You will not regret this."},
        {2110, "Get lost, before I change my mind, by the Great Builders."},
        {2111, "You know what, let's talk about something else."},
        {2112, "Thanks for the potion, chief. I feel like I can compete with the heroes of our time!"},
        {2113, "Don’t forget that once the effects of the potion wear off, you will be a pathetic minstrel again."},
        {2114, "So, I got the mask. Thanks, you helped me a lot."},
        {2115, "Ah good good, if only I could get into my shop to get the lute for you.."},
        {2116, "Do you have the key?"},
        {2117, "No."},
        {2118, "So. See you later then."},
        {2119, "No, wait..!"},
        {2120, "I am having such a great time with the mask, Ay. I occasionally wear it at parties."},
        {2121, "Arggh."},
        {2122, "I suddenly feel a great urge to go stand over there. Bye."},
        {2123, "I am back! Rejoice!"},
        {2124, "Can you give me the roughneck shot?"},
        {2125, "You can buy it."},
    };
    #endregion

	void Start () 
    {
        Instance = this;

        Animator = GetComponentInChildren<Animator>();
	}

    public void StartDialogue()
    {
    //    Animator.SetBool("DialogueState", true);

        DialogueManager.StartDialogueState(NPCEnum.NPCs.AyTheTearCollector);
    }

    public void DialogueLineNumberToSituation(int lastLineID)   //the last line of dialogue determines which situation will follow
    {
        int characterSituation = CharacterSituation;

        if ((lastLineID == 2013 || lastLineID == 2023 || lastLineID == 2123 || lastLineID == 2064 || lastLineID == 2067) &&
            (characterSituation < 5))
        {
            DialogueMenu.AddToDialogueOptions(2014);
        }

        if ((lastLineID == 2025 || lastLineID == 2123 || lastLineID == 2039 || lastLineID == 2041 || lastLineID == 2043 || lastLineID == 2045 || lastLineID == 2064 || lastLineID == 2067 || lastLineID == 2111 || lastLineID == 2123) &&
            (characterSituation < 5) &&
            DialogueOptions[2014] == "")
        {
            DialogueMenu.AddToDialogueOptions(2026);
        }

        if ((lastLineID == 2031 || lastLineID == 2123 || lastLineID == 2039 || lastLineID == 2041 || lastLineID == 2043 || lastLineID == 2045 || lastLineID == 2064 || lastLineID == 2067 || lastLineID == 2111 || lastLineID == 2123) &&
            (characterSituation < 5) && DialogueOptions[2026] == "")
        {
            DialogueMenu.AddToDialogueOptions(2032);    //tear collector shop?
        }

        if ((lastLineID == 2025 || lastLineID == 2031 || lastLineID == 2037 || lastLineID == 2064 || lastLineID == 2067 || lastLineID == 2110 || lastLineID == 2111 || lastLineID == 2123) &&
            (characterSituation < 5) &&
            DialogueOptions[2014] == "")
        {
            DialogueMenu.AddToDialogueOptions(2038);
        }

        if ((lastLineID == 2025 || lastLineID == 2031 || lastLineID == 2037 || lastLineID == 2039 || lastLineID == 2064 || lastLineID == 2067 || lastLineID == 2111 || lastLineID == 2123) &&
            (characterSituation < 5) &&
            DialogueOptions[2038] == "")
        {
            Debug.LogWarning("gimme " + DialogueOptions[2038]);
            DialogueMenu.AddToDialogueOptions(2040);
        }

        if ((lastLineID == 2025 || lastLineID == 2031 || lastLineID == 2037 || lastLineID == 2041 || lastLineID == 2064 || lastLineID == 2067 || lastLineID == 2111 || lastLineID == 2123) &&
            (characterSituation < 5) &&
            DialogueOptions[2040] == "")
        {
            DialogueMenu.AddToDialogueOptions(2042);
        }

        if ((lastLineID == 2025 || lastLineID == 2031 || lastLineID == 2037 || lastLineID == 2043 || lastLineID == 2045 || lastLineID == 2064 || lastLineID == 2067 || lastLineID == 2111 || lastLineID == 2123) &&
            (characterSituation < 5) &&
            DialogueOptions[2042] == "")
        {
            DialogueMenu.AddToDialogueOptions(2044);
        }

        if ((lastLineID == 2013 || lastLineID == 2031 || lastLineID == 2037 || lastLineID == 2039 || lastLineID == 2041 || lastLineID == 2043 || lastLineID == 2045 || lastLineID == 2123) &&
            (characterSituation < 5) &&
            WorldEvents.BennyHasOfferedLute == true)
        {
            DialogueMenu.AddToDialogueOptions(2046);
        }

        if ((lastLineID == 2013 || lastLineID == 2031 || lastLineID == 2037 || lastLineID == 2039 || lastLineID == 2041 || lastLineID == 2043 || lastLineID == 2045 || lastLineID == 2064 || lastLineID == 2067 || lastLineID == 2123) &&
            (characterSituation < 5) &&
            DialogueOptions[2046] == "")
        {
            DialogueMenu.AddToDialogueOptions(2065);
        }

        if (lastLineID == 2078 || lastLineID == 2084 || lastLineID == 2086 || lastLineID == 2089 || lastLineID == 2095 || lastLineID == 2098 || lastLineID == 2101 || lastLineID == 2125)
        {
            DialogueMenu.AddToDialogueOptions(2079);
        }

        if (lastLineID == 2078 || lastLineID == 2080 || lastLineID == 2095 || lastLineID == 2098 || lastLineID == 2101 || lastLineID == 2125)
        {
            DialogueMenu.AddToDialogueOptions(2081); //How much is it?
        }

        if (lastLineID == 2089)
        {
            DialogueOptions[2081] = "";
        }

        if (lastLineID == 2082)
        {
            DialogueMenu.AddToDialogueOptions(2083);    //40 rupee is too much
        }

        if (lastLineID == 2082 || 
            lastLineID == 2124)
        {
            DialogueMenu.AddToDialogueOptions(2085);    //alright I want to buy your potion
        }

        if ((DialogueOptions[2079] == "") && 
            lastLineID == 2078 || lastLineID == 2080 || lastLineID == 2084 || lastLineID == 2086 || lastLineID == 2089 || lastLineID == 2095 || lastLineID == 2098 || lastLineID == 2101 || lastLineID == 2125)
        {
            DialogueMenu.AddToDialogueOptions(2090);    // free massage
        }

        if ((DialogueOptions[2079] == "" || DialogueOptions[2090] == "" || DialogueOptions[2099] == "")
            && (lastLineID == 2080 || lastLineID == 2084 || lastLineID == 2089 || lastLineID == 2095 || lastLineID == 2101 || lastLineID == 2125))
        {
            DialogueMenu.AddToDialogueOptions(2096);  //If you give me the Roughneck shot, you don’t have to reward me with the lute later on.
        }

        if ((DialogueOptions[2079] == "" && DialogueOptions[2090] == "") &&
            (lastLineID == 2084 || lastLineID == 2086 || lastLineID == 2089 || lastLineID == 2095 || lastLineID == 2098 || lastLineID == 2125))
        {
            DialogueMenu.AddToDialogueOptions(2099);    // don't you see how disappointed I am?
        }

        if (
            ((DialogueOptions[2079] == "" && DialogueOptions[2087] == "") ||
            (DialogueOptions[2079] == "") ||
            (DialogueOptions[2079] == "" && DialogueOptions[2085] == "") ||
            (DialogueOptions[2079] == "" && DialogueOptions[2096] == "") ||
            (DialogueOptions[2079] == "" && DialogueOptions[2099] == "") ||
            (DialogueOptions[2079] == "" && DialogueOptions[2090] == "") ||
            (DialogueOptions[2087] == "") ||
            (DialogueOptions[2090] == "") ||
            (DialogueOptions[2096] == "") ||
            (DialogueOptions[2099] == "") ||
            (DialogueOptions[2085] == "" && DialogueOptions[2087] == "") ||
            (DialogueOptions[2085] == "" && DialogueOptions[2090] == "") ||
            (DialogueOptions[2085] == "" && DialogueOptions[2096] == "") ||
            (DialogueOptions[2090] == "" && DialogueOptions[2096] == "")) &&
            (lastLineID == 2080 || lastLineID == 2084 || lastLineID == 2089 || lastLineID == 2095 || lastLineID == 2098 || lastLineID == 2101 || lastLineID == 2125))
        {
            DialogueMenu.AddToDialogueOptions(2102);
        }

        if (lastLineID == 2078 || lastLineID == 2080 || lastLineID == 2082 || lastLineID == 2084 || lastLineID == 2086 || lastLineID == 2089 || lastLineID == 2095 || lastLineID == 2098 || lastLineID == 2101 || lastLineID == 2125)
        {
            DialogueMenu.AddToDialogueOptions(2111);    // let's talk about something else
        }

        if ((lastLineID == 2031 || lastLineID == 2037 || lastLineID == 2039 || lastLineID == 2041 || lastLineID == 2043 || lastLineID == 2045 || lastLineID == 2111 || lastLineID == 2123) &&
            (characterSituation == 3))
        {
            DialogueMenu.AddToDialogueOptions(2124); // can you give me the roughshot?
        }

        if ((lastLineID == 2001 || lastLineID == 2002 || lastLineID == 2003 || lastLineID == 2004 || lastLineID == 2013 || lastLineID == 2025 || lastLineID == 2031 || lastLineID == 2037 || lastLineID == 2039 || lastLineID == 2041 || lastLineID == 2043 || lastLineID == 2045 || lastLineID == 2064 || lastLineID == 2067 || lastLineID == 2110 || lastLineID == 2111 || lastLineID == 2123) &&
            (characterSituation == 1 || characterSituation == 2 || characterSituation == 3 || characterSituation == 4))
        {
            DialogueMenu.AddToDialogueOptions(2122);   //ending sequence
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
                DialogueMenu.AddToDialogueOptions(2001);
                DialogueMenu.AddToDialogueOptions(2002);
                DialogueMenu.AddToDialogueOptions(2003);
                DialogueMenu.AddToDialogueOptions(2004);
                DialogueMenu.FindDialogueOptionText();
                MouseClickOnObject.ObjectLines[ObjectsInLevel.AyTheTearCollector] = "Ay the Tear Collector";    
                break;
            case 2: //SITUATION 2   // I'm back, rejoice!  
                AddToDialogue(2123);
                DialoguePlayback.Instance.PlaybackDialogue(2123);
                break;
            case 3: // I Don't have the mask
                AddToDialogue(2068);
                AddToDialogue(2069);
                AddToDialogue(2070); 
                AddToDialogue(2071); 
                AddToDialogue(2072);
                AddToDialogue(2073);
                AddToDialogue(2074);
                AddToDialogue(2075);
                AddToDialogue(2076);
                AddToDialogue(2077); 
                AddToDialogue(2078);
                DialoguePlayback.Instance.PlaybackDialogue(2068);
                break;
            case 4: //Thanks for the potion, chief
                AddToDialogue(2112);
                AddToDialogue(2113);
                DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogue(2112);
                break;
            case 5: //So, I got the mask
                AddToDialogue(2114);
                AddToDialogue(2115);
                AddToDialogue(2116);
                AddToDialogue(2117);
                AddToDialogue(2118);
                AddToDialogue(2119);

                DialoguePlayback.DeleteLineID = 2114;

                DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogue(2114);
                break;
            case 6: // I'm having a great time with the mask
                AddToDialogue(2120);
                AddToDialogue(2121);

                DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogue(2120);
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
        if (dialogueOptionID == 2001 || dialogueOptionID == 2002 || dialogueOptionID == 2003 || dialogueOptionID == 2004)
        {
            AddToDialogue(dialogueOptionID);
            AddToDialogue(2005);
            AddToDialogue(2006);
            AddToDialogue(2007);
            AddToDialogue(2008);
            AddToDialogue(2009);
            AddToDialogue(2010);
            AddToDialogue(2011);
            AddToDialogue(2012);
            AddToDialogue(2013);

            WorldEvents.EmmonKnowsAy = true;
            MouseClickOnObject.ObjectLines[ObjectsInLevel.AyTheTearCollector] = "Ay the Tear Collector";   
        }

        if (dialogueOptionID == 2014)
        {
            DialoguePlayback.DeleteLineID = 2014;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2015);
            AddToDialogue(2016);
            AddToDialogue(2017);
            AddToDialogue(2018);
            AddToDialogue(2019);
            AddToDialogue(2020);
            AddToDialogue(2021);
            AddToDialogue(2022);
            AddToDialogue(2023);
            AddToDialogue(2024);
            AddToDialogue(2025);
        }

        if (dialogueOptionID == 2026)
        {
            DialoguePlayback.DeleteLineID = 2026;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2027);
            AddToDialogue(2028);
            AddToDialogue(2029);
            AddToDialogue(2030);
            AddToDialogue(2031);
        }

        if (dialogueOptionID == 2032)
        {
            DialoguePlayback.DeleteLineID = 2032;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2033);
            AddToDialogue(2034);
            AddToDialogue(2035);
            AddToDialogue(2036);
            AddToDialogue(2037);
        }

        if (dialogueOptionID == 2038)
        {
            DialoguePlayback.DeleteLineID = 2038;

            Debug.LogWarning("delete 2038");
            AddToDialogue(dialogueOptionID);
            AddToDialogue(2039);
        }

        if (dialogueOptionID == 2040)
        {
            DialoguePlayback.DeleteLineID = 2040;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2041);
        }

        if (dialogueOptionID == 2042)
        {
            DialoguePlayback.DeleteLineID = 2042;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2043);
        }

        if (dialogueOptionID == 2044)
        {
            AddToDialogue(dialogueOptionID);
            AddToDialogue(2045);
        }

        if (dialogueOptionID == 2046)
        {
            DialoguePlayback.DeleteLineID = 2046;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2047);
            AddToDialogue(2048);
            AddToDialogue(2049);
            AddToDialogue(2050);
            AddToDialogue(2051);
            AddToDialogue(2052);
            AddToDialogue(2053);
            AddToDialogue(2054);
            AddToDialogue(2055);
            AddToDialogue(2056);
            AddToDialogue(2057);
            AddToDialogue(2058);
            AddToDialogue(2059);
            AddToDialogue(2060);
            AddToDialogue(2061);
            AddToDialogue(2062);
            AddToDialogue(2063);
            AddToDialogue(2064);

            WorldEvents.EmmonKnowsMaskLocation = true;
        }

        if (dialogueOptionID == 2065)
        {
            AddToDialogue(dialogueOptionID);
            AddToDialogue(2066);
            AddToDialogue(2067);
        }

        if (dialogueOptionID == 2079)               //when buying the potion, something special happens here
        {
            DialoguePlayback.DeleteLineID = 2079;
            AddToDialogue(dialogueOptionID);
            AddToDialogue(2080);
        }

        if (dialogueOptionID == 2081)
        {
            AddToDialogue(dialogueOptionID);
            AddToDialogue(2082);
        }

        if (dialogueOptionID == 2083)
        {
            AddToDialogue(dialogueOptionID);
            AddToDialogue(2084);
        }

        if (dialogueOptionID == 2085)
        {
            DialoguePlayback.DeleteLineID = 2085;

            AddToDialogue(dialogueOptionID);
            if (GameManager.Instance.RupeeHeld < 40)
                AddToDialogue(2086);    //not enough money
            else
            {
                AddToDialogue(2087);   //has enough money. -40 Rupee
                AddToDialogue(2088);
                AddToDialogue(2089);
                GameManager.Instance.ChangeMoney(-40);
            }
        }

        if (dialogueOptionID == 2090)
        {
            DialoguePlayback.DeleteLineID = 2090;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2091);
            AddToDialogue(2092);
            AddToDialogue(2093);
            AddToDialogue(2094);
            AddToDialogue(2095);
        }

        if (dialogueOptionID == 2096)
        {
            DialoguePlayback.DeleteLineID = 2096;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2097);
            AddToDialogue(2098);
        }

        if (dialogueOptionID == 2099)
        {
            DialoguePlayback.DeleteLineID = 2099;

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2100);
            AddToDialogue(2101);
        }

        if (dialogueOptionID == 2102)
        {
            WorldEvents.EmmonHasRoughneckShot = true;
            DialoguePlayback.DeleteLineID = 2124; //right?

            AddToDialogue(dialogueOptionID);
            AddToDialogue(2103);
            AddToDialogue(2104);
            AddToDialogue(2105);
            AddToDialogue(2106);
            AddToDialogue(2107);
            AddToDialogue(2108);
            AddToDialogue(2109);
            AddToDialogue(2110);
            SlotScript.IInventory.AddItem(1); // add roughneck shot
        }

        if (dialogueOptionID == 2111)
        {
            AddToDialogue(dialogueOptionID);
        }

        if (dialogueOptionID == 2122)
        {
            AddToDialogue(dialogueOptionID); // exit option
            DialoguePlayback.EndingDialogue = true;
        }

        if (dialogueOptionID == 2124)
        {
            AddToDialogue(dialogueOptionID);
            AddToDialogue(2125);
        }
    }

    private static void AddToDialogue(int dialogueID)
    {
        DialoguePlayback.AddToDialogue(dialogueID);
    }
}
