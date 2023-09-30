using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;
using UnityEngine.UI;

public interface IInventory
{
    void AddItem(Item item);
    void RemoveItem(Item item);
    void EquipItem(Item item);
    void UnequipItem(Item item);
}

public class InventoryManager : MonoBehaviour, IInventory
{
    private List<ItemInstance> items = new();
    public GameObject inventoryUI;
    public Transform itemAttachmentPoint;
    public Text itemNameText;
    public Image itemIconImage;
    public void AddItem(ItemInstance item)
    {
        items.Add(item);
        LoadAddressableAssets(item);
        UpdateUI(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

    }

    public void EquipItem(Item item)
    {
        item.isEquipped = true;
        UpdateUI(item);
    }

    public void UnequipItem(Item item)
    {
        item.isEquipped = false;
        if (item.modelPrefab != null && itemAttachmentPoint != null)
        {
            Destroy(itemAttachmentPoint.GetChild(0).gameObject);
        }

        UpdateUI(item);
    }

    private void LoadAddressableAssets(Item item)
    {

        AsyncOperationHandle<GameObject> modelPrefabHandle = Addressables.LoadAssetAsync<GameObject>(item.modelPrefab);
        AsyncOperationHandle<GameObject> collectablePrefabHandle = Addressables.LoadAssetAsync<GameObject>(item.collectablePrefab);
        AsyncOperationHandle<Sprite> iconHandle = Addressables.LoadAssetAsync<Sprite>(item.icon);


        modelPrefabHandle.Completed += handle =>
        {
            if (item.modelPrefab != null && itemAttachmentPoint != null)
            {
                GameObject instantiatedModel = Instantiate(handle.Result);
                instantiatedModel.transform.SetParent(itemAttachmentPoint);
                instantiatedModel.transform.localPosition = item.attachmentPosition;
            }
        };

        collectablePrefabHandle.Completed += handle =>
        {
            if (item.collectablePrefab != null && itemAttachmentPoint != null)
            {
                GameObject instantiatedCollectabe = Instantiate(handle.Result);
                instantiatedCollectabe.transform.SetParent(itemAttachmentPoint);
                instantiatedCollectabe.transform.localPosition = item.attachmentPosition;
            }
        };

        iconHandle.Completed += handle =>
        {
            if (item.icon != null && itemAttachmentPoint != null)
            {
                Sprite instantiatedIcon = Instantiate(handle.Result);
                instantiatedIcon.transform.SetParent(itemAttachmentPoint);
                instantiatedIcon.transform.localPosition = item.attachmentPosition;
            }
        };
    }

    void UpdateUI(Item item)
    {
        if (itemNameText != null)
        {
            itemNameText.text = item.itemName;
        }
        if (itemIconImage != null)
        {
            itemIconImage.sprite = item.icon;
        }
    }
}
