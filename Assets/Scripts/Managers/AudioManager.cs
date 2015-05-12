using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public static bool SwitchSoundtrack = false;
    public static bool CurrentlyPlayingSoundtrack1 = false;
    public static bool CurrentlyPlayingSoundtrack2 = false;

    private AudioClip _dialogueAudioClip;

    public static AudioClip Soundtrack1;
    public static AudioClip Soundtrack2;
    public static AudioClip CurrentSoundtrack;

    public Footsteps FootstepsScript;
    public UISounds UISoundsScript;

    private string _audioPath = "";
    public void Awake()
    {
        Instance = this;

        FootstepsScript = new Footsteps();
        FootstepsScript.Awake();

        UISoundsScript = new UISounds();
        UISoundsScript.Awake();

        _dialogueAudioClip = Resources.Load("Audio/Dialogues/" + _audioPath) as AudioClip;
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

        AudioSource.PlayClipAtPoint(_dialogueAudioClip, GameManager.Player.transform.position);

        TimeManager.Instance.PlayDialogueTimer(_dialogueAudioClip.length);
    }

    public void PlayEffectAudio(string audioPath)
    {

    }
}