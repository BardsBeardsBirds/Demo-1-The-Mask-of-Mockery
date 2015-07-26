using System;
using UnityEngine;


public class Emmon : MonoBehaviour
{
    public static Emmon Instance;

    public CharacterControllerLogic.WalkGround Ground = CharacterControllerLogic.WalkGround.None;

    public GameObject WaterRings = null;
    public GameObject InWaterGo;
    public bool InWater = false;

    public AreaEnum CurrentArea;
    public AreaEnum PreviousArea;

    public void Awake()
    {
        Instance = this;

        SetWaterRings();
    }

    public void Update()
    {
        if(InWater)
        {
            WaterRings.transform.position = new Vector3(WaterRings.transform.position.x,
                InWaterGo.GetComponent<WaterBehaviour>().WaterLevel, 
                WaterRings.transform.position.z);
        }
    }

    public void SetWaterRings()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.name == "Particle Effects")
            {
                GameObject waterRings = GameObject.Instantiate(Resources.Load("Prefabs/Particles/Water Rings") as GameObject);
                waterRings.transform.SetParent(child);
                waterRings.transform.position = child.position;
                WaterRings = waterRings;
                WaterRings.SetActive(false);
            }
        }
    }
}
