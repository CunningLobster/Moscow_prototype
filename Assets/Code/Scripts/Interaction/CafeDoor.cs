using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;

public class CafeDoor : InteractableObject
{
    [SerializeField] private Texture2D _activatedCursor;
    [SerializeField] private MonologueComponent cafeMonologue;
    [SerializeField] private GameObject riddleButton;
    
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        AudioClip clip = FindObjectOfType<SoundManager>().LoadClip(SoundManager.NameOfSound.KnockDoor);
        float progress = 0f;

        if (!_isObserved)
        {
            _isObserved = true;
            _pointCursor = _activatedCursor;
            UpdateCursor();
            cafeMonologue.Observ();
            riddleButton.SetActive(true);
            yield break;
            
        }
        else
        {
            if (_isAvailable)
            {
                FindObjectOfType<AudioSource>().PlayOneShot(clip);
                _isAvailable = false;
            }

            yield return new WaitForSeconds(clip.length);
            // while (progress <= clip.length)
            // {
            //     progress += Time.deltaTime;
            //     yield return null;
            // }

            _isAvailable = true;
        }

    }

}
