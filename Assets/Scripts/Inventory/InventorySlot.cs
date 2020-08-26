using System;

public class InventorySlot
{
    public readonly SlotType SlotType;
    public Item Item { get; private set; }

    public InventorySlot() => SlotType = SlotType.General;

    public InventorySlot(SlotType slotType) => SlotType = slotType;

    public event Action ItemChanged;

    public void SetItem(Item item)
    {
        Item = item;
        ItemChanged?.Invoke();
    }
}