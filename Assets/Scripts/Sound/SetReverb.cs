using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum ReverbLevel
{ None, Low, Medium, High, Extreme}

public class SetReverb : MonoBehaviour
{
    public int ReverbAmount;
    public AudioMixer Mixer;

    public void AssignReverb(ReverbLevel reverbLevel)
    {
        switch (reverbLevel)
        {
            case ReverbLevel.None:
                AudioManager.Instance.SetSendLevel(-80f);
                break;
            case ReverbLevel.Low:
                AudioManager.Instance.SetSendLevel(-20f);
                break;
            case ReverbLevel.Medium:
                AudioManager.Instance.SetSendLevel(-10f);
                break;
            case ReverbLevel.High:
                AudioManager.Instance.SetSendLevel(-5f);
                break;
            case ReverbLevel.Extreme:
                AudioManager.Instance.SetSendLevel(0);
                break;
            default:
                break;
        }
    }

    //public void FindMixer()
    //{
    //    Mixer = AudioManager.Instance.MainMixer;
    //}

    //public void SetSendLevel(float lvl)
    //{
    //    float waka = 0;
    //    Mixer.GetFloat("FootstepsReverbSend", out waka);
    //    Debug.Log(waka);
    //    Mixer.SetFloat("FootstepsReverbSend", lvl);
    //}
}