using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rotator : InteractableObject
{
    public override async void Interact(InputAction.CallbackContext context)
    {
        try
        {
            if (_isPointed)
            {
                var end = Time.time + 5000;
                while (Time.time < end)
                {
                    transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
                    await Task.Yield();
                }
            }
        }
        catch
        {
            return;
        }
    }
}
