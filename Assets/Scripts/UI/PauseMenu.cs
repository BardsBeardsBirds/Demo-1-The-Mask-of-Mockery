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
        Transform panel = Instance.transform.FindChild("Panel");
        panel.gameObject.SetActive(true);
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
        Transform panel = Instance.transform.FindChild("Panel");
        panel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void QuitAppliction()
    {
        AudioManager.Instance.UISoundsScript.PlayDrumRoll();   // sound
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
}
