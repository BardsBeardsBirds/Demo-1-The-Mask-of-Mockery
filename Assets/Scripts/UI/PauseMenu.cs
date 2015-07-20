using System;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PauseMenu Instance;

    public void Start()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        Transform mainPanel = Instance.transform.FindChild("MainPanel");
        mainPanel.gameObject.SetActive(true);
        GameManager.Instance.GameStateToPaused();//////
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        AudioManager.Instance.UISoundsScript.PlayClick();   // sound
        ResumeGame();
        GameManager.Instance.GameStateToRunning();/////
    }

    public void ResumeGame()
    {
        Transform mainPanel = Instance.transform.FindChild("MainPanel");
        mainPanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowHelp()
    {
        Transform mainPanel = Instance.transform.FindChild("MainPanel");
        mainPanel.gameObject.SetActive(false);
        Transform helpPanel = Instance.transform.FindChild("HelpPanel");
        helpPanel.gameObject.SetActive(true);
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
    }

    public void ReturnToMenu()
    {
        Transform helpPanel = Instance.transform.FindChild("HelpPanel");
        helpPanel.gameObject.SetActive(false);
        Transform mainPanel = Instance.transform.FindChild("MainPanel");
        mainPanel.gameObject.SetActive(true);

    }
}
