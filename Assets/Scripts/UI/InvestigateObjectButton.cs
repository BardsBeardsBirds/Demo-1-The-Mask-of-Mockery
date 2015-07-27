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
        MouseClickOnObject.DescriptionText.enabled = true;
        ActionPanel.ShowHoverInvestigationLine();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
            MouseClickOnObject.MouseIsOnInvestigateButton = false;
            MouseClickOnObject.HideObjectDescriptionText();
    }
}
