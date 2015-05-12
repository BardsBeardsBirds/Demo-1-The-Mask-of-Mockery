using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour 
{
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter(Collider other)
    {
        var player = other.transform;
        var otherEnd = this.transform.FindChild("OtherEnd");
        player.position = otherEnd.position;
    }
}
