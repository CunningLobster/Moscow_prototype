using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        while (_isAvailable)
        {
            _player.GetComponent<PlayerMover>().Target = gameObject;
            yield return ComeToInteractionPoint();

            Debug.Log("Got the note");

            FindObjectOfType<SoundManager>().OldSituationSound(SoundManager.NameOfSound.ReadingBook);
            _isAvailable = false;
            _spriteRenderer.enabled = false;
        }
    }
}
