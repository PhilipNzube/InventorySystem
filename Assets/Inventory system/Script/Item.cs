using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public AssetReference modelPrefab;
    public AssetReference collectablePrefab;
    public Sprite icon;
    public Vector3 attachmentPosition;
    public Vector3 attachmentRotation;

}