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
        GameManager.Instance.UICanvas.ObjectDescriptionText.enabled = true;
        ActionPanel.ShowHoverInteractionLine();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseClickOnObject.MouseIsOnInteractionButton = false;
        GameManager.Instance.UICanvas.HideObjectDescriptionText();
    }
}
