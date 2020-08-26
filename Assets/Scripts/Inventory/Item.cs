using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour, IItem
{
    [SerializeField] private CrosshairDefinition _crosshairDefinition;
    [SerializeField] private UseAction[] _actions = new UseAction[0];
    [SerializeField] private Sprite _icon;
    [SerializeField] private StatMod[] _statMods;
    [SerializeField] private SlotType _slotType;

    public StatMod[] StatMods => _statMods;

    public SlotType SlotType => _slotType;

    public event Action OnPickedUp;


    public UseAction[] Actions => _actions;
    public CrosshairDefinition CrosshairDefinition => _crosshairDefinition;
    public Sprite Icon => _icon;
    public bool WasPickedUp { get; set; }
   

    private void OnTriggerEnter(Collider other)
    {
        if (WasPickedUp)
            return;

        var inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.Pickup(this);
            OnPickedUp?.Invoke();
        }
    }

    private void OnValidate()
    {
        var collider = GetComponent<Collider>();
        if (collider.isTrigger == false)
            collider.isTrigger = true;
    }
}