using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Surface : InteractableObject
{
    public override void Interact(InputAction.CallbackContext context)
    {
        if (_isPointed)
        {
            _player.GetComponent<PlayerMover>().Target = null;
            _player.stoppingDistance = 0f;
            _player.destination = _raycaster.Hit.point;
        }
    }

}
