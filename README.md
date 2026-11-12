# Inventory System

A Unity inventory system for collecting, storing, equipping, and removing items during gameplay.

The system uses ScriptableObjects to define item data and Unity Addressables to load item models and collectable prefabs when needed. It also includes an inventory UI that displays collected items and allows the player to equip them.

## Features

- **Item definitions:** Create reusable item assets through ScriptableObjects.
- **Item collection:** Detect collectible objects through player trigger interactions.
- **Inventory management:** Add and remove items through an inventory interface.
- **Equipment handling:** Equip and unequip items, with support for attaching item models to a player transform.
- **Addressable assets:** Load item models and collectable prefabs through Unity Addressables.
- **Inventory UI:** Generate item UI elements dynamically and display item names and icons.
- **Item instances:** Includes an item-instance structure for tracking properties such as condition and ammunition.

## How it is organised

The main implementation is located in `Assets/Inventory system/Script/`.

| Script | Responsibility |
|---|---|
| `InventoryManager.cs` | Manages inventory items, UI updates, and equipment |
| `Inventory.cs` | Contains an alternative inventory implementation |
| `PlayerInventory.cs` | Detects collectible items and adds them to the inventory |
| `Item.cs` | Defines item data and Addressable references |
| `ItemContainer.cs` | Holds an item in the world and handles collection |
| `ItemData.cs` | Defines item data used by item instances |
| `ItemInstance.cs` | Stores instance-specific item properties |
| `IInventory.cs` | Defines the inventory operations |
| `IInventoryUI.cs` | Defines the inventory UI contract |

## Built with

- **Unity**
- **C#**
- **Unity Addressables**
- **TextMeshPro**
- **Unity UI**
