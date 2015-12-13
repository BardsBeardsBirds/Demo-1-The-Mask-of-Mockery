using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyAfterPlayback : MonoBehaviour
{
    public GameObject ObjectToDestroy;
    public float TimeBeforeDestroy = 4f;
    public bool StartDestroying = true;

    public void Update()
    {
        if (TimeBeforeDestroy > 0 && StartDestroying)
        {
            TimeBeforeDestroy -= Time.deltaTime;
        }
        else if(StartDestroying)
            Destroy();
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}

