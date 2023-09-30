using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private IInventory inventory;



    void Start()
    {
        inventory = GetComponent<IInventory>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ItemContainer foundItem))
        {
            inventory.AddItem(foundItem.TakeItem());
        }
    }
}