using UnityEngine;
public class ItemContainer : MonoBehaviour
{
    public Item item;
    public Item TakeItem()
    {
        Destroy(gameObject);
        return item;
    }
}