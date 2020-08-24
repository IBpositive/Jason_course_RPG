using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class Slot : MonoBehaviour
{
    [FormerlySerializedAs("_icon")] [SerializeField] private Image _iconImage;
    [SerializeField] TMP_Text _text;
    public Item Item { get; private set; }
    public bool IsEmpty => Item == null;
    public Image IconImage => _iconImage;

    // runs when saved or compiled. This is why it auto updates if you duplicate and add slots.
    private void OnValidate()
    {
        _text.GetComponentInChildren<TMP_Text>();
        int hotkeyNumber = transform.GetSiblingIndex() + 1;
        _text.SetText(hotkeyNumber.ToString());
        gameObject.name = "Slot " + hotkeyNumber;
    }
}