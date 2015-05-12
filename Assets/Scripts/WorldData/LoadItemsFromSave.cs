using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

    public class LoadItemsFromSave : MonoBehaviour
    {
        public void LoadAllItemsFromSave()
        {
            Inventory inventory = GameManager.Instance.FindInventory();

            foreach (int itemNumber in inventory.InitialiseInventoryItems)
            {
                Debug.Log("Add " + itemNumber);

                inventory.AddItem(itemNumber);
            }
        }
    }

