using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        Debug.Log("Got the note");

        gameObject.SetActive(false);
    }
}
