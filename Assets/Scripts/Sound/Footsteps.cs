using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Footsteps
{
    private AudioSource _footstepSource;

    public static List<AudioClip> FootstepWalkClips = new List<AudioClip>();
    public static List<AudioClip> FootstepRunClips = new List<AudioClip>();
    public static List<AudioClip> FootstepSprintClips = new List<AudioClip>();
    public static List<AudioClip> FootstepTurnClips = new List<AudioClip>();


    public void Awake()
    {
        _footstepSource = GameObject.Find("Footsteps").GetComponent<AudioSource>();
        FootstepWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);
        FootstepWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_2") as AudioClip);
        FootstepWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_3") as AudioClip);

        FootstepRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);
        FootstepRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_2") as AudioClip);
        FootstepRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_3") as AudioClip);
        FootstepRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_4") as AudioClip);
        FootstepRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_5") as AudioClip);

        FootstepSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);
        FootstepSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_2") as AudioClip);
        FootstepSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_3") as AudioClip);
        FootstepSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_4") as AudioClip);
        FootstepSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_5") as AudioClip);

        FootstepTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);
        FootstepTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_2") as AudioClip);
        FootstepTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_3") as AudioClip);
    }

    public void Update()
    {
     //   float speed = GameManager.Player.GetComponent<Animator>().GetFloat("Speed");
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.WalkBackwards ||
            CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Walking)
        {
            if (!_footstepSource.isPlaying)
                PlayWalkingFootstep(Emmon.Instance.Ground);
        }
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Running)
        {
            if (!_footstepSource.isPlaying)
                PlayRunningFootstep();
        }
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Sprinting)
        {
            if (!_footstepSource.isPlaying)
                PlaySprintingFootstep();
        } 
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Turning)
        {
            if (!_footstepSource.isPlaying)
                PlayTurningFootstep();
        }
    }

    public void PlayWalkingFootstep(CharacterControllerLogic.WalkGround ground)
    {
        int randomClip = Random.Range(0, FootstepWalkClips.Count);
        _footstepSource.clip = FootstepWalkClips[randomClip];
        _footstepSource.Play();
    }

    public void PlayRunningFootstep()
    {
        int randomClip = Random.Range(0, FootstepRunClips.Count);
        _footstepSource.clip = FootstepRunClips[randomClip];
        _footstepSource.Play();
    }

    public void PlaySprintingFootstep()
    {
        int randomClip = Random.Range(0, FootstepWalkClips.Count);
        _footstepSource.clip = FootstepWalkClips[randomClip];
        _footstepSource.Play();
    }

    public void PlayTurningFootstep()
    {
        int randomClip = Random.Range(0, FootstepTurnClips.Count);
        _footstepSource.clip = FootstepTurnClips[randomClip];
        _footstepSource.Play();
    }
}
