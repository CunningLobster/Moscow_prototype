using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;

public class SimpleInteractionObject : InteractableObject
{
    [SerializeField] private MonologueComponent bookShellMonologue;

    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        Debug.Log("Sound and commentary");
        bookShellMonologue.Observ();
    }
}
