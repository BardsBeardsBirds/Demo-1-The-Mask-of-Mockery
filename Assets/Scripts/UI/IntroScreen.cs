using UnityEngine;

public class IntroScreen : MonoBehaviour
{
    private Animator _animator;

    public bool PanelOpen
    {
        get { return _animator.GetBool("IsOpen"); }
        set { _animator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void ToTutorial()
    {
        if (InventoryCanvas.InventoryIsOpen)
            GameManager.Instance.UICanvas.HideInventory();

        GameManager.Instance.UICanvas.HideScreenButtonWidget();
        GameManager.Instance.GameStateToPaused();
        GameManager.Instance.UICanvas.ShowHelpMenu();

        GameManager.Instance.UICanvas.PauseMenuCanvas.GetComponent<PauseMenu>().MenuState = PauseMenuStates.Help;

        Destroy(GameManager.Instance.UICanvas.IntroScreen);
    }

    public void Exit()
    {
        Destroy(GameManager.Instance.UICanvas.IntroScreen);
    }
}

