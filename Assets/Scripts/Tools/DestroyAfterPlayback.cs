using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyAfterPlayback : MonoBehaviour
{
    public float TimeBeforeDestroy = 2;

    public void Update()
    {
        if (TimeBeforeDestroy > 0)
        {
            TimeBeforeDestroy -= Time.deltaTime;
        }
        else
            Destroy();
    }

    private void Destroy()
    {
        Destroy(this.transform.gameObject);
    }
}

