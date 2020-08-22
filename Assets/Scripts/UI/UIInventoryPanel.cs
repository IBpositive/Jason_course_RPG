using System.Collections;
using NSubstitute.ClearExtensions;
using UnityEngine;

public class UIInventoryPanel : MonoBehaviour
{
    public UIInventorySlot[] Slots;

    private void Awake()
    {
        Slots = GetComponentsInChildren<UIInventorySlot>();
    }

    public int SlotCount => Slots.Length;

    public void Bind(Inventory inventory)
    {
        for (var i = 0; i < Slots.Length; i++)
        {
            var slot = Slots[i];
            if (inventory.Items.Count > i)
            {
                slot.SetItem(inventory.Items[i]);
            }
            else
            {
                slot.Clear();
            }
        }
    }
}