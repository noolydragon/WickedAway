using System;

[Serializable]
public class InventorySlot
{
    public ItemData itemData;
    public int quantity;

    public InventorySlot(ItemData item, int amount)
    {
        itemData = item;
        quantity = amount;
    }

    public bool IsEmpty => itemData == null || quantity <= 0;

    public void Clear()
    {
        itemData = null;
        quantity = 0;
    }
}
