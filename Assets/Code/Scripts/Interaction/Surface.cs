using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Surface : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = null;
        _player.stoppingDistance = 0f;
        _player.destination = _raycaster.Hit.point;
        yield return null;
    }
}
