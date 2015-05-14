using System;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AreaManager : MonoBehaviour
{
    public static AreaManager Instance;
    public GameObject AmbientPlayer;
    public static AreaEnum CurrentArea;
    public static AreaEnum PreviousArea;
    public static AudioMixerGroup Mixer;

    public List<GameObject> AmbientGOs = new List<GameObject>();

    public void Awake()
    {
        Instance = this;
        AmbientPlayer = GameObject.Find("AmbientPlayer");
        Mixer = GameManager.Instance.Mixer;
    }

    public void StartAmbientSoundtrack(AreaEnum currentArea, AudioClip audioClip, float transitionIn)
    {
   //     Debug.LogError("previous: " + PreviousArea + "and now: " + currentArea);
        if (CurrentArea == currentArea)
            return;

        PreviousArea = CurrentArea;
        
        CurrentArea = currentArea;

        for (int i = 0; i < AmbientPlayer.transform.childCount; i++)
        {
            GameObject go = AmbientPlayer.transform.GetChild(i).gameObject;
            if(go.name == CurrentArea.ToString())
            {

                AudioMixerSnapshot snapshot = AmbientSoundtracks.Instance.FindSoundtrack(CurrentArea);
                snapshot.TransitionTo(transitionIn);
                AudioSource audioSource = go.GetComponent<AudioSource>();
                audioSource.clip = audioClip;
                audioSource.Play();
                AmbientGOs.Add(go);
            }
        }
    }
}
