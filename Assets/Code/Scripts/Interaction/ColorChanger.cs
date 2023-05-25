using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using System.Threading;

public class ColorChanger : InteractableObject
{
    protected override async Task RunInteractionTask()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        await ComeAlong();

        if (_player.GetComponent<PlayerMover>().Target.Equals(gameObject))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            await Task.Delay(1000);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            await Task.Delay(1000);
            gameObject.GetComponent<Renderer>().material.color = Color.green;

        }
    }

}
