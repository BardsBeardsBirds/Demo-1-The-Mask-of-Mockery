using System;
using UnityEngine;


public class DialogueSituationSelector
{
    public static int CharacterSituation = 1;

    public static void LoadAySituations()
    {
        CharacterSituation = 1;
        if (WorldEvents.EmmonKnowsAy)
            CharacterSituation = 2;
        if (WorldEvents.EmmonKnowsWhatSentinelWants && WorldEvents.EmmonKnowsMaskLocation)
            CharacterSituation = 3;
        if (WorldEvents.EmmonHasRoughneckShot)
            CharacterSituation = 4;
        if (InGameObjectManager.PickedUpMaskOfMockery)
        {
            if (DialogueManager.IsDialoguePassed(2114))
                CharacterSituation = 6;
            else
                CharacterSituation = 5;
        }

        AyTheTearCollector.CharacterSituation = CharacterSituation;
        AyTheTearCollector.Instance.DialogueLineNumberToSituation(CharacterSituation);   //dialogue situation at start.
        DialogueMenu.ShowDialogueOptions();
    }

    public static void LoadBennyTwospoonsSituations()
    {
        CharacterSituation = 1;
        if(ObjectCommentary.AskingLute)
            CharacterSituation = 2;
        if (WorldEvents.EmmonKnowsMaskLocation)
            CharacterSituation = 3;
        if (WorldEvents.EmmonKnowsWhatSentinelWants && WorldEvents.EmmonKnowsMaskLocation)
            CharacterSituation = 4;
        if (WorldEvents.EmmonHasPassedTheSentinel)
            CharacterSituation = 5;
        if (InGameObjectManager.PickedUpMaskOfMockery)
            CharacterSituation = 6;

        BennyTwospoons.CharacterSituation = CharacterSituation;
        BennyTwospoons.Instance.DialogueLineNumberToSituation(CharacterSituation);   //dialogue situation at start.
        DialogueMenu.ShowDialogueOptions();
    }

    public static void LoadSentinelSituations()
    {
        CharacterSituation = 1;
        if ((WorldEvents.EmmonKnowsMaskLocation || WorldEvents.EmmonWasBlockedBySentinel) && !SentinelBlocker.TryingToSneakPast)
            CharacterSituation = 2;
        if (WorldEvents.EmmonHasRoughneckShot)
            CharacterSituation = 3;
        if (WorldEvents.EmmonHasPassedTheSentinel)
            CharacterSituation = 4;

        Sentinel.CharacterSituation = CharacterSituation;
        Sentinel.Instance.DialogueLineNumberToSituation(CharacterSituation);   //dialogue situation at start.
        DialogueMenu.ShowDialogueOptions();
    }
}


