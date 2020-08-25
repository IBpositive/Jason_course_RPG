using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _characterController;
    private IMover _mover;
    private Rotator _rotator;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _mover = new Mover(this);
        _rotator = new Rotator(this);

        PlayerInput.Instance.MoveModeTogglePressed += MoveModeTogglePressed;
    }

    private void MoveModeTogglePressed()
    {
        if (_mover is NavmeshMover)
            _mover = new Mover(this);
        else
            _mover = new NavmeshMover(this);
    }

    private void Update()
    {
        if (Pause.Active)
            return;
        
       _mover.Tick();
       _rotator.Tick();
    }
}