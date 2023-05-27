using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageContainers : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        while (_isAvailable)
        {
            _player.GetComponent<PlayerMover>().Target = gameObject;
            yield return ComeToInteractionPoint();

            Debug.Log("Garbage is utilized");

            _isAvailable = false;
            SetDefaultCursor();
        }
    }
}
