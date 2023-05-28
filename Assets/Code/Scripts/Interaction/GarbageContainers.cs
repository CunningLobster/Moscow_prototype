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

            FindObjectOfType<SoundManager>().OldSituationSound(SoundManager.NameOfSound.CheckGarbage);

            _isAvailable = false;
            SetDefaultCursor();
        }
    }
}
