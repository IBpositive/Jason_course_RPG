using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventorySlot : 
    MonoBehaviour, IPointerDownHandler, IEndDragHandler, 
    IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<UIInventorySlot> OnSlotClicked;
    
    [SerializeField] private Image _image;
    [SerializeField] private Image _selectedImage;
    [SerializeField] private Image _focusedImage;
    [SerializeField] private int _sortIndex;
    [SerializeField] private SlotType _slotType;


    public SlotType SlotType => _slotType;

    public IItem Item { get; private set; }
    
    public bool IsEmpty => Item == null;
    public Sprite Icon => _image.sprite;
    public bool IconImageEnabled => _image.enabled;
    public int SortIndex => _sortIndex;

    public void SetItem(IItem item)
    {
        Item = item;
        _image.sprite = item != null ? item.Icon : null;
        _image.enabled = item != null;
    }

    public void Clear()
    {
        Item = null;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnSlotClicked?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var droppedOnSlot = eventData.pointerCurrentRaycast.gameObject?.GetComponentInParent<UIInventorySlot>();
        if (droppedOnSlot != null)
            droppedOnSlot.OnPointerDown(eventData);
        else
            OnPointerDown(eventData);
    }

    public void OnDrag(PointerEventData eventData) { }
    
    public void BecomeSelected()
    {
        if (_selectedImage)
        {
            _selectedImage.enabled = true;
        }
    }
    
    public void BecomeUnselected()
    {
        if (_selectedImage)
        {
            _selectedImage.enabled = false;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_focusedImage)
        {
            _focusedImage.enabled = true;
        }   
    }
    
    public void OnPointerExit(PointerEventData eventData) => DisableFocusedImage();
    
    private void OnDisable() => DisableFocusedImage();
    
    private void DisableFocusedImage()
    {
        if (_focusedImage)
        {
            _focusedImage.enabled = false;
        }
    }
}