using UnityEngine;

public class UISounds
{
    private AudioSource _UISoundSource;
    private AudioClip _click;
    private AudioClip _drumRoll;

    public void Awake()
    {
        _UISoundSource = GameObject.Find("UISoundSource").GetComponent<AudioSource>();
        _click = Resources.Load("Audio/Effects/UI/HiHatClick") as AudioClip;
        _drumRoll = Resources.Load("Audio/Effects/UI/DrumRoll") as AudioClip;
    }

    public void PlayClick()
    {
        _UISoundSource.clip = _click;
        _UISoundSource.Play();
    }

    public void PlayDrumRoll()
    {
        _UISoundSource.clip = _drumRoll;
        _UISoundSource.Play();
    }
}

