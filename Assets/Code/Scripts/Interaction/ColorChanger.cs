using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class ColorChanger : InteractableObject
{
    public override async void Interact(InputAction.CallbackContext context)
    {
        if (_isPointed)
        {
            _player.GetComponent<PlayerMover>().Target = gameObject;
            await ComeAlong();

            if (_player.GetComponent<PlayerMover>().Target.Equals(gameObject))
            {
                Debug.Log($"is active: {_isPointed.ToString()}");
                gameObject.GetComponent<Renderer>().material.color = Color.cyan;
                await Task.Delay(1000);
                gameObject.GetComponent<Renderer>().material.color = Color.red;
                await Task.Delay(1000);
                gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }

}
