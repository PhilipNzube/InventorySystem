[System.Serializable]
public class ItemInstance
{
    public ItemData itemType;
    public int condition;
    public int ammo;
    public ItemInstance(ItemData itemData)
    {
        itemType = itemData;
        condition = itemData.startingCondition;
        ammo = itemData = itemData.startingAmmo;
    }
}