using System.Collections;
using UnityEngine;

public interface IItem
{
    Sprite Icon { get; }
    GameObject gameObject { get; }
    Transform transform { get; }
    CrosshairDefinition CrosshairDefinition { get; }
    UseAction[] Actions { get; }
    StatMod[] StatMods { get; }
}