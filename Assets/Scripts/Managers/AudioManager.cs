﻿using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public static bool SwitchSoundtrack = false;
    public static bool CurrentlyPlayingSoundtrack1 = false;
    public static bool CurrentlyPlayingSoundtrack2 = false;

    public AudioMixer MainMixer;


    public static AudioClip Soundtrack1;
    public static AudioClip Soundtrack2;
    public static AudioClip CurrentSoundtrack;

    public Footsteps FootstepsScript;
    public UISounds UISoundsScript;

    private string _audioPath = "";

    //private static AudioSource _voiceActorsSource;
    private AudioClip _dialogueAudioClip;

    private static AudioSource _doorOpeningSoundSource;
    private static AudioClip _doorOpeningSound;

    private static AudioSource _templeDoorMusicSource;
    private static AudioClip _templeDoorMusicSound;

    private static AudioSource _chestSoundSource;
    private static AudioClip _chestOpeningSound;

    public static List<AudioClip> _wheelTurnClips = new List<AudioClip>();
    private static AudioSource _wheelSoundSource;

    public static List<AudioClip> _pickUpClips = new List<AudioClip>();
    private static AudioSource _pickUpSource;

    public void Awake()
    {
        Instance = this;

        MainMixer = GameObject.Find("MainMixerGO").GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer;
        SetSendLevel(-90f);


        FootstepsScript = new Footsteps();
        FootstepsScript.Awake();

        UISoundsScript = new UISounds();
        UISoundsScript.Awake();

        _dialogueAudioClip = Resources.Load("Audio/Dialogues/" + _audioPath) as AudioClip;

        _doorOpeningSoundSource = GameObject.Find("TempleDoorOpeningAudio").GetComponent<AudioSource>();
        _doorOpeningSound = Resources.Load("Audio/Effects/Doors/OpeningGate") as AudioClip;

        _templeDoorMusicSource = GameObject.Find("IncidentalMusic").GetComponent<AudioSource>();
        _templeDoorMusicSound = Resources.Load("Audio/Music/MuseumDoorOpens") as AudioClip;

        _chestOpeningSound = Resources.Load("Audio/Effects/ChestOpening") as AudioClip;

        _wheelSoundSource = GameObject.Find("PuzzleWheelAudio").GetComponent<AudioSource>();
        _wheelTurnClips.Add(Resources.Load("Audio/Effects/Doors/wheel turn 1") as AudioClip);
        _wheelTurnClips.Add(Resources.Load("Audio/Effects/Doors/wheel turn 2") as AudioClip);
        _pickUpSource = GameObject.Find("PickUpAudio").GetComponent<AudioSource>();
        _pickUpClips.Add(Resources.Load("Audio/Effects/PickingUp/pick up 1") as AudioClip);
        _pickUpClips.Add(Resources.Load("Audio/Effects/PickingUp/pick up 2") as AudioClip);
        _pickUpClips.Add(Resources.Load("Audio/Effects/PickingUp/pick up 3") as AudioClip);

    }

    public void Update()
    {
        FootstepsScript.Update();
    }

    public void PlayDialogueAudio(string audioPath)
    {
        _audioPath = audioPath;

        _dialogueAudioClip = Resources.Load(("Audio/Dialogues/") + _audioPath) as AudioClip;

        if (_dialogueAudioClip == null)
            _dialogueAudioClip = Resources.Load("Audio/Dialogues/DefaultClip") as AudioClip;

        //      AudioSource.PlayClipAtPoint(_dialogueAudioClip, GameManager.Player.transform.position);
        AudioSource.PlayClipAtPoint(_dialogueAudioClip, ThirdPersonCamera.Instance.MyCamera.transform.position);

        TimeManager.Instance.PlayDialogueTimer(_dialogueAudioClip.length);
    }

    public void SetSendLevel(float lvl)
    {
        MainMixer.SetFloat("FootstepsReverbSend", lvl);
    }

    public void PlayEffectAudio(string audioPath)
    {

    }

    public static void OpenTempleDoorAudio()
    {
        _doorOpeningSoundSource.clip = _doorOpeningSound;
        _doorOpeningSoundSource.Play();

        Debug.Log("Play the sound");
        _templeDoorMusicSource.clip = _templeDoorMusicSound;
        _templeDoorMusicSource.Play();
    }

    public static void OpenChestAudio(GameObject source)
    {
        _chestSoundSource = source.GetComponent<AudioSource>();
        _chestSoundSource.clip = _chestOpeningSound;
        _chestSoundSource.Play();
    }

    public static void TurnWheelAudio()
    {
        int randomClip = Random.Range(0, _wheelTurnClips.Count);
        _wheelSoundSource.clip = _wheelTurnClips[randomClip];
        _wheelSoundSource.Play();
    }

    public static void PickUpAudio()
    {
        int randomClip = Random.Range(0, _pickUpClips.Count);
        _pickUpSource.clip = _pickUpClips[randomClip];
        _pickUpSource.Play();
    }
}