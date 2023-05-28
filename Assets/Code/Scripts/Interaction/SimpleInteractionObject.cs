using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInteractionObject : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        Debug.Log("Sound and commentary");
    }
}
