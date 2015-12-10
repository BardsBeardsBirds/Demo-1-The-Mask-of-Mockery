using UnityEngine;
using System.Collections;

public class UVScroller : MonoBehaviour
{
    public float ScrollSpeed = 0.3f;
    public float BumpSpeedFactor = -7f;
    public float MainTexSpeedFactor = 10f;

    void Update()
    {
        var offset = Time.time * ScrollSpeed;

        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset / MainTexSpeedFactor, offset));
        GetComponent<Renderer>().material.SetTextureOffset("_BumpMap", new Vector2(offset / BumpSpeedFactor, offset));
    }
}
