using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    public InventoryCanvas Instance;
    public static bool InventoryIsOpen;

    public void Start()
    {
        Instance = this;
    }

    public void OpenInventory()
    {
        RectTransform rect = this.GetComponent<RectTransform>();
        SetLeftBottomPosition(rect, new Vector2(-Screen.width / 2, -Screen.height / 2));

        GameManager.Instance.UICanvas.ShowInventory();

        InventoryIsOpen = true;
    }

    public void CloseInventory()
    {
        GameManager.Instance.UICanvas.HideInventory();

        InventoryIsOpen = false;

        GameManager.Destroy("InteractionButton");
        GameManager.Destroy("InvestigateButton");
        SlotScript.IInventory.HideTooltip();
    }

    public static void SetLeftBottomPosition(RectTransform trans, Vector2 newPos)
    {
        trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
    }
}

