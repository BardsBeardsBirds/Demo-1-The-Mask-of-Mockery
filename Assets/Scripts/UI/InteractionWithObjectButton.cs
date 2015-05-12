using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InteractionWithObjectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public InteractionWithObjectButton Instance;

    public void Start()
    {
        Instance = this;  
    }

    public void OnPointerEnter(PointerEventData eventData)
    {       
        MouseClickOnObject.MouseIsOnInteractionButton = true;
        MouseClickOnObject.DescriptionText.enabled = true;
        ActionPanel.ShowHoverInteractionLine();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseClickOnObject.MouseIsOnInteractionButton = false;
        MouseClickOnObject.HideObjectDescriptionText();
    }
}
