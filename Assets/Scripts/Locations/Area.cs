using UnityEngine;
using System.Collections;

public class Area : MonoBehaviour 
{
    public Area Instance;
    public AreaEnum Name;
    public AudioClip AreaSoundtrack;
    public void Awake()
    {
        Instance = this;
        if (Name == AreaEnum.Null)
            Debug.LogError("There is an area not assigned");

        AreaSoundtrack = Resources.Load("Audio/Music/" + FindName()) as AudioClip;
    }

    public void OnTriggerEnter () 
    {
        float transitionIn = AmbientSoundtracks.Instance.FindTransitionInTime(this.Name);
        AreaManager.Instance.StartAmbientSoundtrack(this.Name, AreaSoundtrack, transitionIn);

       // Debug.Log("We are now in: " + AreaManager.CurrentArea);

        if (AreaSoundtrack == null)
        {
            MyConsole.WriteToConsole("This area has no soundtrack.");
            return;
        }

        if (Name == AreaEnum.Crater)
            ArrangeParticleSystems.LoadWaterfallParticlesAndSound();

        if (Name == AreaEnum.Pathway)
            ArrangeParticleSystems.DeleteWaterfallParticlesAndSound();
	}

    private string FindName()
    {
        var soundtrackName = "";

        if (Name == AreaEnum.Crater)
            soundtrackName = "Crater Environment";
        else if (Name == AreaEnum.Town)
            soundtrackName = "Square Environment";
        else if (Name == AreaEnum.The_Two_Spoons)
            soundtrackName = "The Two Spoons";
        else if (Name == AreaEnum.Pathway)
            soundtrackName = "Pathway Environment";
        else if (Name == AreaEnum.Cave)
            soundtrackName = "Crater Environment";
        else
            MyConsole.WriteToConsole("Unknown area!");
        return soundtrackName;
    }
}
