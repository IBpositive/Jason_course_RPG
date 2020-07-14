using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private IMover _mover;
    private Rotator _rotator;
    public IPlayerInput PlayerInput { get; set; } = new PlayerInput();

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mover = new Mover( this);
        _rotator = new Rotator(this);

        PlayerInput.MoveModeTogglePressed += MoveModeTogglePressed;
    }

    private void MoveModeTogglePressed()
    {
        if (_mover is NavmeshMover)
        {
            _mover = new Mover(this);
        }
        else
        {
            _mover = new NavmeshMover(this);
        }
    }

    private void Update()
    {
        if (Pause.Active)
        {
            return;
        }
        _mover.Tick();
        _rotator.Tick();
        PlayerInput.Tick();
    }
}