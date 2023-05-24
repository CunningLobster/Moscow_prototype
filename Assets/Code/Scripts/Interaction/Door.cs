using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : InteractableObject
{


    public override async void Interact(InputAction.CallbackContext context)
    {
        Debug.Log(_interactionPoint.position);
        try
        {
            if (_isPointed)
            {
                _player.GetComponent<PlayerMover>().Target = gameObject;
                await ComeToInteractionPoint();

                Debug.Log("Open door");

            }
        }
        catch
        {
            return;
        }

    }
}
