using UnityEngine;
using System.Collections;

public class SentinelBlocker : MonoBehaviour 
{
    public static bool IsBlocking;

    public void OnTriggerEnter(Collider other)
    {
        if (WorldEvents.EmmonHasRoughneckShot)
        {
            CharacterControllerLogic.Instance.GoToTalkingState();
            Sentinel.Instance.StartDialogue();
    //        CharacterControllerLogic.Instance.ForceSpeed(0f);
        }
        else if (!IsBlocking)
        {
            TimeManager.Instance.CreateRotator(GameManager.Player.transform, Sentinel.Instance.transform, 200, 2f);
            Sentinel.Instance.HoldItThere();
        }
        else
            Debug.LogError("We are already blocking!!");
    }
}
