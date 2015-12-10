using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameObjectManager : MonoBehaviour
{
    public static InGameObjectManager Instance;
    public List<GameObject> Objects = new List<GameObject>();
    public List<GameObject> TreasureChests = new List<GameObject>();

    public static bool PickedUpCarrot = false;
    public static bool PickedUpMaskOfMockery = false;

    void Awake()
    {
        Instance = this;
        Objects.Add(GameObject.Find("Carrot"));
        Objects.Add(GameObject.Find("MaskOfMockery"));

        foreach (GameObject chest in GameObject.FindGameObjectsWithTag("TreasureChest"))
        {
            TreasureChests.Add((chest) as GameObject);
        }     
    }

    public void TurnOffObject(GameObject obj)
    {
        for (int i = 0; i < Objects.Count; i++)
        {
            if(obj == Objects[i])
            {
                obj.SetActive(false);
            }
        }
    }

    public void LoadInGameObjectsInfo()
    {
        if (PickedUpCarrot)
            TurnOffObject(findInObjects("Carrot"));
        if (PickedUpMaskOfMockery)
            TurnOffObject(findInObjects("MaskOfMockery"));
    }

    private GameObject findInObjects(string name)
    {
        GameObject gameObject = null;

        foreach (GameObject go in Objects)
        {
            if (go.name == name)
                gameObject = go;
        }
        if (gameObject == null)
            Debug.LogWarning(("game object is null ") + name);
        return gameObject;
    }
}
