using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;


public class InventoryManager : MonoBehaviour, IInventory
{
    public List<Item> items = new List<Item>();
    public Transform itemAttachmentPoint;
    public Transform collectableItemAttachmentPoint;
    private IInventoryUI inventoryUI;
    public TextMeshProUGUI itemNameText;
    public Image itemIconImage;
    public GameObject itemUIPrefab;
    public Transform inventoryParent;
    AsyncOperationHandle<GameObject> modelPrefabHandle;
    AsyncOperationHandle<GameObject> collectablePrefabHandle;
    ItemContainer itemContainer;
    public bool isEquipped;


    void Start()
    {
        inventoryUI = GetComponent<IInventoryUI>();
        UpdateUI();
    }


    public void UpdateUI()
    {
        float spacing = 10f;
        // float firstItemXPos = 0f;
        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            if (itemNameText != null)
            {
                itemNameText.text = item.itemName;
            }
            GameObject itemUI = Instantiate(itemUIPrefab, inventoryParent);
            // float xPos = i == 0 ? firstItemXPos : firstItemXPos + (i - 1) * (itemUI.GetComponent<RectTransform>().rect.width + spacing);
            float xPos = i  * (itemUI.GetComponent<RectTransform>().rect.width + spacing);
            itemUI.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, itemUI.GetComponent<RectTransform>().rect.height);
            Image itemImage = itemUI.GetComponent<Image>();
            itemImage.sprite = item.icon;
            Button itemButton = itemUI.GetComponent<Button>();
            itemButton.onClick.AddListener(() => EquipItem(item));
        }

    }

    public void AddItem(Item item)
    {
        items.Add(item);
        UpdateUI();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void EquipItem(Item item)
    {
        if (isEquipped == false)
        {
            isEquipped = true;
            LoadAddressableAssets(item);
            modelPrefabHandle.Completed += async handle =>
        {
            await handle.Task;
            if (item.modelPrefab != null && itemAttachmentPoint != null)
            {
                GameObject instantiatedModel = Instantiate(handle.Result);
                instantiatedModel.transform.SetParent(itemAttachmentPoint);
                instantiatedModel.transform.localPosition = item.attachmentPosition;
                instantiatedModel.transform.localEulerAngles = item.attachmentRotation;
            }
        };
        }
        else
        {
            UnequipItem(item);
            isEquipped = false;
        }
        // UpdateUI();
    }

    public void UnequipItem(Item item)
    {
        isEquipped = false;


        if (item.modelPrefab != null && itemAttachmentPoint != null)
        {
            DropWeapon(item);
            Destroy(itemAttachmentPoint.GetChild(0).gameObject);
        }

        // UpdateUI();
    }


    public void DropWeapon(Item item)
    {
        collectablePrefabHandle.Completed += async handle =>
        {
            await handle.Task;
            if (item.collectablePrefab != null)
            {
                GameObject instantiatedCollectable = Instantiate(handle.Result);
                instantiatedCollectable.transform.localPosition = itemAttachmentPoint.transform.position;
            }
        };
    }

    private void LoadAddressableAssets(Item item)
    {
        modelPrefabHandle = Addressables.LoadAssetAsync<GameObject>(item.modelPrefab);
        collectablePrefabHandle = Addressables.LoadAssetAsync<GameObject>(item.collectablePrefab);
    }


}
