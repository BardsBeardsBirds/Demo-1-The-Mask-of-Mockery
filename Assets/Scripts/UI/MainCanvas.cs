using UnityEngine;
public class MainCanvas : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject DialogueOptions;
    public GameObject InventoryCanvas;
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuMainWindow;
    public GameObject PauseMenuHelpWindow;

    public void Awake()
    {
        MainPanel = this.gameObject;

        InventoryCanvas = GameObject.Find("InventoryCanvas");

        PauseMenuCanvas = GameObject.Find("PauseMenuCanvas");
        PauseMenuMainWindow = PauseMenuCanvas.transform.FindChild("MainPanel").gameObject;
        PauseMenuHelpWindow = PauseMenuCanvas.transform.FindChild("HelpPanel").gameObject;

        if (DialogueOptions == null)
        {
            Debug.Log("couldn't find DialogueOptionsUI");
            DialogueOptions = GameObject.Find("DialogueOptionsUI");
        }
    }

    public void ShowInventory()
    {
        InventoryCanvas.SetActive(true);
    }

    public void HideInventory()
    {
        InventoryCanvas.SetActive(false);
    }
    
    public void ShowPauseMainMenu()
    {
        PauseMenuMainWindow.SetActive(true);
    }

    public void HidePauseMainMenu()
    {
        PauseMenuMainWindow.SetActive(false);
    }

    public void ShowHelpMenu()
    {
        PauseMenuHelpWindow.SetActive(true);
    }

    public void HideHelpMenu()
    {
        PauseMenuHelpWindow.SetActive(false);
    }

    public void ShowDialogueOptionsUI()
    {
        Transform dialogueOptions = DialogueOptions.transform.FindChild("DialogueOptions");
        dialogueOptions.gameObject.SetActive(true);
    }

    public void HideDialogueOptionsUI()
    {
        Transform dialogueOptions = DialogueOptions.transform.FindChild("DialogueOptions");
        dialogueOptions.gameObject.SetActive(false);
    }
}