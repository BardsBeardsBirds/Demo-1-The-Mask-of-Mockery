using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    /// <summary>
    public static bool NewGame = true;
    /// </summary>


    public enum GameMode { Paused, Running, IntroMode, DeadMode, MissionAccomplished };


    public AudioMixerGroup Mixer;

    public static GameManager Instance;
    public int RupeeHeld;
    public Portal DebugSpawn;
    public GameObject GameManagerObj;
    public GameObject InventoryWindow;
    public GameObject PauseMenuWindow;
    public GameObject SuperCanvas;
    public static GameObject Player;
    public Inventory IInventory;
    public InGameObjectManager InGameObjectM;

    private GameObject _ay;
    private GameObject _benny;
    private GameObject _sentinel;

    public static GameMode GamePlayingMode;

    public static AudioSource AudioSource1;
    public static AudioSource AudioSource2;

    private bool _showConsole = false;

    public static bool InCutScene = false;
    public static bool GameIsOver { get; set; }
    public static bool InIntroMode { get; set; }
    public bool WasLocked { get; set; }

    private float _fadeDelay = 2f;
    private float _fadeTimer;

    private bool _fade = false;
    private bool _isResetting;

    public static Dictionary<NPCEnum.NPCs, Transform> NPCs = new Dictionary<NPCEnum.NPCs, Transform>() { };

    public void Awake()
    {     
        Instance = this;
        NewGame = IsThisGameNew();
        Debug.Log("New game? " + NewGame);
        if (NewGame)
            GameStateToIntro();

        FadeBlackToClear();

        SetPlayerPosition();

        LoadManagers();
        FindCharacters();

        InCutScene = false;

        PauseMenuWindow = GameObject.Find("PauseMenuCanvas");
        InventoryWindow = GameObject.Find("InventoryCanvas");
        SuperCanvas = GameObject.Find("Canvas");
        InventoryCanvas invCan = InventoryWindow.GetComponent<InventoryCanvas>();
        RectTransform rect = invCan.GetComponent<RectTransform>();
        InventoryCanvas.SetLeftBottomPosition(rect, new Vector2(2000, 2000));
        IInventory = Inventory.Instance;

        if (NewGame)
            SetInitialBools();

        InGameObjectManager.Instance.LoadInGameObjectsInfo();  
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
        GameManagerObj.AddComponent<UIDrawer>();
        InGameObjectM = GameManagerObj.AddComponent<InGameObjectManager>();

    }

    private void FindCharacters()
    {
        if (SaveAndLoadGame.ComingFromMainMenu)
        {
            Debug.Log("find characters");
            _ay = GameObject.Find("Ay the Tear Collector");
            _ay.AddComponent<AyTheTearCollector>();
            NPCs.Add(NPCEnum.NPCs.AyTheTearCollector, _ay.transform);

            _benny = GameObject.Find("Benny Twospoons");
            _benny.AddComponent<BennyTwospoons>();
            NPCs.Add(NPCEnum.NPCs.BennyTwospoons, _benny.transform);

            _sentinel = GameObject.Find("Sentinel");
            _sentinel.AddComponent<Sentinel>();
            NPCs.Add(NPCEnum.NPCs.Sentinel, _sentinel.transform);
        }
    }

    public void SetPlayerPosition()
    {
        Player = GameObject.Find("Emmon");

        Player.transform.position = new Vector3(-58f, 6f, 158f);
        Player.transform.rotation = new Quaternion(0.0f, 0.4f, 0.0f, -0.9f);
    }

    public void ChangeMoney(int amount)
    {
        RupeeHeld += amount;
        MyConsole.WriteToConsole("We have now " + RupeeHeld + " rupees");
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

        //INVENTORY
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(InventoryCanvas.InventoryIsOpen)
            {
                InventoryCanvas i = InventoryWindow.GetComponent<InventoryCanvas>();
                i.CloseInventory();
            }
            else
            {
                InventoryCanvas i = InventoryWindow.GetComponent<InventoryCanvas>();
                i.OpenInventory();
            }
        }

        //PAUSE MENU
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                PauseMenu p = PauseMenuWindow.GetComponent<PauseMenu>();
                p.PauseGame();
            }
            else
            {
                PauseMenu p = PauseMenuWindow.GetComponent<PauseMenu>();

                p.UnpauseGame();
            }
        }

        if (Input.GetKeyUp(KeyCode.N))
        {
            //for (int i = 0; i < SlotScript.IInventory.Items.Count; i++)
            //{
            //    Debug.Log(SlotScript.IInventory.Items[i].IType);
            //}

            Debug.Log(WorldEvents.EmmonWasBlockedBySentinel);
            Debug.Log(WorldEvents.EmmonHasRoughneckShot);
            Debug.Log(WorldEvents.EmmonHasMaskOfMockery);
            Debug.Log(WorldEvents.EmmonKnowsAy);
            Debug.Log(WorldEvents.EmmonKnowsBenny);
            Debug.Log(WorldEvents.BennyHasOfferedLute);
            Debug.Log(WorldEvents.EmmonSawTheLute);            
            Debug.Log(WorldEvents.EmmonKnowsMaskLocation);
            Debug.Log(WorldEvents.EmmonHasPassedTheSentinel);
            Debug.Log(WorldEvents.MissionAccomplished);

        //    Inventory.Instance.AddItem(2);
        }

        if(GamePlayingMode == GameMode.DeadMode)
        {
            GameOver();
        }

        if(GamePlayingMode == GameMode.MissionAccomplished)
        {
            if(_fadeTimer > 0 && _fade)
            {
                _fadeTimer -= Time.deltaTime;
                if(_fadeTimer <= 0)
                {
                    ///show add
                }
            }
        }
    }

    public static void Destroy(string name)
    {
        var go = GameObject.Find(name);
        if(go != null )
            Destroy(go);
    }

    public void GameOver()
    {
        GameIsOver = true;
        _fadeTimer = _fadeDelay;
        _fade = true;
    }

    public void GameStart()
    {
        InIntroMode = false;
        GameIsOver = false;
        _fade = false;
        _isResetting = false;
    }

    public void DidLockCursor()
    {
        Cursor.visible = true;
    }

    public void DidUnlockCursor()
    {
        Cursor.visible = false;
    }

    //public Inventory CreateInventory()
    //{
    //    Inventory inventory = null;

    //    foreach (Transform child in InventoryWindow.transform)
    //    {
    //        //Debug.LogWarning("going over child: " + child.name);
    //        if (child.name == "InventoryPanel")
    //        {
    //            inventory = child.gameObject.AddComponent<Inventory>();

    //            Debug.LogWarning("created inventory");
    //            break;
    //        }
    //    }

    //    if (inventory == null)
    //        Debug.LogError("we couldnt find the inventory!");

    //    return inventory;
    //}

    public Inventory FindInventory()
    {
        Inventory inventory = null;

        foreach (Transform child in InventoryWindow.transform)
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
                //Debug.LogWarning(line); // prints each line of the file
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
                  //  return true;
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
        WorldEvents.EmmonWasBlockedBySentinel = false;
        WorldEvents.EmmonHasRoughneckShot = false;
        WorldEvents.EmmonHasMaskOfMockery = false;
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

        foreach (Transform trans in SuperCanvas.transform)
        {
            if (trans.gameObject.name == "ScreenFaderBlackToClear")
                sceneFaderGO = trans.gameObject;
        }

        if (sceneFaderGO == null)
            Debug.Log("could not find fader go!");

        sceneFaderGO.SetActive(true);

        SceneFader fader = sceneFaderGO.GetComponent<SceneFader>();
        if(NewGame)
            fader.ClearFader = SceneFader.ToClear.StartFromNew;
        else
        {
            fader.BlackImage.color = new Color(0, 0, 0, 1);
            fader.ClearFader = SceneFader.ToClear.StartFromLoad;
            Debug.Log("fader from load");
        }

        fader.IsFadingToClear = true;
    }

    public void GameStateToRunning()
    {
        Debug.Log("set to running");
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
