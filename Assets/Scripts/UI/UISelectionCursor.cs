using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayTests
{
    public class UISelectionCursor : MonoBehaviour
    {
        [SerializeField] private Image _image;
        private UIInventoryPanel _inventoryPanel;

        public bool IconVisible => _image != null && _image.sprite != null && _image.enabled;
        public Sprite Icon => _image.sprite;

        private void Awake()
        {
            _inventoryPanel = FindObjectOfType<UIInventoryPanel>();
            _image.enabled = false;
        }

        private void Update()
        {
            transform.position = PlayerInput.Instance.MousePosition;
        }

        private void OnEnable() => _inventoryPanel.OnSelectionChanged += HandleSelectionChanged;
        private void OnDisable() => _inventoryPanel.OnSelectionChanged -= HandleSelectionChanged;
        private void HandleSelectionChanged()
        {
            _image.sprite = _inventoryPanel.Selected ? _inventoryPanel.Selected.Icon : null;
            _image.enabled = _image.sprite != null;
        }
    }
}