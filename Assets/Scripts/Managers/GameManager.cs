using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public enum GameMode { Paused, Running, IntroMode, DeadMode, MissionAccomplished };
    public enum GameType { NewGame, LoadFromMenu, LoadFromInGame, None};

    public AudioMixerGroup Mixer;

    public static GameManager Instance;

    public int RupeeHeld;

    public Portal DebugSpawn;
    public GameObject GameManagerObj;
    public MainCanvas UICanvas;

    public static GameObject Player;
    public Inventory MyInventory;
    public InGameObjectManager InGameObjectM;
    public InventoryCombinations IIventoryItemWithObject = null;

    private GameObject _ay;
    private GameObject _benny;
    private GameObject _sentinel;

    public static GameMode GamePlayingMode;
    public static GameType MyGameType;

    public static AudioSource AudioSource1;
    public static AudioSource AudioSource2;

    private bool _showConsole = false;

    public static Dictionary<int, SpokenLine> AyDialogue = new Dictionary<int, SpokenLine>();     //TODO: Change into Dictionaries <ID>, <Spokenline>, so we can get rid of loops 
    public static Dictionary<int, SpokenLine> BennyDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> SentinelDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> ObjectInvestigationDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> ObjectInteractionDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> InventoryInvestigationDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> InventoryInteractionDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> InventoryCombinationDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> ItemWorldCombinationDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> RandomNoDialogue = new Dictionary<int, SpokenLine>();
    public static Dictionary<int, SpokenLine> IntroDialogue = new Dictionary<int, SpokenLine>();

    public static Dictionary<Character, Transform> NPCs = new Dictionary<Character, Transform>();
    public static Dictionary<Character, Dictionary<int, SpokenLine>> CharacterDialogueLists = new Dictionary<Character, Dictionary<int, SpokenLine>>()
    { 
        {Character.Ay, AyDialogue},
        {Character.Benny, BennyDialogue},
        {Character.Sentinel, SentinelDialogue},
    };

    public void Awake()
    {     
        Instance = this;

        bool newGame = IsThisGameNew();
        if (newGame)
            MyGameType = GameType.NewGame;
        else
            MyGameType = GameType.LoadFromMenu;

        Debug.Log("MyGameType " + MyGameType);

        if (MyGameType == GameType.NewGame)
            GameStateToIntro();

        FadeBlackToClear();

        ///Setting up the level>>
        SetPlayerPosition(); 
        LoadManagers();
        FindCharacters();
     //   LoadDialogues();
        ///Setting up the level<<

        if (UICanvas == null)
            UICanvas = GameObject.Find("Canvas").GetComponent<MainCanvas>();

        if (MyGameType == GameType.NewGame)
            SetInitialBools();

        InGameObjectManager.Instance.LoadInGameObjectsInfo();  //see what objects should be turned on or off
        IIventoryItemWithObject = new InventoryCombinations();
    }

    public void Start()
    {
        Debug.Log(GamePlayingMode);
    }

    private void LoadManagers()
    {
        AudioSource1 = Instance.gameObject.AddComponent<AudioSource>() as AudioSource;
        AudioSource2 = Instance.gameObject.AddComponent<AudioSource>() as AudioSource;

        GameManagerObj = this.gameObject;

        GameManagerObj.AddComponent<AudioManager>();
        GameManagerObj.AddComponent<TimeManager>();
        GameManagerObj.AddComponent<AreaManager>();
        GameManagerObj.AddComponent<ItemManager>();
        GameManagerObj.AddComponent<DialogueMenu>();
        GameManagerObj.AddComponent<DialoguePlayback>();
        InGameObjectM = GameManagerObj.AddComponent<InGameObjectManager>();
    }

    public void FindCharacters()
    {
        _benny = GameObject.Find("Benny Twospoons");
        _benny.AddComponent<BennyTwospoons>();
        NPCs.Add(Character.Benny, _benny.transform);

        _sentinel = GameObject.Find("Sentinel");
        _sentinel.AddComponent<Sentinel>();
        NPCs.Add(Character.Sentinel, _sentinel.transform);

        _ay = GameObject.Find("Ay the Tear Collector");
        _ay.AddComponent<AyTheTearCollector>();
        NPCs.Add(Character.Ay, _ay.transform);

        NPCs.Add(Character.Emmon, Player.transform);
    }

    public void SetPlayerPosition()
    {
        Player = GameObject.Find("Emmon");

        if (Player == null)
            Debug.LogError("Couldn't find the player!");

        Debug.Log("set player position");
        Player.transform.position = new Vector3(-31f, 5.5f, 145f);
        Player.transform.rotation = new Quaternion(0.0f, -0.1f, 0.0f, -1.0f);
    }

    public void ChangeMoney(int amount)
    {
        int amountToChange = amount;
        if (amount > 0)
        {
            UICanvas.MoneyOnScreen.Plus = true;
            StartCoroutine(AddOneToCoins(amountToChange));
        }
        else
        {
            UICanvas.MoneyOnScreen.Minus = true;
            StartCoroutine(SubtractOneToCoins(amountToChange));
        }
        MyConsole.WriteToConsole("We have now " + RupeeHeld + " rupees");
    }


    public IEnumerator AddOneToCoins(int amountToChange)
    {
        for (int i = 0; i < amountToChange; i++)    //only for positive numbers
        {
            RupeeHeld = RupeeHeld + 1;

            UICanvas.MoneyOnScreen.DisplayDifferentAmount(RupeeHeld);

            yield return StartCoroutine(WaitFor.Frames(2));

        }
        UICanvas.MoneyOnScreen.Plus = false;
    }

    public IEnumerator SubtractOneToCoins(int amountToChange)
    {
        for (int i = 0; i > amountToChange; i--)    //only for positive numbers
        {
            RupeeHeld = RupeeHeld - 1;

            UICanvas.MoneyOnScreen.DisplayDifferentAmount(RupeeHeld);

            yield return StartCoroutine(WaitFor.Frames(2));

        }
        UICanvas.MoneyOnScreen.Minus = false;
    }

    public void Update()
    {
        //CONSOLE
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (MyConsole.ShowConsole)
                MyConsole.ShowConsole = false;
            else
                MyConsole.ShowConsole = true;
        }

        if (GamePlayingMode == GameMode.Running)
        {
            //INVENTORY
            if (Input.GetKeyDown(KeyCode.I))
            {
                UICanvas.OpenCloseInventory();
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {

            }

            //PAUSE MENU
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UICanvas.PauseMenuCanvas.GetComponent<PauseMenu>().PauseGame();
            }

            if (Input.GetKeyUp(KeyCode.N))
            {
                Debug.Log("EmmonWasBlockedBySentinel" + WorldEvents.EmmonKnowsWhatSentinelWants);
                Debug.Log("EmmonHasRoughneckShot" + WorldEvents.EmmonHasRoughneckShot);
                Debug.Log("PickedUpMaskOfMockery" + InGameObjectManager.PickedUpMaskOfMockery);
                Debug.Log("EmmonKnowsAy" + WorldEvents.EmmonKnowsAy);
                Debug.Log("EmmonKnowsBenny" + WorldEvents.EmmonKnowsBenny);
                Debug.Log("BennyHasOfferedLute" + WorldEvents.BennyHasOfferedLute);
                Debug.Log("EmmonSawTheLute" + WorldEvents.EmmonSawTheLute);
                Debug.Log("EmmonKnowsMaskLocation" + WorldEvents.EmmonKnowsMaskLocation);
                Debug.Log("EmmonHasPassedTheSentinel" + WorldEvents.EmmonHasPassedTheSentinel);
                Debug.Log("MissionAccomplished" + WorldEvents.MissionAccomplished);
            }

            if(Input.GetKeyDown(KeyCode.M))
            {
                WorldEvents.EmmonKnowsWhatSentinelWants = true;
                WorldEvents.EmmonHasRoughneckShot = true;
                WorldEvents.EmmonKnowsAy = true;
                WorldEvents.EmmonKnowsBenny = true;
                WorldEvents.BennyHasOfferedLute = true;
                WorldEvents.EmmonSawTheLute = true;
                WorldEvents.EmmonKnowsMaskLocation = true;
                WorldEvents.EmmonHasPassedTheSentinel = true;
                WorldEvents.MissionAccomplished = false;
                InGameObjectManager.PickedUpMaskOfMockery = true;

                Debug.Log("Changed event settings!");
                Debug.Log("EmmonWasBlockedBySentinel" + WorldEvents.EmmonKnowsWhatSentinelWants);
                Debug.Log("EmmonHasRoughneckShot" + WorldEvents.EmmonHasRoughneckShot);
                Debug.Log("PickedUpMaskOfMockery" + InGameObjectManager.PickedUpMaskOfMockery);
                Debug.Log("EmmonKnowsAy" + WorldEvents.EmmonKnowsAy);
                Debug.Log("EmmonKnowsBenny" + WorldEvents.EmmonKnowsBenny);
                Debug.Log("BennyHasOfferedLute" + WorldEvents.BennyHasOfferedLute);
                Debug.Log("EmmonSawTheLute" + WorldEvents.EmmonSawTheLute);
                Debug.Log("EmmonKnowsMaskLocation" + WorldEvents.EmmonKnowsMaskLocation);
                Debug.Log("EmmonHasPassedTheSentinel" + WorldEvents.EmmonHasPassedTheSentinel);
                Debug.Log("MissionAccomplished" + WorldEvents.MissionAccomplished);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Escape))  //closing menu
        {
            if(Time.timeScale != 1)
                UICanvas.PauseMenuCanvas.GetComponent<PauseMenu>().ResumeGame();
        }
    }



    public static void Destroy(string name)
    {
        var go = GameObject.Find(name);
        if(go != null )
            Destroy(go);
    }

    public void DidLockCursor()
    {
        Cursor.visible = true;
    }

    public void DidUnlockCursor()
    {
        Cursor.visible = false;
    }

    public Inventory FindInventory()
    {
        Inventory inventory = null;

        foreach (Transform child in UICanvas.InventoryCanvasGO.transform)
        {
            //Debug.LogWarning("going over child: " + child.name);
            if (child.name == "InventoryPanel")
            {
                inventory = child.GetComponent<Inventory>(); ;
                Debug.LogWarning("found inventory");
                break;
            }
        }

        if (inventory == null)
            Debug.LogError("we couldnt find the inventory!");

        return inventory;
    }


    private bool IsThisGameNew()
    {
        if (File.Exists("NewGame.txt"))    
        {
            var sr = File.OpenText("NewGame.txt");
            var line = sr.ReadLine();
            while (line != null)
            {
                Debug.LogWarning(line); // prints each line of the file
                if (line == "This is not a new game")
                {
                    return false;
                }
                else if
                    (line == "This is a new game")
                    return true;
                else
                {
                    Debug.LogError("unexpected text in file: " + line);
                }
            }   
        }
        else
            Debug.LogError("cannot find the file NewGame.txt");
        return true;
    }

    private void SetInitialBools()
    {
        Debug.Log("reset all events");
        WorldEvents.EmmonKnowsWhatSentinelWants = false;
        WorldEvents.EmmonHasRoughneckShot = false;
        //WorldEvents.EmmonHasMaskOfMockery = false;
        WorldEvents.EmmonKnowsAy = false;
        WorldEvents.EmmonKnowsBenny = false;
        WorldEvents.BennyHasOfferedLute = false;
        WorldEvents.EmmonSawTheLute = false;
        WorldEvents.EmmonKnowsMaskLocation = false;
        WorldEvents.EmmonHasPassedTheSentinel = false;
        WorldEvents.MissionAccomplished = false;

        InGameObjectManager.PickedUpCarrot = false;
        InGameObjectManager.PickedUpMaskOfMockery = false;
    }

    public void FadeBlackToClear()
    {
        GameObject sceneFaderGO = null;

        foreach (Transform trans in UICanvas.transform)
        {
            if (trans.gameObject.name == "ScreenFaderBlackToClear")
                sceneFaderGO = trans.gameObject;
        }

        if (sceneFaderGO == null)
            Debug.Log("could not find fader go!");

        sceneFaderGO.SetActive(true);

        SceneFader fader = sceneFaderGO.GetComponent<SceneFader>();
        if (MyGameType == GameType.NewGame)
            fader.ClearFader = SceneFader.ToClear.StartFromNew;
        else
        {
            fader.BlackImage.color = new Color(0, 0, 0, 1);
            fader.ClearFader = SceneFader.ToClear.StartFromLoad;
            Debug.Log("fader from load");
        }

        fader.IsFadingToClear = true;
    }

    public void LoadEventConsequences()
    {
        if (WorldEvents.EmmonKnowsAy)
        {
            DialogueManager.AddToPassedDialogueLines(1003);
            MouseClickOnObject.ObjectLines[ObjectsInLevel.AyTheTearCollector] = "Ay the Tear Collector";
            MouseClickOnObject.ObjectInvestigationLines[ObjectsInLevel.AyTheTearCollector] = "Investigate Ay";
            MouseClickOnObject.ObjectInteractionLines[ObjectsInLevel.AyTheTearCollector] = "Talk to Ay";
        }

        if (WorldEvents.EmmonKnowsBenny)
        {
            DialogueManager.AddToPassedDialogueLines(1020);
            MouseClickOnObject.ObjectLines[ObjectsInLevel.BennyTwospoons] = "Ex-clown Benny Twospoons";
            MouseClickOnObject.ObjectInvestigationLines[ObjectsInLevel.BennyTwospoons] = "Investigate Benny Twospoons";
            MouseClickOnObject.ObjectInteractionLines[ObjectsInLevel.BennyTwospoons] = "Talk to Benny Twospoons";
        }
    }

    public void GameStateToRunning()
    {
        GamePlayingMode = GameMode.Running;
    }

    public void GameStateToPaused()
    {
        GamePlayingMode = GameMode.Paused;
    }

    public void GameStateToIntro()
    {
        GamePlayingMode = GameMode.IntroMode;
    }

    public void GameStateToDead()
    {
        GamePlayingMode = GameMode.DeadMode;
    }

    public void GameStateToMissionAccomplished()
    {
        GamePlayingMode = GameMode.MissionAccomplished;
    }
}