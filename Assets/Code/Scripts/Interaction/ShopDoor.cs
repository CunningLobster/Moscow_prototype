using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;

public class ShopDoor : InteractableObject
{
    [SerializeField] private MonologueComponent shopMonologue;
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        Debug.Log("Ask a worker");
        shopMonologue.Action();
        
    }
}
