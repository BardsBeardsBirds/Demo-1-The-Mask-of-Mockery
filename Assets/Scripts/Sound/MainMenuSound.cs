using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MainMenuSound : MonoBehaviour
{
    public AudioClip Music;
    public AudioSource AudioSource;

    public static bool FadeOut = false;

    public void Awake()
    {
        if (Music == null)
            Music = Resources.Load("Audio/Music/MainMenu") as AudioClip;
        AudioSource = this.gameObject.GetComponent<AudioSource>();
        AudioSource.clip = Music;
        AudioSource.Play();
    }

    public void Update()
    {
        if (FadeOut)
            AudioSource.volume = AudioSource.volume - .8f * Time.deltaTime;
    }
}