using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
    [SerializeField] private CrosshairDefinition _crosshairDefinition;
    [SerializeField] private UseAction[] _actions = new UseAction[0];
    [SerializeField] private Sprite _icon;

    public UseAction[] Actions => _actions;
    public CrosshairDefinition CrosshairDefinition => _crosshairDefinition;
    public Sprite Icon => _icon;

    private bool _wasPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (_wasPickedUp)
            return;

        var inventory = other.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.Pickup(this);
            _wasPickedUp = true;
        }
    }

    private void OnValidate()
    {
        var collider = GetComponent<Collider>();
        // the if statement is to avoid an UI bug in unity 
        // Jason talks about it in 8f of the game architecture course.
        if (collider.isTrigger == false)
        {
            collider.isTrigger = true;
        }
    }
}

[CustomEditor(typeof(Item))]
public class ItemEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Item item = (Item) target;


        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Icon", GUILayout.Width(150));

        if (item.Icon != null)
        {
            GUILayout.Box(item.Icon.texture, GUILayout.Width(60), GUILayout.Height(60));
        }
        else
        {
            EditorGUILayout.HelpBox("No Icon Selected", MessageType.Error);
        }

        // this lets us reuse this code multiple times without copy/paste i think.
        using (var property = serializedObject.FindProperty("_icon"))
        {
            var sprite = (Sprite) EditorGUILayout.ObjectField(item.Icon, typeof(Sprite), false);
            property.objectReferenceValue = sprite;
            serializedObject.ApplyModifiedProperties();
        }


        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Crosshair", GUILayout.Width(150));

        if (item.CrosshairDefinition?.Sprite != null)
        {
            GUILayout.Box(item.CrosshairDefinition.Sprite.texture, GUILayout.Width(60), GUILayout.Height(60));
        }
        else
        {
            EditorGUILayout.HelpBox("No Crosshair Selected", MessageType.Error);
        }

        // this lets us reuse this code multiple times without copy/paste i think.
        using (var property = serializedObject.FindProperty("_crosshairDefinition"))
        {
            var crosshairDefinition = (CrosshairDefinition) EditorGUILayout.ObjectField(
                item.CrosshairDefinition,
                typeof(CrosshairDefinition),
                false);
            property.objectReferenceValue = crosshairDefinition;
            serializedObject.ApplyModifiedProperties();
        }


        EditorGUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}