using System;
using UnityEngine;
using UnityEngine.Audio;

public class GroundTerrain : MonoBehaviour
{
    public GroundTerrain Instance;
    public CharacterControllerLogic.WalkGround Ground;
    public static SetReverb Reverb;
    public ReverbLevel ReverbAmount;

    public void Awake()
    {
        Instance = this;

        if (Ground == CharacterControllerLogic.WalkGround.None)
        {
            Debug.LogError("Please assign this piece of ground material");
        }

        Reverb = new SetReverb();
      //  Reverb.FindMixer();
    }

    public void OnTriggerEnter()
    {
        SetCurrentGroundMaterial(this.Ground);
        Reverb.AssignReverb(ReverbAmount);

    }

    public void SetCurrentGroundMaterial(CharacterControllerLogic.WalkGround type)
    {
        Emmon.Instance.Ground = type;
    }
}

