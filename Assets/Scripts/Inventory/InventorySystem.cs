// using System;
// using System.Collections.Generic;
// using UnityEngine;


// public class InventorySystem : MonoBehaviour
// {
//     public int inventorySize = 10;
//     public InventorySlot[] slots;

//     public event Action OnInventoryChanged;

//     private void Awake()
//     {
//         slots = new InventorySlot[inventorySize];
//         for(int i = 0; i < inventorySize; i++)
//         {
//             slots[i] = new InventorySlot(null, 0);
//         }
//     }

//     public bool AddItem(ItemData item, int amount)
//     {
//         if (item.isStackable)
//         {
//             foreach (var slot in slots)
//             {
//                 if(!slot.IsEmpty && slot.itemData == item && slot.quantity < item.maxStackSize)
//                 {
//                     int spaceLeft = item.maxStackSize - slot.quantity;
//                     int amountToAdd = Mathf.Min(spaceLeft, amount);
//                     slot.quantity += amountToAdd;
//                     amount -= amountToAdd;

//                     if (amount <= 0)
//                     {
//                         OnInventoryChanged?.Invoke();
//                         return true;
//                     }
//                 }
//             }
//         }

//         while (amount > 0)
//         {
//             int emptyIndex = GetEmptySlotIndex();
//             if (emptyIndex == -1)
//             {
//                 OnInventoryChanged?.Invoke();
//                 return false;
//             }
//             int stackAmount = Mathf.Min(amount, item.isStackable ? item.maxStackSize : 1);
//             slots[emptyIndex] = new InventorySlot(item, stackAmount);
//             amount -= stackAmount;
//         }
//     }

//     private int GetEmptySlotIndex()
//     {
//         for(int i = 0; i < slots.Length; i++)
//         {
//             if(slots[i].IsEmpty) return i;
//         }
//         return -1;
//     }
// }
