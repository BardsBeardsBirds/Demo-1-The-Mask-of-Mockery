using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour 
{
    public void OnTriggerEnter(Collider other)
    {
        var player = other.transform;
        var otherEnd = this.transform.FindChild("OtherEnd");
        player.position = otherEnd.position;
    }
}