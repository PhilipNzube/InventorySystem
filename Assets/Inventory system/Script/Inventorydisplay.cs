public class InventoryDisplay : Monobehaviour
{
    public DynamicInventory inventory;
    public itemdisplay[] slots;
    private void Start()
    {
        UpdateInventory();

    }
    void UpdateInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].gameObject.setActive(true);
                slots[i].UpdateItemDisplay(inventory.items[i].itemType.icon, i);
            }
            else
            {
                slots[i].gameObject.SetActive(false);
            }
        }
    }
}