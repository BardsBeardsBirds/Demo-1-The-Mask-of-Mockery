using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InvestigateObjectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InvestigateObjectButton Instance;

    public void Start()
    {
        Instance = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseClickOnObject.MouseIsOnInvestigateButton = true;
        GameManager.Instance.UICanvas.ObjectDescriptionText.enabled = true;
        if (ActionPanel.IsInInventory)
            ActionPanel.ShowHoverInvestigationLine(DialogueType.InventoryInvestigation);
        else
            ActionPanel.ShowHoverInvestigationLine(DialogueType.ObjectInvestigation);
        //ActionPanel.ShowHoverInvestigationLine();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
            MouseClickOnObject.MouseIsOnInvestigateButton = false;
            GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }
}
