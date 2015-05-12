using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Item
{
    public enum ItemClass { Weapon, UniqueItem, Ammunition, Consumable };
    public enum ItemType { Empty, RoughneckShot, Carrot, MaskOfMockery };

    public string ItemName;
    public string ItemDescription;
    public int ItemID;
    public Sprite ItemIcon;
    public GameObject ItemModel;
    public int ItemAmount;
    public ItemClass IClass;
    public ItemType IType;

    public Item(string name, int id, string description, int amount, ItemClass iClass, ItemType iType)
    {
        ItemName = name;
        ItemID = id;
        ItemDescription = description;
        ItemAmount = amount;
        IClass = iClass;
        IType = iType;
        ItemIcon = Resources.Load<Sprite>("Icons/Items/" + name);
    }

    public Item()   // empty slots
    {

    }
}