using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBell : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        AudioClip clip = FindObjectOfType<SoundManager>().LoadClip(SoundManager.NameOfSound.DoorBell);
        float progress = 0f;

        if (_isAvailable)
        {
            FindObjectOfType<AudioSource>().PlayOneShot(clip);
            _isAvailable = false;
        }

        while (progress <= clip.length)
        {
            progress += Time.deltaTime;
            yield return null;
        }

        _isAvailable = true;
    }
}
