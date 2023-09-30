using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "itemData", menuName = "InventoryItemData")]
public class Inventory : ScriptableObject 
{
    public List<ItemData> items = new();
}