using System;
using UnityEngine;

public interface IPlayerInput
{
    event Action<int> HotkeyPressed;
    event Action MoveModeTogglePressed;
    float Vertical { get; }
    float MouseX { get; }
    float Horizontal { get; }
    void Tick();
    bool PausePressed { get; }
    Vector2 MousePosition { get; }
}