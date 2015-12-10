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

    public static bool HasLoadedGame = false;

    public void Awake()
    {
        HasLoadedGame = false;

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
  //      Debug.LogWarning("Fading black to clear! " + ClearFader +  " " + HasLoadedGame);
        if (ClearFader == ToClear.StartFromLoad && !HasLoadedGame)
        {
            SaveAndLoadGame loadGame = new SaveAndLoadGame();
            loadGame.LoadGameData();
            HasLoadedGame = true;
        }

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
            {
                Application.LoadLevel("MainMenu");
            }
            else if (BlackFader == ToBlack.LoadFromMainMenu)
            {
                MainMenuManager.LoadLevel();
                GameManager.MyGameType = GameManager.GameType.LoadFromMenu;
            }
            else if (BlackFader == ToBlack.LoadFromInGame)
            {
                Debug.Log("load game from in-game");
                GameManager.MyGameType = GameManager.GameType.LoadFromInGame;

                GameManager.Instance.FadeBlackToClear();

                PauseMenu p = GameManager.Instance.UICanvas.PauseMenuCanvas.GetComponent<PauseMenu>();
                p.ResumeGame();
                
                GameManager.Instance.UICanvas.WidgetActive();   //Show UI components here

                CharacterControllerLogic.Instance.GoToIdleState();

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