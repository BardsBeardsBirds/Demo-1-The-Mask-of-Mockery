using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class Footsteps
{
    private AudioSource _footstepSource;

    public static List<AudioClip> ConcreteWalkClips = new List<AudioClip>();
    public static List<AudioClip> ConcreteRunClips = new List<AudioClip>();
    public static List<AudioClip> ConcreteSprintClips = new List<AudioClip>();
    public static List<AudioClip> ConcreteTurnClips = new List<AudioClip>();

    public static List<AudioClip> ConcreteGrittyWalkClips = new List<AudioClip>();
    public static List<AudioClip> ConcreteGrittyRunClips = new List<AudioClip>();
    public static List<AudioClip> ConcreteGrittySprintClips = new List<AudioClip>();
    public static List<AudioClip> ConcreteGrittyTurnClips = new List<AudioClip>();

    public static List<AudioClip> CreakyFloorWalkClips = new List<AudioClip>();
    public static List<AudioClip> CreakyFloorRunClips = new List<AudioClip>();
    public static List<AudioClip> CreakyFloorSprintClips = new List<AudioClip>();
    public static List<AudioClip> CreakyFloorTurnClips = new List<AudioClip>();

    public static List<AudioClip> CreakyRugWalkClips = new List<AudioClip>();
    public static List<AudioClip> CreakyRugRunClips = new List<AudioClip>();
    public static List<AudioClip> CreakyRugSprintClips = new List<AudioClip>();
    public static List<AudioClip> CreakyRugTurnClips = new List<AudioClip>();

    public static List<AudioClip> DeckWalkClips = new List<AudioClip>();
    public static List<AudioClip> DeckRunClips = new List<AudioClip>();
    public static List<AudioClip> DeckSprintClips = new List<AudioClip>();
    public static List<AudioClip> DeckTurnClips = new List<AudioClip>();

    public static List<AudioClip> DirtWalkClips = new List<AudioClip>();
    public static List<AudioClip> DirtRunClips = new List<AudioClip>();
    public static List<AudioClip> DirtSprintClips = new List<AudioClip>();
    public static List<AudioClip> DirtTurnClips = new List<AudioClip>();

    public static List<AudioClip> GravelWalkClips = new List<AudioClip>();
    public static List<AudioClip> GravelRunClips = new List<AudioClip>();
    public static List<AudioClip> GravelSprintClips = new List<AudioClip>();
    public static List<AudioClip> GravelTurnClips = new List<AudioClip>();

    public static List<AudioClip> LeavesWalkClips = new List<AudioClip>();
    public static List<AudioClip> LeavesRunClips = new List<AudioClip>();
    public static List<AudioClip> LeavesSprintClips = new List<AudioClip>();
    public static List<AudioClip> LeavesTurnClips = new List<AudioClip>();

    public static List<AudioClip> MarbleWalkClips = new List<AudioClip>();
    public static List<AudioClip> MarbleRunClips = new List<AudioClip>();
    public static List<AudioClip> MarbleSprintClips = new List<AudioClip>();
    public static List<AudioClip> MarbleTurnClips = new List<AudioClip>();

    public static List<AudioClip> MetalWalkClips = new List<AudioClip>();
    public static List<AudioClip> MetalRunClips = new List<AudioClip>();
    public static List<AudioClip> MetalSprintClips = new List<AudioClip>();
    public static List<AudioClip> MetalTurnClips = new List<AudioClip>();

    public static List<AudioClip> MudWalkClips = new List<AudioClip>();
    public static List<AudioClip> MudRunClips = new List<AudioClip>();
    public static List<AudioClip> MudSprintClips = new List<AudioClip>();
    public static List<AudioClip> MudTurnClips = new List<AudioClip>();

    public static List<AudioClip> SandDryWalkClips = new List<AudioClip>();
    public static List<AudioClip> SandDryRunClips = new List<AudioClip>();
    public static List<AudioClip> SandDrySprintClips = new List<AudioClip>();
    public static List<AudioClip> SandDryTurnClips = new List<AudioClip>();

    public static List<AudioClip> SandWetWalkClips = new List<AudioClip>();
    public static List<AudioClip> SandWetRunClips = new List<AudioClip>();
    public static List<AudioClip> SandWetSprintClips = new List<AudioClip>();
    public static List<AudioClip> SandWetTurnClips = new List<AudioClip>();

    public static List<AudioClip> SnowWalkClips = new List<AudioClip>();
    public static List<AudioClip> SnowRunClips = new List<AudioClip>();
    public static List<AudioClip> SnowSprintClips = new List<AudioClip>();
    public static List<AudioClip> SnowTurnClips = new List<AudioClip>();

    public static List<AudioClip> WoodWalkClips = new List<AudioClip>();
    public static List<AudioClip> WoodRunClips = new List<AudioClip>();
    public static List<AudioClip> WoodSprintClips = new List<AudioClip>();
    public static List<AudioClip> WoodTurnClips = new List<AudioClip>();

    public static List<AudioClip> WoodRugWalkClips = new List<AudioClip>();
    public static List<AudioClip> WoodRugRunClips = new List<AudioClip>();
    public static List<AudioClip> WoodRugSprintClips = new List<AudioClip>();
    public static List<AudioClip> WoodRugTurnClips = new List<AudioClip>();

    public static List<AudioClip> WoodSolidWalkClips = new List<AudioClip>();
    public static List<AudioClip> WoodSolidRunClips = new List<AudioClip>();
    public static List<AudioClip> WoodSolidSprintClips = new List<AudioClip>();
    public static List<AudioClip> WoodSolidTurnClips = new List<AudioClip>();


    public void Awake()
    {
        _footstepSource = GameObject.Find("Footsteps").GetComponent<AudioSource>();
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        ConcreteTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        ConcreteGrittyTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        CreakyFloorTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        CreakyRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        CreakyRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        CreakyRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        CreakyRugTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);



        DeckWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        DeckRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        DeckSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        DeckTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        DirtTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        GravelTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        LeavesTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        MarbleWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        MarbleRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        MarbleSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        MarbleTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        MetalWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        MetalRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        MetalSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        MetalTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        MudTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        SandDryTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        SandWetTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        SnowWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        SnowRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        SnowSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        SnowTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_2") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_3") as AudioClip);

        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_2") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_3") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_4") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_5") as AudioClip);

        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_2") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_3") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_4") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_5") as AudioClip);

        WoodTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);
        WoodTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_2") as AudioClip);
        WoodTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_3") as AudioClip);


        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        WoodRugTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        WoodSolidTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);
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
                PlayRunningFootstep(Emmon.Instance.Ground);
        }
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Sprinting)
        {
            if (!_footstepSource.isPlaying)
                PlaySprintingFootstep(Emmon.Instance.Ground);
        } 
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Turning)
        {
            if (!_footstepSource.isPlaying)
                PlayTurningFootstep(Emmon.Instance.Ground);
        }
    }

    public void PlayWalkingFootstep(CharacterControllerLogic.WalkGround ground)
    {
        int randomClip = 0;
        switch (ground)
        {
            case CharacterControllerLogic.WalkGround.Concrete:
                randomClip = Random.Range(0, ConcreteWalkClips.Count);
                _footstepSource.clip = ConcreteWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.ConcreteGritty:
                randomClip = Random.Range(0, ConcreteGrittyWalkClips.Count);
                _footstepSource.clip = ConcreteGrittyWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyFloor:
                randomClip = Random.Range(0, CreakyFloorWalkClips.Count);
                _footstepSource.clip = CreakyFloorWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyRug:
                randomClip = Random.Range(0, CreakyRugWalkClips.Count);
                _footstepSource.clip = CreakyRugWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Deck:
                randomClip = Random.Range(0, DeckWalkClips.Count);
                _footstepSource.clip = DeckWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Dirt:
                randomClip = Random.Range(0, DirtWalkClips.Count);
                _footstepSource.clip = DirtWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Gravel:
                randomClip = Random.Range(0, GravelWalkClips.Count);
                _footstepSource.clip = GravelWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Leaves:
                randomClip = Random.Range(0, LeavesWalkClips.Count);
                _footstepSource.clip = LeavesWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Marble:
                randomClip = Random.Range(0, MarbleWalkClips.Count);
                _footstepSource.clip = MarbleWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Metal:
                randomClip = Random.Range(0, MetalWalkClips.Count);
                _footstepSource.clip = MetalWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Mud:
                randomClip = Random.Range(0, MudWalkClips.Count);
                _footstepSource.clip = MudWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandDry:
                randomClip = Random.Range(0, SandDryWalkClips.Count);
                _footstepSource.clip = SandDryWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandWet:
                randomClip = Random.Range(0, SandWetWalkClips.Count);
                _footstepSource.clip = SandWetWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Snow:
                randomClip = Random.Range(0, SnowWalkClips.Count);
                _footstepSource.clip = SnowWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Wood:
                randomClip = Random.Range(0, WoodWalkClips.Count);
                _footstepSource.clip = WoodWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodRug:
                randomClip = Random.Range(0, WoodRugWalkClips.Count);
                _footstepSource.clip = WoodRugWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodSolid:
                randomClip = Random.Range(0, WoodSolidWalkClips.Count);
                _footstepSource.clip = WoodSolidWalkClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.None:
                randomClip = Random.Range(0, WoodWalkClips.Count);
                _footstepSource.clip = WoodWalkClips[randomClip];
                _footstepSource.Play();
                break;
            default:
                randomClip = Random.Range(0, WoodWalkClips.Count);
                _footstepSource.clip = WoodWalkClips[randomClip];
                _footstepSource.Play();
                break;
        }
    }

    public void PlayRunningFootstep(CharacterControllerLogic.WalkGround ground)
    {
        int randomClip = 0;
        switch (ground)
        {
            case CharacterControllerLogic.WalkGround.Concrete:
                randomClip = Random.Range(0, ConcreteRunClips.Count);
                _footstepSource.clip = ConcreteRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.ConcreteGritty:
                randomClip = Random.Range(0, ConcreteGrittyRunClips.Count);
                _footstepSource.clip = ConcreteGrittyRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyFloor:
                randomClip = Random.Range(0, CreakyFloorRunClips.Count);
                _footstepSource.clip = CreakyFloorRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyRug:
                randomClip = Random.Range(0, CreakyRugRunClips.Count);
                _footstepSource.clip = CreakyRugRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Deck:
                randomClip = Random.Range(0, DeckRunClips.Count);
                _footstepSource.clip = DeckRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Dirt:
                randomClip = Random.Range(0, DirtRunClips.Count);
                _footstepSource.clip = DirtRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Gravel:
                randomClip = Random.Range(0, GravelRunClips.Count);
                _footstepSource.clip = GravelRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Leaves:
                randomClip = Random.Range(0, LeavesRunClips.Count);
                _footstepSource.clip = LeavesRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Marble:
                randomClip = Random.Range(0, MarbleRunClips.Count);
                _footstepSource.clip = MarbleRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Metal:
                randomClip = Random.Range(0, MetalRunClips.Count);
                _footstepSource.clip = MetalRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Mud:
                randomClip = Random.Range(0, MudRunClips.Count);
                _footstepSource.clip = MudRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandDry:
                randomClip = Random.Range(0, SandDryRunClips.Count);
                _footstepSource.clip = SandDryRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandWet:
                randomClip = Random.Range(0, SandWetRunClips.Count);
                _footstepSource.clip = SandWetRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Snow:
                randomClip = Random.Range(0, SnowRunClips.Count);
                _footstepSource.clip = SnowRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Wood:
                randomClip = Random.Range(0, WoodRunClips.Count);
                _footstepSource.clip = WoodRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodRug:
                randomClip = Random.Range(0, WoodRugRunClips.Count);
                _footstepSource.clip = WoodRugRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodSolid:
                randomClip = Random.Range(0, WoodSolidRunClips.Count);
                _footstepSource.clip = WoodSolidRunClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.None:
                randomClip = Random.Range(0, WoodRunClips.Count);
                _footstepSource.clip = WoodRunClips[randomClip];
                _footstepSource.Play();
                break;
            default:
                randomClip = Random.Range(0, WoodRunClips.Count);
                _footstepSource.clip = WoodRunClips[randomClip];
                _footstepSource.Play();
                break;
        }
    }

    public void PlaySprintingFootstep(CharacterControllerLogic.WalkGround ground)
    {
        int randomClip = Random.Range(0, WoodWalkClips.Count);
        _footstepSource.clip = WoodWalkClips[randomClip];
        _footstepSource.Play();
    }

    public void PlayTurningFootstep(CharacterControllerLogic.WalkGround ground)
    {
        int randomClip = 0;
        switch (ground)
        {
            case CharacterControllerLogic.WalkGround.Concrete:
                randomClip = Random.Range(0, ConcreteTurnClips.Count);
                _footstepSource.clip = ConcreteTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.ConcreteGritty:
                randomClip = Random.Range(0, ConcreteGrittyTurnClips.Count);
                _footstepSource.clip = ConcreteGrittyTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyFloor:
                randomClip = Random.Range(0, CreakyFloorTurnClips.Count);
                _footstepSource.clip = CreakyFloorTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyRug:
                randomClip = Random.Range(0, CreakyRugTurnClips.Count);
                _footstepSource.clip = CreakyRugTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Deck:
                randomClip = Random.Range(0, DeckTurnClips.Count);
                _footstepSource.clip = DeckTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Dirt:
                randomClip = Random.Range(0, DirtTurnClips.Count);
                _footstepSource.clip = DirtTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Gravel:
                randomClip = Random.Range(0, GravelTurnClips.Count);
                _footstepSource.clip = GravelTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Leaves:
                randomClip = Random.Range(0, LeavesTurnClips.Count);
                _footstepSource.clip = LeavesTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Marble:
                randomClip = Random.Range(0, MarbleTurnClips.Count);
                _footstepSource.clip = MarbleTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Metal:
                randomClip = Random.Range(0, MetalTurnClips.Count);
                _footstepSource.clip = MetalTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Mud:
                randomClip = Random.Range(0, MudTurnClips.Count);
                _footstepSource.clip = MudTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandDry:
                randomClip = Random.Range(0, SandDryTurnClips.Count);
                _footstepSource.clip = SandDryTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandWet:
                randomClip = Random.Range(0, SandWetTurnClips.Count);
                _footstepSource.clip = SandWetTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Snow:
                randomClip = Random.Range(0, SnowTurnClips.Count);
                _footstepSource.clip = SnowTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Wood:
                randomClip = Random.Range(0, WoodTurnClips.Count);
                _footstepSource.clip = WoodTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodRug:
                randomClip = Random.Range(0, WoodRugTurnClips.Count);
                _footstepSource.clip = WoodRugTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodSolid:
                randomClip = Random.Range(0, WoodSolidTurnClips.Count);
                _footstepSource.clip = WoodSolidTurnClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.None:
                randomClip = Random.Range(0, WoodTurnClips.Count);
                _footstepSource.clip = WoodTurnClips[randomClip];
                _footstepSource.Play();
                break;
            default:
                randomClip = Random.Range(0, WoodTurnClips.Count);
                _footstepSource.clip = WoodTurnClips[randomClip];
                _footstepSource.Play();
                break;
        }
    }
}