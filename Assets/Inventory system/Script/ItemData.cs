using System.Collections;
using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;


[CreateAssetsMenu]
public class ItemData : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
    public GameObject modelPrefab;
    public GameObject collectablePrefab;
    public Vector3 attachmentPosition;
    public bool isEquipped;
    public int startingAmmo;
    public starting startingCondition;

}