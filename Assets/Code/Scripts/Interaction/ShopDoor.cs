using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDoor : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        Debug.Log("Ask a worker");
    }
}
