using UnityEngine;
using UnityEngine.UI;
public class MainCanvas : MonoBehaviour
{
    public enum Hoverings { MouseInWorld, MouseInInventory };

    public GameObject MainPanel;
    public GameObject DialogueOptions;
    public GameObject InventoryCanvasGO;
    public GameObject PauseMenuCanvas;
    public GameObject PauseMenuMainWindow;
    public GameObject PauseMenuHelpWindow;
    public GameObject ScreenButtonWidget;
    public GameObject IntroScreen;

    public GameObject DialogueLineImage;
    public GameObject ObjectDescriptionTextGO;
    public Text ObjectDescriptionText;
    public Hoverings Hovering;

    public Image InventoryPanelImage;
    public GameObject InventoryPanelSlots;
    public UIDrawer MyUIDrawer;
    public MoneyDisplay MoneyOnScreen;  //the script that arranges displaying the money on screen.

    private bool _widgetIsActive = false;

    public void Awake()
    {
        MainPanel = this.gameObject;

        Hovering = Hoverings.MouseInWorld;

        MyUIDrawer = MainPanel.AddComponent<UIDrawer>();

        ObjectDescriptionTextGO = GameObject.Find("ObjectDescriptionText");
        ObjectDescriptionText = ObjectDescriptionTextGO.GetComponent<Text>();

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

        if(GameManager.MyGameType != GameManager.GameType.NewGame)
            GameManager.Instance.UICanvas.WidgetActive();
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
        Inventory.Instance.MyAnimator.SetBool("Open", true);

    //    InventoryPanelImage.enabled = true;
    //    InventoryPanelSlots.SetActive(true);
    }

    public void HideInventory()
    {
        //InventoryPanelImage.enabled = false;
        //InventoryPanelSlots.SetActive(false);
        Inventory.Instance.MyAnimator.SetBool("Open", false);

        if(GameManager.Instance.UICanvas.Hovering == Hoverings.MouseInInventory)
        {
            HideObjectDescriptionText();
            GameManager.Instance.UICanvas.Hovering = Hoverings.MouseInWorld;
        }
    }
    
    public void ShowPauseMainMenu()
    {
        PauseMenuMainWindow.GetComponent<PauseMainPanel>().MainPanelOpen = true;
    }

    public void HidePauseMainMenu()
    {
        PauseMenuMainWindow.GetComponent<PauseMainPanel>().MainPanelOpen = false;
    }

    public void ShowHelpMenu()
    {
        PauseMenuHelpWindow.GetComponent<PauseHelpPanel>().HelpPanelOpen = true;
    }

    public void HideHelpMenu()
    {
        PauseMenuHelpWindow.GetComponent<PauseHelpPanel>().HelpPanelOpen = false;
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
        _widgetIsActive = ScreenButtonWidget.GetComponent<Widget>().WidgetActive;
        ScreenButtonWidget.SetActive(false);
    }

    public void ShowScreenButtonWidget()
    {
        ScreenButtonWidget.SetActive(true);
        if (_widgetIsActive)
            WidgetActive();
        else
            WidgetNotActive();
    }

    public void HideObjectDescriptionText()
    {
        ObjectDescriptionText.text = "";
        ObjectDescriptionTextGO.GetComponentInChildren<DescriptionUnderlining>().ShowNewDescription = false;
        ObjectDescriptionText.enabled = false;
    }

    public void NewObjectDescription()
    {
        ObjectDescriptionTextGO.GetComponentInChildren<DescriptionUnderlining>().ShowNewDescription = true;
    }

    public void WidgetActive()
    {
        ScreenButtonWidget.GetComponent<Widget>().WidgetActive = true;
    }

    public void WidgetNotActive()
    {
        //Debug.Log("to not active");
        ScreenButtonWidget.GetComponent<Widget>().WidgetActive = false;
    }
}