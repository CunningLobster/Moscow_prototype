using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ColorChanger : InteractableObject
{
    public override async void Interact(InputAction.CallbackContext context)
    {
        if (_isActive)
        {
            Debug.Log($"is active: {_isActive.ToString()}");
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            await System.Threading.Tasks.Task.Delay(2000);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            await System.Threading.Tasks.Task.Delay(2000);
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

}
