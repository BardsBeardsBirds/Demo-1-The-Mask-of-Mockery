using UnityEngine;
using UnityEngine.UI;
public class MainCanvas : MonoBehaviour
{
    public GameObject MainPanel;
    public GameObject DialogueOptions;
    public GameObject InventoryCanvasGO;
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuMainWindow;
    public GameObject PauseMenuHelpWindow;
    public GameObject ScreenButtonWidget;

    public Image InventoryPanelImage;
    public GameObject InventoryPanelSlots;
    public UIDrawer MyUIDrawer;
    public MoneyDisplay MoneyOnScreen;  //the script that arranges displaying the money on screen.


    public void Awake()
    {
        MainPanel = this.gameObject;

        MyUIDrawer = MainPanel.AddComponent<UIDrawer>();



        PauseMenuCanvas = GameObject.Find("PauseMenuCanvas");
        PauseMenuMainWindow = PauseMenuCanvas.transform.FindChild("MainPanel").gameObject;
        PauseMenuHelpWindow = PauseMenuCanvas.transform.FindChild("HelpPanel").gameObject;

        if (DialogueOptions == null)
        {
            Debug.LogError("couldn't find DialogueOptionsUI");
            DialogueOptions = GameObject.Find("DialogueOptionsUI");
        }

        if (InventoryCanvasGO == null)
        {
            Debug.LogError("couldn't find InventoryCanvas");
            InventoryCanvasGO = GameObject.Find("InventoryCanvas");
        }
        else
            GameManager.Instance.MyInventory = InventoryCanvasGO.GetComponentInChildren<Inventory>();

        if (InventoryPanelImage == null)
        {
            Debug.LogError("couldn't find InventoryPanelImage");
        }

        if (InventoryPanelSlots == null)
        {
            Debug.LogError("couldn't find InventoryPanelSlots");
        }

        if (ScreenButtonWidget == null)
        {
            Debug.LogError("couldn't find ScreenButtonWidget");
        }
  //      HideInventory();
    //    ShowSlotsImages();
    }

    public void OpenCloseInventory()
    {
        if (InventoryCanvas.InventoryIsOpen)
        {
            InventoryCanvasGO.GetComponent<InventoryCanvas>().CloseInventory();
        }
        else
        {
            InventoryCanvasGO.GetComponent<InventoryCanvas>().OpenInventory();
        }
    }

    public void ShowInventory()
    {
        InventoryPanelImage.enabled = true;
        InventoryPanelSlots.SetActive(true);
    }

    public void HideInventory()
    {
        InventoryPanelImage.enabled = false;
        InventoryPanelSlots.SetActive(false);
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

    public void HideScreenButtonWidget()
    {
        ScreenButtonWidget.SetActive(false);
    }

    public void ShowScreenButtonWidget()
    {
        ScreenButtonWidget.SetActive(true);
    }

    //#region Helpers

    //public void HideSlotsGO()
    //{

    //}

    //public void ShowSlotsImages()
    //{
    //    foreach(Transform trans in InventoryPanelSlots.transform)
    //    {
    //        trans.GetComponent<Image>().enabled = true;
    //    }
    //}

    //#endregion Helpers
}