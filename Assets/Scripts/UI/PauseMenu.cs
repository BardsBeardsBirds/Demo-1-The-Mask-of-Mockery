using System;
using System.Collections.Generic;
using UnityEngine;

public enum PauseMenuStates {Main, Help, None};

public class PauseMenu : MonoBehaviour
{
    public PauseMenu Instance;
    public PauseMenuStates MenuState;

    public void Start()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        GameManager.Instance.UICanvas.ShowPauseMainMenu();

        if (InventoryCanvas.InventoryIsOpen)
            GameManager.Instance.UICanvas.HideInventory();

        MenuState = PauseMenuStates.Main;

        GameManager.Instance.GameStateToPaused();//////
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound
        //reset player locomotion
        CharacterControllerLogic.Instance.UnpauseGame();
        GameManager.Instance.GameStateToRunning();/////

        ClosePanel();

        MenuState = PauseMenuStates.None;

        Time.timeScale = 1;
    }

    public void ShowHelp()
    {
        GameManager.Instance.UICanvas.HidePauseMainMenu();
        GameManager.Instance.UICanvas.ShowHelpMenu();

        MenuState = PauseMenuStates.Help;
    }

    public void QuitAppliction()
    {
        AudioManager.Instance.UISoundsScript.PlayDrumRoll();   // sound
        StartCoroutine(TimeManager.WaitUntilEndOfClip(2f));
        MyConsole.WriteToConsole("We quit the game");
        Application.Quit();
    }

    public void SaveGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound

        SaveAndLoadGame saver = new SaveAndLoadGame();
        saver.SaveGameData();

        ResumeGame();
        MenuState = PauseMenuStates.None;
    }

    public void LoadGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound
        Debug.Log("Start loading game");
        GameManager.Instance.GameStateToPaused();
        Inventory inventory = Inventory.Instance;
        inventory.InitialiseInventoryItems.Clear();
        inventory.ResetAmounts();

        Time.timeScale = 1;

        GameObject sceneFaderGO = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScreenFaderClearToBlack")) as GameObject;
        sceneFaderGO.transform.SetParent(GameObject.Find("Canvas").transform);

        SaveAndLoadGame loader = new SaveAndLoadGame();
        loader.IsNotNewGame();

        SceneFader fader = sceneFaderGO.GetComponent<SceneFader>();
        fader.BlackFader = SceneFader.ToBlack.LoadFromInGame;
        fader.IsFadingToBlack = true;

        ClosePanel();
        MenuState = PauseMenuStates.None;
    }

    public void ReturnToMenu()
    {
        GameManager.Instance.UICanvas.HideHelpMenu();
        GameManager.Instance.UICanvas.ShowPauseMainMenu();

        MenuState = PauseMenuStates.Main;
    }

    private void ClosePanel()
    {
        if (MenuState == PauseMenuStates.Main)
        {
            GameManager.Instance.UICanvas.HidePauseMainMenu();

            if (InventoryCanvas.InventoryIsOpen)
                GameManager.Instance.UICanvas.ShowInventory();
        }
        else if (MenuState == PauseMenuStates.Help)
        {
            GameManager.Instance.UICanvas.HideHelpMenu();
        }
    }
}