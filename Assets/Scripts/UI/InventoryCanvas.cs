using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    public static InventoryCanvas Instance;
    public static bool InventoryIsOpen;

    public void Start()
    {
        Instance = this;
        InventoryIsOpen = false;
    }

    public void OpenInventory()
    {
        GameManager.Instance.UICanvas.ShowInventory();
        InventoryIsOpen = true;
    }

    public void CloseInventory()
    {
        Debug.Log("close inventory");

        GameManager.Instance.UICanvas.HideInventory();

        InventoryIsOpen = false;

        GameManager.Destroy("InteractionButton");
        GameManager.Destroy("InvestigateButton");
    }

    public static void SetLeftBottomPosition(RectTransform trans, Vector2 newPos)
    {
        trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
    }
}

