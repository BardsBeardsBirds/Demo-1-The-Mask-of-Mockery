using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuManager : MonoBehaviour
{
    public MainMenu CurrentMenu;

    private bool _hasNoLoadGame = true;

     public void Start()
    {
        ShowMenu(CurrentMenu);

        if (!File.Exists(Application.persistentDataPath + "/demo1Progress.dat"))
            GreyOutLoadGameButton();
        else
            ActivateLoadGameButton();
    }

     public void ShowMenu(MainMenu menu)
     {
         if (CurrentMenu != null)
             CurrentMenu.IsOpen = false;

         CurrentMenu = menu;
         CurrentMenu.IsOpen = true;
     }

    public void StartNewGame()
    {
        SaveAndLoadGame loader = new SaveAndLoadGame();

        loader.ThisIsANewGame();
        Debug.Log("starting a new game");

        GameObject sceneFaderGO = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScreenFaderClearToBlack")) as GameObject;
        sceneFaderGO.transform.SetParent(GameObject.Find("Canvas").transform);

        SceneFader fader = sceneFaderGO.GetComponent<SceneFader>();
        fader.BlackFader = SceneFader.ToBlack.NewGameFromMainMenu;
        fader.IsFadingToBlack = true;
        MainMenuSound.FadeOut = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public static void LoadLevel()
    {       
        Application.LoadLevel("Demo1");
    }

    public void LoadGame()
    {
        SaveAndLoadGame loader = new SaveAndLoadGame();
        loader.IsNotNewGame();

        GameObject sceneFaderGO = GameObject.Instantiate(Resources.Load("Prefabs/UI/ScreenFaderClearToBlack")) as GameObject;
        sceneFaderGO.transform.SetParent(GameObject.Find("Canvas").transform);

        SceneFader fader = sceneFaderGO.GetComponent<SceneFader>();
        fader.BlackFader = SceneFader.ToBlack.LoadFromMainMenu;
        fader.IsFadingToBlack = true;
        MainMenuSound.FadeOut = true;
    }

    private void GreyOutLoadGameButton()
    {
        GameObject button = GameObject.Find("LoadGameButton");
        button.SetActive(false);
        GameObject greyButton = GameObject.Find("LoadGameButtonGrey");
        greyButton.SetActive(true);
    }

    private void ActivateLoadGameButton()
    {
        GameObject button = GameObject.Find("LoadGameButton");
        button.SetActive(true);
        GameObject greyButton = GameObject.Find("LoadGameButtonGrey");
        greyButton.SetActive(false);
    }
}
