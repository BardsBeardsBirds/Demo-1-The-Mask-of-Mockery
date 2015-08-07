using UnityEngine;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    public static List<GameObject> RegularItemSpawnpoints = new List<GameObject>();
    public static List<GameObject> UniqueItemSpawnpoints = new List<GameObject>();
    public static List<GameObject> CoinageSpawnpoints = new List<GameObject>();

    private List<Coinage> coins = new List<Coinage>();

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
    }

    private void CreateCoinage()
    {
        foreach (GameObject spawnpoint in CoinageSpawnpoints)
        {
            Coinage coin = new Coinage(spawnpoint.name, spawnpoint);
            coins.Add(coin);
        }
    }

    public static void AddItem(int item)
    {
        GameManager.Instance.MyInventory.AddItem(item);
    }
}