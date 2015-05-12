using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemDatabase : MonoBehaviour
{
    public List<Item> Items = new List<Item>();

    void Start()
    {
        Items.Add(new Item("Roughneck Shot", 1, "Drink this to pass the gaurd", 1, Item.ItemClass.UniqueItem, Item.ItemType.RoughneckShot));

        Items.Add(new Item("Carrot", 2, "Carrot", 1, Item.ItemClass.Consumable, Item.ItemType.Carrot));

        Items.Add(new Item("Mask of Mockery", 3, "The Mask of Mockery", 1, Item.ItemClass.UniqueItem, Item.ItemType.MaskOfMockery));
    }
}

