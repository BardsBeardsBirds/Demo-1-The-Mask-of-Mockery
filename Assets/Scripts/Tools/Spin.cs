using System;
using System.Collections;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = .5f;

    public void Start()
    {
        StartCoroutine(SpinCoin());
    }

    public IEnumerator SpinCoin()
    {
        while(true)
        {
            transform.Rotate(transform.up, 360 * rotateSpeed * Time.deltaTime);
            yield return 0;
        }
    }
}
