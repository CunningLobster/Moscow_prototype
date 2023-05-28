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

            AudioClip clip = FindObjectOfType<SoundManager>().LoadClip(SoundManager.NameOfSound.PlasticBag);
            FindObjectOfType<AudioSource>().PlayOneShot(clip);

            _isAvailable = false;
            SetDefaultCursor();
        }
    }
}
