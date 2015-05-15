using System;
using System.Collections;
using UnityEngine;


public class WaterBehaviour : MonoBehaviour
{
    public Vector3 WaterAboveObject;
    public float WaterLevel;
    private float _waterRingDuration = 8f;
    private float _waterTimer = 0;

    public void Awake()
    {
   //         Debug.DrawRay(this.transform.position, WaterAboveObject, Color.magenta);
        WaterAboveObject = new Vector3(0, 0.85f, 0);
        WaterLevel = WaterAboveObject.y + this.transform.position.y;
    }

    public void Update()
   {
    //    Debug.DrawRay(this.transform.position, WaterAboveObject, Color.magenta);
    //    Debug.Log(this.transform.position.y);
        if(_waterTimer > 0)
        {
            _waterTimer -= Time.deltaTime;
            if (_waterTimer <= 0)
            {
                if (Emmon.Instance.InWater)
                {
                    Debug.Log("We finished the timer but are in the water");
                }
                else  
                {
                    Emmon.Instance.WaterRings.SetActive(false);
                    Debug.Log("We finished the timer and are not in the water");
                }
            }
        }
            
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
            return;

        Emmon.Instance.InWaterGo = this.gameObject;

        Emmon.Instance.InWater = true;
        Emmon.Instance.WaterRings.SetActive(true);
        Emmon.Instance.WaterRings.GetComponentInChildren<ParticleSystem>().emissionRate = 8;
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
            return;

        Emmon.Instance.InWater = false;

        _waterTimer = _waterRingDuration;

        Emmon.Instance.WaterRings.GetComponentInChildren<ParticleSystem>().emissionRate = 0;

     //   StartCoroutine(TurnOffWater());


    }


    //public IEnumerator TurnOffWater()
    //{
        
    //    Debug.Log("We are in the routine");

    //    yield return new WaitForSeconds(_waterRingDuration);


    //}
}