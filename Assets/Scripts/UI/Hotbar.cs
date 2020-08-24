using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private Inventory _inventory;
    private Slot[] _slots;

    private void OnEnable()
    {
        PlayerInput.Instance.HotkeyPressed += HotkeyPressed;
        
        _inventory = FindObjectOfType<Inventory>();
        _slots = GetComponentsInChildren<Slot>();
    }

    private void OnDisable()
    {
        // remove event registration
        // if we don't do this, and this script gets called multiple times, we'll have multiple events triggering
        PlayerInput.Instance.HotkeyPressed -= HotkeyPressed;
    }

    private void HotkeyPressed(int index)
    {
        if (index >= _slots.Length || index < 0)
        {
            return;
        }
        if (_slots[index].IsEmpty == false)
        {
            _inventory.Equip(_slots[index].Item);
        }
    }
}