using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class NPCLoot : MonoBehaviour
{
    [SerializeField] private Item[] _itemPrefabs;
    
    
    private Inventory _inventory;

    // Awake gets called before start
    private void Start()
    {
        _inventory = GetComponent<Inventory>();

        foreach (var itemPrefab in _itemPrefabs)
        {
            var itemInstance = Instantiate(itemPrefab);
            _inventory.Pickup(itemInstance);
        }
    }
}
