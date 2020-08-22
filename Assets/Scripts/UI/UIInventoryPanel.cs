using System;
using System.Collections;
using NSubstitute.ClearExtensions;
using UnityEngine;

public class UIInventoryPanel : MonoBehaviour
{
    [ContextMenu("Swap 01")]
    public void Swap01() => _inventory.Move(0, 1);
    
    private Inventory _inventory;

    public int SlotCount => Slots.Length;
    public UIInventorySlot Selected { get; private set; }
    
    public UIInventorySlot[] Slots;

    private void Awake()
    {
        Slots = GetComponentsInChildren<UIInventorySlot>();
        RegisterSlotsForClickCallback();
    }

    private void RegisterSlotsForClickCallback()
    {
        foreach (var slot in Slots)
        {
            slot.OnSlotClicked += HandleSlotClicked;
        }
    }

    private void HandleSlotClicked(UIInventorySlot slot)
    {
        Selected = slot;
    }

    public void Bind(Inventory inventory)
    {
        if (_inventory != null)
        {
            _inventory.ItemPickedUp -= HandleItemPickedUp;
            _inventory.OnItemChanged -= HandleItemChanged;
        }
        
        _inventory = inventory;

        if (_inventory != null)
        {
            _inventory.ItemPickedUp += HandleItemPickedUp;
            _inventory.OnItemChanged += HandleItemChanged;
            RefreshSlots();
        }
        else
        {
            ClearSlots();
        }
    }

    private void HandleItemChanged(int slotNumber)
    {
        Slots[slotNumber].SetItem(_inventory.GetItemInSlot(slotNumber));
    }

    private void ClearSlots()
    {
        foreach (var slot in Slots)
        {
            slot.Clear();
        }
    }

    private void RefreshSlots()
    {
        for (var i = 0; i < Slots.Length; i++)
        {
            var slot = Slots[i];
            if (_inventory.Items.Count > i)
            {
                slot.SetItem(_inventory.Items[i]);
            }
            else
            {
                slot.Clear();
            }
        }
    }

    private void HandleItemPickedUp(Item item)
    {
        RefreshSlots();
    }
}