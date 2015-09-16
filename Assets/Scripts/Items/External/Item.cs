using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

public enum ItemClass { None, Weapon, UniqueItem, Ammunition, Consumable };
public enum ItemType { Empty, RoughneckShot, Carrot, MaskOfMockery };

public class Item
{


    [XmlAttribute("ID")]
    public int ID;
    [XmlElement("Type")]
    public ItemType IType;
    [XmlElement("Name")]
    public string ItemName;
    [XmlElement("Class")]
    public ItemClass Class;
  //  [XmlElement("Sprite")]
    public Sprite ItemIcon;
  //  [XmlElement("GameObject")]
 //   public GameObject ItemModel;
    [XmlElement("Amount")]
    public int ItemAmount;

    public Sprite FindIcon(Item item)
    {
        Sprite icon = Resources.Load<Sprite>("Icons/Items/" + item.ItemName);
        return icon;
    }

    //public Item(string name, int id, string description, int amount, ItemClass iClass, ItemType iType)
    //{
    //    ItemName = name;
    //    ID = id;
    //    ItemDescription = description;
    //    ItemAmount = amount;
    //    Class = iClass;
    //    IType = iType;
    //    ItemIcon = Resources.Load<Sprite>("Icons/Items/" + name);
    //}

    //public Item()   // empty slots
    //{

    //}
}