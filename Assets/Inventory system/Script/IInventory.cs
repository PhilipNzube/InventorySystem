public interface IInventory
{
    void AddItem(Item item);
    void RemoveItem(Item item);
    void EquipItem(Item item);
    void UnequipItem(Item item);
}