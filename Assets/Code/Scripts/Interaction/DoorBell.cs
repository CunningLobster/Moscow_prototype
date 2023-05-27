using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBell : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        float duration = 4.272f;
        float progress = 0f;

        if (_isAvailable)
        {
            FindObjectOfType<SoundManager>().SituationSound(SoundManager.NameOfSound.DoorBell);
            _isAvailable = false;
        }

        while (progress <= duration)
        {
            progress += Time.deltaTime;
            yield return null;
        }

        _isAvailable = true;
    }
}
