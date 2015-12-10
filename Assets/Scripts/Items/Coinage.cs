using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Coinage
{
    private string _name;
    private int _value;
    private GameObject _spawnpoint;
    private string[] randomCoins1 = { "Coin", "Coin", "Coin", "TenCoins", "HundredCoins" };

    public Coinage(string name, GameObject spawnpoint)
    {
        _spawnpoint = spawnpoint;
        _name = name;
        if (name == "Random1")
        {
            _name = randomCoins1[UnityEngine.Random.Range(0, randomCoins1.Length)];
        }

        if (_name == "Coin")
            _value = 1;
        else if (_name == "TenCoins")
            _value = 10;
        else if (_name == "HundredCoins")
            _value = 100;
        else
            Debug.LogWarning("This coin does not have a valid name!");
    }

    public string Name
    {
        get
        {   
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public void Instantiate()
    {
        GameObject coin;

        if (_value == 1)
            coin = GameObject.Instantiate(Resources.Load("Prefabs/Items/Coinage/Coin")) as GameObject;
        else if (_value == 10)
            coin = GameObject.Instantiate(Resources.Load("Prefabs/Items/Coinage/TenCoins")) as GameObject;
        else if (_value == 100)
            coin = GameObject.Instantiate(Resources.Load("Prefabs/Items/Coinage/HundredCoins")) as GameObject;
        else
            coin = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        coin.name = _name;
        coin.AddComponent<Rigidbody>();
        coin.GetComponent<Rigidbody>().isKinematic = true;

        coin.transform.position = _spawnpoint.transform.position;
        coin.transform.parent = _spawnpoint.transform;
    }
}

