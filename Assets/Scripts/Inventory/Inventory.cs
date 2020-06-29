using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inventory master class.
/// </summary>
public class Inventory : MonoBehaviour
{
    [SerializeField] private Transform _rightHand;
    
    private List<Item> _items = new List<Item>();
    private Transform _itemRoot;
    
    public Item ActiveItem { get; private set; }

    // We make the awake to initialize _item and _itemRoot.
    private void Awake()
    {
        _itemRoot = new GameObject("Items").transform;
        _itemRoot.transform.SetParent(transform);
    }

    public void Pickup(Item item)
    {
        _items.Add(item);
        item.transform.SetParent(_itemRoot);

        Equip(item);
    }

    private void Equip(Item item)
    {
        Debug.Log($"Equipped Item {item.gameObject.name}");
        item.transform.SetParent(_rightHand);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;
        ActiveItem = item;
    }
}