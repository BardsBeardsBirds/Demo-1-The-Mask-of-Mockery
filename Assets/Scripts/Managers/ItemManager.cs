using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public static List<GameObject> RegularItemSpawnpoints = new List<GameObject>();
    public static List<GameObject> UniqueItemSpawnpoints = new List<GameObject>();
    public static List<GameObject> CoinageSpawnpoints = new List<GameObject>();

    private List<Coinage> coins = new List<Coinage>();
    private static ItemDatabase _itemDatabase;

    private void Start()
    {
        Transform coinageSpawnpoint = GameObject.Find("CoinageSpawnpoints").transform;

        foreach (Transform child in coinageSpawnpoint)
        {
            CoinageSpawnpoints.Add(child.gameObject);
        };

        foreach (Coinage coin in coins)
        {
            coin.Instantiate();
        }

        _itemDatabase = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
    }

    private void CreateCoinage()
    {
        foreach (GameObject spawnpoint in CoinageSpawnpoints)
        {
            Coinage coin = new Coinage(spawnpoint.name, spawnpoint);
            coins.Add(coin);
        }
    }

    public static void AddItem(ItemType itemType)
    {
        Item item = null;

        for (int i = 0; i < _itemDatabase.Items.Count; i++)
        {
            if (_itemDatabase.Items[i].IType == itemType)
            {
                item = _itemDatabase.Items[i];
            }
        }
        if (item != null)
            GameManager.Instance.MyInventory.AddItem(item.ID);
        else
            Debug.LogError("we don't know this item type so we cannot add it: " + itemType);
    }
}