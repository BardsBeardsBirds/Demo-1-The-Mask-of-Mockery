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

        //Concrete
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 1") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 2") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 3") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 4") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 5") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 6") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 7") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 8") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 9") as AudioClip);
        ConcreteWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole walk 10") as AudioClip);

        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 1") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 2") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 3") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 4") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 5") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 6") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 7") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 8") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 9") as AudioClip);
        ConcreteRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole run 10") as AudioClip);

        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 1") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 2") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 3") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 4") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 5") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 6") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 7") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 8") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 9") as AudioClip);
        ConcreteSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole sprint 10") as AudioClip);

        ConcreteTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole turn 1") as AudioClip);
        ConcreteTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole turn 2") as AudioClip);
        ConcreteTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole turn 3") as AudioClip);
        ConcreteTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Concrete/Male leather sole turn 4") as AudioClip);

        //Concrete Gritty
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 1") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 2") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 3") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 4") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 5") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 6") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 7") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 8") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 9") as AudioClip);
        ConcreteGrittyWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole walk 10") as AudioClip);

        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 1") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 2") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 3") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 4") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 5") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 6") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 7") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 8") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 9") as AudioClip);
        ConcreteGrittyRunClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole run 10") as AudioClip);

        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 1") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 2") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 3") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 4") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 5") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 6") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 7") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 8") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 9") as AudioClip);
        ConcreteGrittySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole sprint 10") as AudioClip);

        ConcreteGrittyTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole turn 1") as AudioClip);
        ConcreteGrittyTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole turn 2") as AudioClip);
        ConcreteGrittyTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/ConcreteGritty/Male leather sole turn 3") as AudioClip);

        //Creaky Floor
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 1") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 2") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 3") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 4") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 5") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 6") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 7") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 8") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 9") as AudioClip);
        CreakyFloorWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers walk 10") as AudioClip);

        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 1") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 2") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 3") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 4") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 5") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 6") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 7") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 8") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 9") as AudioClip);
        CreakyFloorRunClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers run 10") as AudioClip);

        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 1") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 2") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 3") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 4") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 5") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 6") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 7") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 8") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 9") as AudioClip);
        CreakyFloorSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers sprint 10") as AudioClip);

        CreakyFloorTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers turn 1") as AudioClip);
        CreakyFloorTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers turn 2") as AudioClip);
        CreakyFloorTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/CreakyFloor/Male sneakers turn 3") as AudioClip);


        CreakyRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        CreakyRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        CreakyRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        CreakyRugTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);



        DeckWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        DeckRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        DeckSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        DeckTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);

        //Dirt
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 1") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 2") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 3") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 4") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 5") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 6") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 7") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 8") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 9") as AudioClip);
        DirtWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole walk 10") as AudioClip);

        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 1") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 2") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 3") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 4") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 5") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 6") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 7") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 8") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 9") as AudioClip);
        DirtRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole run 10") as AudioClip);

        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 1") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 2") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 3") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 4") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 5") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 6") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 7") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 8") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 9") as AudioClip);
        DirtSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole sprint 10") as AudioClip);

        DirtTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole turn 1") as AudioClip);
        DirtTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole turn 2") as AudioClip);
        DirtTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole turn 3") as AudioClip);
        DirtTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Dirt/Male leather sole turn 4") as AudioClip);

        //Gravel
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 1") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 2") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 3") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 4") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 5") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 6") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 7") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 8") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 9") as AudioClip);
        GravelWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe walk 10") as AudioClip);

        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 1") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 2") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 3") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 4") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 5") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 6") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 7") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 8") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 9") as AudioClip);
        GravelRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe run 10") as AudioClip);

        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 1") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 2") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 3") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 4") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 5") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 6") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 7") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 8") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 9") as AudioClip);
        GravelSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe sprint 10") as AudioClip);

        GravelTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe turn 1") as AudioClip);
        GravelTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe turn 2") as AudioClip);
        GravelTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe turn 3") as AudioClip);
        GravelTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Gravel/Male shoe turn 4") as AudioClip);

        //Leaves
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 1") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 2") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 3") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 4") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 5") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 6") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 7") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 8") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 9") as AudioClip);
        LeavesWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe walk 10") as AudioClip);

        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 1") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 2") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 3") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 4") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 5") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 6") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 7") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 8") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 9") as AudioClip);
        LeavesRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe run 10") as AudioClip);

        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 1") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 2") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 3") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 4") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 5") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 6") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 7") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 8") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 9") as AudioClip);
        LeavesSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe sprint 10") as AudioClip);

        LeavesTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe turn 1") as AudioClip);
        LeavesTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe turn 2") as AudioClip);
        LeavesTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe turn 3") as AudioClip);
        LeavesTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Leaves/Male shoe turn 4") as AudioClip);


        MarbleWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        MarbleRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        MarbleSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        MarbleTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);


        MetalWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        MetalRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        MetalSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        MetalTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);

        //Mud
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 1") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 2") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 3") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 4") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 5") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 6") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 7") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 8") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 9") as AudioClip);
        MudWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole walk 10") as AudioClip);

        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 1") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 2") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 3") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 4") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 5") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 6") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 7") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 8") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 9") as AudioClip);
        MudRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole run 10") as AudioClip);

        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 1") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 2") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 3") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 4") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 5") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 6") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 7") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 8") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 9") as AudioClip);
        MudSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole sprint 10") as AudioClip);

        MudTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole turn 1") as AudioClip);
        MudTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole turn 2") as AudioClip);
        MudTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole turn 3") as AudioClip);
        MudTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Mud/Male leather sole turn 4") as AudioClip);

        //Sand Dry
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 1") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 2") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 3") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 4") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 5") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 6") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 7") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 8") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 9") as AudioClip);
        SandDryWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole walk 10") as AudioClip);

        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 1") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 2") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 3") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 4") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 5") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 6") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 7") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 8") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 9") as AudioClip);
        SandDryRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole run 10") as AudioClip);

        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 1") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 2") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 3") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 4") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 5") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 6") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 7") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 8") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 9") as AudioClip);
        SandDrySprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole sprint 10") as AudioClip);

        SandDryTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole turn 1") as AudioClip);
        SandDryTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole turn 2") as AudioClip);
        SandDryTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/SandDry/Male leather sole turn 3") as AudioClip);

        //Sand Wet
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 1") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 2") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 3") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 4") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 5") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 6") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 7") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 8") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 9") as AudioClip);
        SandWetWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole walk 10") as AudioClip);

        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 1") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 2") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 3") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 4") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 5") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 6") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 7") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 8") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 9") as AudioClip);
        SandWetRunClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole run 10") as AudioClip);

        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 1") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 2") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 3") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 4") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 5") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 6") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 7") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 8") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 9") as AudioClip);
        SandWetSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole sprint 10") as AudioClip);

        SandWetTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole turn 1") as AudioClip);
        SandWetTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole turn 2") as AudioClip);
        SandWetTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/SandWet/Male leather sole turn 3") as AudioClip);

        SnowWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_walk_carpet_1") as AudioClip);

        SnowRunClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_run_carpet_1") as AudioClip);

        SnowSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_sprint_carpet_1") as AudioClip);

        SnowTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/footsteps_lending_carpet_1") as AudioClip);

        //Wood
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 1") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 2") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 3") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 4") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 5") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 6") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 7") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 8") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 9") as AudioClip);
        WoodWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole walk 10") as AudioClip);

        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 1") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 2") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 3") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 4") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 5") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 6") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 7") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 8") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 9") as AudioClip);
        WoodRunClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 10") as AudioClip);

        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 1") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 2") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 3") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 4") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 5") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 6") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 7") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 8") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 9") as AudioClip);
        WoodSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole run 10") as AudioClip);

        WoodTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole turn 1") as AudioClip);
        WoodTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole turn 2") as AudioClip);
        WoodTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/Wood/Male leather sole turn 3") as AudioClip);

        //Wood Rug
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 1") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 2") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 3") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 4") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 5") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 6") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 7") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 8") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 9") as AudioClip);
        WoodRugWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole walk 10") as AudioClip);

        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 1") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 2") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 3") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 4") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 5") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 6") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 7") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 8") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 9") as AudioClip);
        WoodRugRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 10") as AudioClip);

        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 1") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 2") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 3") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 4") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 5") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 6") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 7") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 8") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 9") as AudioClip);
        WoodRugSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole run 10") as AudioClip);

        WoodRugTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole turn 1") as AudioClip);
        WoodRugTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole turn 2") as AudioClip);
        WoodRugTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodRug/Male leather sole turn 3") as AudioClip);

        //Wood Solid
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 1") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 2") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 3") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 4") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 5") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 6") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 7") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 8") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 9") as AudioClip);
        WoodSolidWalkClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole walk 10") as AudioClip);

        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 1") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 2") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 3") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 4") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 5") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 6") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 7") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 8") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 9") as AudioClip);
        WoodSolidRunClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 10") as AudioClip);

        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 1") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 2") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 3") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 4") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 5") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 6") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 7") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 8") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 9") as AudioClip);
        WoodSolidSprintClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole run 10") as AudioClip);

        WoodSolidTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole turn 1") as AudioClip);
        WoodSolidTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole turn 2") as AudioClip);
        WoodSolidTurnClips.Add(Resources.Load("Audio/Effects/Footsteps/WoodSolid/Male leather sole turn 3") as AudioClip);
    }

    public void Update()
    {
        if (CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Falling ||
            CharacterControllerLogic.Instance.State == CharacterControllerLogic.CharacterState.Sliding)
            return;

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
        Debug.Log(ground);

        int randomClip = 0;
        switch (ground)
        {
            case CharacterControllerLogic.WalkGround.Concrete:
                randomClip = Random.Range(0, ConcreteSprintClips.Count);
                _footstepSource.clip = ConcreteSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.ConcreteGritty:
                randomClip = Random.Range(0, ConcreteGrittySprintClips.Count);
                _footstepSource.clip = ConcreteGrittySprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyFloor:
                randomClip = Random.Range(0, CreakyFloorSprintClips.Count);
                _footstepSource.clip = CreakyFloorSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyRug:
                randomClip = Random.Range(0, CreakyRugSprintClips.Count);
                _footstepSource.clip = CreakyRugSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Deck:
                randomClip = Random.Range(0, DeckSprintClips.Count);
                _footstepSource.clip = DeckSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Dirt:
                randomClip = Random.Range(0, DirtSprintClips.Count);
                _footstepSource.clip = DirtSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Gravel:
                randomClip = Random.Range(0, GravelSprintClips.Count);
                _footstepSource.clip = GravelSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Leaves:
                randomClip = Random.Range(0, LeavesSprintClips.Count);
                _footstepSource.clip = LeavesSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Marble:
                randomClip = Random.Range(0, MarbleSprintClips.Count);
                _footstepSource.clip = MarbleSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Metal:
                randomClip = Random.Range(0, MetalSprintClips.Count);
                _footstepSource.clip = MetalSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Mud:
                randomClip = Random.Range(0, MudSprintClips.Count);
                _footstepSource.clip = MudSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandDry:
                randomClip = Random.Range(0, SandDrySprintClips.Count);
                _footstepSource.clip = SandDrySprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandWet:
                randomClip = Random.Range(0, SandWetSprintClips.Count);
                _footstepSource.clip = SandWetSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Snow:
                randomClip = Random.Range(0, SnowSprintClips.Count);
                _footstepSource.clip = SnowSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Wood:
                randomClip = Random.Range(0, WoodSprintClips.Count);
                _footstepSource.clip = WoodSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodRug:
                randomClip = Random.Range(0, WoodRugSprintClips.Count);
                _footstepSource.clip = WoodRugSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodSolid:
                randomClip = Random.Range(0, WoodSolidSprintClips.Count);
                _footstepSource.clip = WoodSolidSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.None:
                randomClip = Random.Range(0, WoodSprintClips.Count);
                _footstepSource.clip = WoodSprintClips[randomClip];
                _footstepSource.Play();
                break;
            default:
                randomClip = Random.Range(0, WoodSprintClips.Count);
                _footstepSource.clip = WoodSprintClips[randomClip];
                _footstepSource.Play();
                break;
        }
    }

    public void PlaySprintingFootstep(CharacterControllerLogic.WalkGround ground)
    {
        int randomClip = 0;
        switch (ground)
        {
            case CharacterControllerLogic.WalkGround.Concrete:
                randomClip = Random.Range(0, ConcreteSprintClips.Count);
                _footstepSource.clip = ConcreteSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.ConcreteGritty:
                randomClip = Random.Range(0, ConcreteGrittySprintClips.Count);
                _footstepSource.clip = ConcreteGrittySprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyFloor:
                randomClip = Random.Range(0, CreakyFloorSprintClips.Count);
                _footstepSource.clip = CreakyFloorSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.CreakyRug:
                randomClip = Random.Range(0, CreakyRugSprintClips.Count);
                _footstepSource.clip = CreakyRugSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Deck:
                randomClip = Random.Range(0, DeckSprintClips.Count);
                _footstepSource.clip = DeckSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Dirt:
                randomClip = Random.Range(0, DirtSprintClips.Count);
                _footstepSource.clip = DirtSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Gravel:
                randomClip = Random.Range(0, GravelSprintClips.Count);
                _footstepSource.clip = GravelSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Leaves:
                randomClip = Random.Range(0, LeavesSprintClips.Count);
                _footstepSource.clip = LeavesSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Marble:
                randomClip = Random.Range(0, MarbleSprintClips.Count);
                _footstepSource.clip = MarbleSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Metal:
                randomClip = Random.Range(0, MetalSprintClips.Count);
                _footstepSource.clip = MetalSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Mud:
                randomClip = Random.Range(0, MudSprintClips.Count);
                _footstepSource.clip = MudSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandDry:
                randomClip = Random.Range(0, SandDrySprintClips.Count);
                _footstepSource.clip = SandDrySprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.SandWet:
                randomClip = Random.Range(0, SandWetSprintClips.Count);
                _footstepSource.clip = SandWetSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Snow:
                randomClip = Random.Range(0, SnowSprintClips.Count);
                _footstepSource.clip = SnowSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.Wood:
                randomClip = Random.Range(0, WoodSprintClips.Count);
                _footstepSource.clip = WoodSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodRug:
                randomClip = Random.Range(0, WoodRugSprintClips.Count);
                _footstepSource.clip = WoodRugSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.WoodSolid:
                randomClip = Random.Range(0, WoodSolidSprintClips.Count);
                _footstepSource.clip = WoodSolidSprintClips[randomClip];
                _footstepSource.Play();
                break;
            case CharacterControllerLogic.WalkGround.None:
                randomClip = Random.Range(0, WoodSprintClips.Count);
                _footstepSource.clip = WoodSprintClips[randomClip];
                _footstepSource.Play();
                break;
            default:
                randomClip = Random.Range(0, WoodSprintClips.Count);
                _footstepSource.clip = WoodSprintClips[randomClip];
                _footstepSource.Play();
                break;
        }
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