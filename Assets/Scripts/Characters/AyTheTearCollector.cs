using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AyTheTearCollector : MonoBehaviour 
{
    public static int CharacterSituation;
    public static AyTheTearCollector Instance;
    public Animator Animator;

    private static List<int> LastBefore2014 = new List<int>() { 2013, 2023, 2123, 2064, 2067 };
    private static List<int> LastBefore2026 = new List<int>() { 2025, 2039, 2041, 2043, 2045, 2064, 2067, 2111, 2123 };
    private static List<int> LastBefore2032 = new List<int>() { 2031, 2039, 2041, 2043, 2045, 2064, 2067, 2110, 2111, 2123 };
    private static List<int> LastBefore2038 = new List<int>() { 2025, 2031, 2037, 2064, 2067, 2110, 2111, 2123 };
    private static List<int> LastBefore2040 = new List<int>() { 2025, 2031, 2037, 2039, 2064, 2067, 2110, 2111, 2123 };
    private static List<int> LastBefore2042 = new List<int>() { 2025, 2031, 2037, 2039, 2041, 2064, 2067, 2110, 2111, 2123 };
    private static List<int> LastBefore2044 = new List<int>() { 2025, 2031, 2037, 2043, 2045, 2064, 2067, 2110, 2111, 2123 };
    private static List<int> LastBefore2046 = new List<int>() { 2013, 2031, 2037, 2039, 2041, 2043, 2045, 2123 };
    private static List<int> LastBefore2065 = new List<int>() { 2013, 2025, 2031, 2037, 2039, 2041, 2043, 2045, 2064, 2067, 2111, 2123 };
    private static List<int> LastBefore2079 = new List<int>() { 2078, 2084, 2086, 2089, 2095, 2098, 2101, 2125 };
    private static List<int> LastBefore2081 = new List<int>() { 2078, 2080, 2095, 2098, 2101, 2125 };
    private static List<int> LastBefore2083 = new List<int>() { 2082 };
    private static List<int> LastBefore2085 = new List<int>() { 2082, 2124 };
    private static List<int> LastBefore2090 = new List<int>() { 2078, 2080, 2084, 2086, 2089, 2095, 2098, 2101, 2125 };
    private static List<int> LastBefore2096 = new List<int>() { 2080, 2084, 2086, 2089, 2095, 2101, 2125 };
    private static List<int> LastBefore2099 = new List<int>() { 2084, 2086, 2089, 2095, 2098, 2125 };
    private static List<int> LastBefore2102 = new List<int>() { 2080, 2084, 2089, 2095, 2098, 2101, 2125 };
    private static List<int> LastBefore2111 = new List<int>() { 2078, 2080, 2082, 2084, 2086, 2089, 2095, 2098, 2101, 2125 };
    private static List<int> LastBefore2122 = new List<int>() { 2001, 2002, 2003, 2004, 2013, 2025, 2031, 2037, 2039, 2041, 2043, 2045, 2064, 2067, 2110, 2111, 2123 };
    private static List<int> LastBefore2124 = new List<int>() { 2031, 2037, 2039, 2041, 2043, 2045, 2067, 2111, 2123 };

    private static Dictionary<int, List<int>> LastLinesBeforeOption = new Dictionary<int, List<int>>()
    { 
        {2014, LastBefore2014},
        {2026, LastBefore2026},
        {2032, LastBefore2032},
        {2038, LastBefore2038},
        {2040, LastBefore2040},
        {2042, LastBefore2042},
        {2044, LastBefore2044},
        {2046, LastBefore2046},
        {2065, LastBefore2065},
        {2079, LastBefore2079},
        {2081, LastBefore2081},
        {2083, LastBefore2083},
        {2085, LastBefore2085},
        {2090, LastBefore2090},
        {2096, LastBefore2096},
        {2099, LastBefore2099},
        {2102, LastBefore2102},
        {2111, LastBefore2111},
        {2122, LastBefore2122},
        {2124, LastBefore2124},
    };

    public void Start() 
    {
        Instance = this;
        CharacterSituation = 1;
        Animator = this.gameObject.GetComponent<Animator>();
	}

    public void StartDialogue()
    {
        DialogueManager.StartDialogueState(Character.Ay);
    }

    public void DialogueLineNumberToSituation(int lastLineID)   //the last line of dialogue determines which situation will follow
    {
        int characterSituation = CharacterSituation;

        if (IsLastBefore(lastLineID, 2014) && characterSituation < 5)
            DialogueMenu.AddToDialogueOptions(2014);

        if (IsLastBefore(lastLineID, 2026) && characterSituation < 5 && DialogueManager.IsDialoguePassed(2014))
            DialogueMenu.AddToDialogueOptions(2026);

        if(IsLastBefore(lastLineID, 2032) && characterSituation < 5 && DialogueManager.IsDialoguePassed(2026))
            DialogueMenu.AddToDialogueOptions(2032);    //tear collector shop?

        if (IsLastBefore(lastLineID, 2038) && characterSituation < 5 && DialogueManager.IsDialoguePassed(2014))
            DialogueMenu.AddToDialogueOptions(2038);

        if (IsLastBefore(lastLineID, 2040) && characterSituation < 5 && DialogueManager.IsDialoguePassed(2038))
            DialogueMenu.AddToDialogueOptions(2040);

        if (IsLastBefore(lastLineID, 2042) && characterSituation < 5 && DialogueManager.IsDialoguePassed(2040))
            DialogueMenu.AddToDialogueOptions(2042);

        if (IsLastBefore(lastLineID, 2044) && characterSituation < 5 && DialogueManager.IsDialoguePassed(2042))
            DialogueMenu.AddToDialogueOptions(2044);

        if (IsLastBefore(lastLineID, 2046) && characterSituation < 5 && DialogueManager.IsDialoguePassed(2014) && WorldEvents.BennyHasOfferedLute == true)
            DialogueMenu.AddToDialogueOptions(2046);

        if (IsLastBefore(lastLineID, 2065) && characterSituation < 5 && DialogueManager.IsDialoguePassed(2046))
            DialogueMenu.AddToDialogueOptions(2065);

        if (IsLastBefore(lastLineID, 2079))
            DialogueMenu.AddToDialogueOptions(2079);

        if (IsLastBefore(lastLineID, 2081))
            DialogueMenu.AddToDialogueOptions(2081); //How much is it?

        if (lastLineID == 2089)
            DialogueManager.AddToPassedDialogueLines(2081);

        if (IsLastBefore(lastLineID, 2083))
            DialogueMenu.AddToDialogueOptions(2083);    //40 rupee is too much

        if (IsLastBefore(lastLineID, 2085))
            DialogueMenu.AddToDialogueOptions(2085);    //alright I want to buy your potion

        if (IsLastBefore(lastLineID, 2090) && DialogueManager.IsDialoguePassed(2079))
            DialogueMenu.AddToDialogueOptions(2090);    // free massage

        if (IsLastBefore(lastLineID, 2096) &&
            (DialogueManager.IsDialoguePassed(2079) || DialogueManager.IsDialoguePassed(2090) || DialogueManager.IsDialoguePassed(2099)))
            DialogueMenu.AddToDialogueOptions(2096);  //If you give me the Roughneck shot, you don’t have to reward me with the lute later on.

        if (IsLastBefore(lastLineID, 2099) && (DialogueManager.IsDialoguePassed(2079) || DialogueManager.IsDialoguePassed(2090)))
            DialogueMenu.AddToDialogueOptions(2099);    // don't you see how disappointed I am?

        if (IsLastBefore(lastLineID, 2102) && 
            // it is more efficient to put this one in its own method, with some foreach loop
            ((DialogueManager.IsDialoguePassed(2079) && DialogueManager.IsDialoguePassed(2087)) ||
            DialogueManager.IsDialoguePassed(2079) || 
            (DialogueManager.IsDialoguePassed(2079) && DialogueManager.IsDialoguePassed(2085)) ||
            (DialogueManager.IsDialoguePassed(2079) && DialogueManager.IsDialoguePassed(2096)) ||
            (DialogueManager.IsDialoguePassed(2079) && DialogueManager.IsDialoguePassed(2099)) ||
            (DialogueManager.IsDialoguePassed(2079) && DialogueManager.IsDialoguePassed(2090)) ||
            DialogueManager.IsDialoguePassed(2087) || 
            DialogueManager.IsDialoguePassed(2090) || 
            DialogueManager.IsDialoguePassed(2096) || 
            DialogueManager.IsDialoguePassed(2099) || 
            (DialogueManager.IsDialoguePassed(2085) && DialogueManager.IsDialoguePassed(2087)) ||
            (DialogueManager.IsDialoguePassed(2085) && DialogueManager.IsDialoguePassed(2090)) ||
            (DialogueManager.IsDialoguePassed(2085) && DialogueManager.IsDialoguePassed(2096)) ||
            (DialogueManager.IsDialoguePassed(2090) && DialogueManager.IsDialoguePassed(2096))))
                DialogueMenu.AddToDialogueOptions(2102);

        if (IsLastBefore(lastLineID, 2111))
            DialogueMenu.AddToDialogueOptions(2111);    // let's talk about something else

        if (IsLastBefore(lastLineID, 2122) && (characterSituation == 1 || characterSituation == 2 || characterSituation == 3 || characterSituation == 4))
            DialogueMenu.AddToDialogueOptions(2122);   //ending sequence

        if (IsLastBefore(lastLineID, 2124) && characterSituation == 3)
            DialogueMenu.AddToDialogueOptions(2124); // can you give me the roughshot?



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
                DialogueMenu.FindDialogueOptionText(Character.Ay);
                MouseClickOnObject.ObjectLines[ObjectsInLevel.AyTheTearCollector] = "Ay the Tear Collector";
                MouseClickOnObject.ObjectInvestigationLines[ObjectsInLevel.AyTheTearCollector] = "Investigate Ay";
                MouseClickOnObject.ObjectInteractionLines[ObjectsInLevel.AyTheTearCollector] = "Talk to Ay";    
                break;
            case 2: //SITUATION 2   // I'm back, rejoice!  
                AddToDialogue(2123);
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(2123);
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
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(2068);
                break;
            case 4: //Thanks for the potion, chief
                AddToDialogue(2112);
                AddToDialogue(2113);
                DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(2112);
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
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(2114);
                break;
            case 6: // I'm having a great time with the mask
                AddToDialogue(2120);
                AddToDialogue(2121);

                DialoguePlayback.EndingDialogue = true;
                DialoguePlayback.Instance.PlaybackDialogueWithoutOptions(2120);
                break;
            case 999:
                DialogueMenu.FindDialogueOptionText(Character.Ay);
                break;

            default: //in all other dialogue options
                DialogueMenu.FindDialogueOptionText(Character.Ay);
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

            DialogueManager.AddToPassedDialogueLines(1094);

            if(WorldEvents.EmmonKnowsWhatSentinelWants)
                DialogueManager.AddToPassedDialogueLines(1055);
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
            ItemManager.AddItem(ItemType.RoughneckShot);
//            GameManager.Instance.MyInventory.AddItem(1); // add roughneck shot
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

    private bool IsLastBefore(int lastLine, int dialogueOptionID)
    {
        if (LastLinesBeforeOption[dialogueOptionID].Contains(lastLine))
            return true;

        return false;
    }
}
