using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Inventory master class.
/// </summary>
public class Inventory : MonoBehaviour
{
    private const int DEFAULT_INVENTORY_SIZE = 25;
    public event Action<Item> ActiveItemChanged;
    public event Action<Item> ItemPickedUp;

    [SerializeField] private Transform _rightHand;

    private Item[] _items = new Item[DEFAULT_INVENTORY_SIZE];
    private Transform _itemRoot;
    

    public Item ActiveItem { get; private set; }
    public List<Item> Items => _items.ToList();
    public int Count => _items.Count(t => t != null);

    // We make the awake to initialize _item and _itemRoot.
    private void Awake()
    {
        _itemRoot = new GameObject("Items").transform;
        _itemRoot.transform.SetParent(transform);
    }

    public void Pickup(Item item, int? slot = null)
    {
        if (slot.HasValue == false)
        {
            slot = FindFirstAvailableSlot();
        }

        if (slot.HasValue == false)
        {
            return;
        }
        _items[slot.Value] = item;
        item.transform.SetParent(_itemRoot);
        ItemPickedUp?.Invoke(item);
        item.WasPickedUp = true;

        Equip(item);
    }

    private int? FindFirstAvailableSlot()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i] == null)
            {
                return i;
            }
        }

        return null;
    }

    public void Equip(Item item)
    {
        if (ActiveItem != null)
        {
            ActiveItem.transform.SetParent(_itemRoot);
            ActiveItem.gameObject.SetActive(false);
        }

        Debug.Log($"Equipped Item {item.gameObject.name}");
        item.transform.SetParent(_rightHand);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        ActiveItem = item;
        // if active item is not null then invoke
        // ? is making a null propagation method
        ActiveItemChanged?.Invoke(ActiveItem);
    }

    public Item GetItemInSlot(int slot)
    {
        return _items[slot];
    }
}