using UnityEngine;
using System.Collections;

public class SentinelBlocker : MonoBehaviour 
{
    public static bool IsBlocking;
    public static bool TryingToSneakPast = false;

    public void OnTriggerEnter(Collider other)
    {
        if (WorldEvents.EmmonHasRoughneckShot)
        {
            CharacterControllerLogic.Instance.GoToTalkingState();
            Sentinel.Instance.StartDialogue();
        }
        else if (!IsBlocking)
        {
            IsBlocking = true;

            TryingToSneakPast = true;
            CharacterControllerLogic.Instance.GoToTalkingState();
            Sentinel.Instance.StartDialogue();
        }
        else
            Debug.LogWarning("We are already blocking!!");
    }
}
