using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public enum ToBlack { FinishGame, NewGameFromMainMenu, LoadFromMainMenu, LoadFromInGame};
    public enum ToClear { StartFromNew, StartFromLoad };
    public ToBlack BlackFader;
    public ToClear ClearFader;
    private float _fadeToBlackSpeed = 1.2f;          // Speed that the screen fades to and from black.
    private float _fadeToClearSpeed = 0.8f;          // Speed that the screen fades to and from black.
    public Image BlackImage;

    public bool IsFadingToBlack = false;
    public bool IsFadingToClear = false;


    public void Awake()
    {
        BlackImage = this.gameObject.GetComponent<Image>();
    }

    public void Update()
    {
        if (IsFadingToBlack)
            ClearToBlack();
        if (IsFadingToClear)
            BlackToClear();

    }

    public void BlackToClear()
    {
        BlackImage.color = Color.Lerp(BlackImage.color, new Color(0, 0, 0, 0), _fadeToClearSpeed * Time.deltaTime);
        if (BlackImage.color.a <= 0.65f)
        {
            _fadeToClearSpeed = 1.4f;
        }
        else
            _fadeToClearSpeed = 0.25f;

        if (BlackImage.color.a <= 0.05f)
        {

            if (ClearFader == ToClear.StartFromNew)
            {
                IntroMode introManager = new IntroMode();
                ///////////////This one has to be removed!
          //      GameManager.GamePlayingMode = GameManager.GameMode.Running;/// to avoid intro
                ////////////////////////////
                introManager.StartIntro();
                /////////////////

            }
            else if(ClearFader == ToClear.StartFromLoad)
            {

              //  GameManager.GamePlayingMode = GameManager.GameMode.Running;
                SaveAndLoadGame loadGame = new SaveAndLoadGame();
                loadGame.LoadGameData();
            }

            IsFadingToClear = false;
            this.gameObject.SetActive(false);
        }
    }

    public void ClearToBlack()
    {
        BlackImage.color = Color.Lerp(BlackImage.color, new Color(0, 0, 0, 1), _fadeToBlackSpeed * Time.deltaTime);

        if (BlackImage.color.a >= 0.98f)
        {
            if (BlackFader == ToBlack.FinishGame)
                Application.Quit();
            else if (BlackFader == ToBlack.LoadFromMainMenu)
                MainMenuManager.LoadLevel();
            else if (BlackFader == ToBlack.LoadFromInGame)
            {
                Debug.Log("load game from in-game");
                SaveAndLoadGame loader = new SaveAndLoadGame();
                SaveAndLoadGame.ComingFromMainMenu = false;
                loader.IsNotNewGame();

                GameManager.NewGame = false;

            //    loader.LoadGameData();
                GameManager.Instance.FadeBlackToClear();

                PauseMenu p = GameManager.Instance.PauseMenuWindow.GetComponent<PauseMenu>();
                p.ResumeGame();

             //   GameManager.GamePlayingMode = GameManager.GameMode.Running;
                CharacterControllerLogic.Instance.GoToIdleState();///

                Destroy(this.gameObject);

            }
            else if (BlackFader == ToBlack.NewGameFromMainMenu)
            {
                MainMenuManager.LoadLevel();

            }
            IsFadingToBlack = false;
        }
    }
}