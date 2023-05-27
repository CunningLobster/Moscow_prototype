using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageContainers : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeAlong();

        Debug.Log("Garbage is utilized");

        _isAvailable = false;
        SetDefaultCursor();

        yield break;
    }
}
