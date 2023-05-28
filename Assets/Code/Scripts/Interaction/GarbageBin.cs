using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;

public class GarbageBin : InteractableObject
{
    [SerializeField] private Sprite _activatedSprite;
    [SerializeField] private Texture2D _activatedCursor;

    [SerializeField] private MonologueComponent binMonologueObserv;
    [SerializeField] private MonologueComponent binMonologueInteraction;

    protected override IEnumerator RunInteractionRoutine()
    {
        if (_isActivated) yield break;

        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();
        

        while (_isAvailable)
        {
            if (!_isObserved)
            {
                _isObserved = true;
                _pointCursor = _activatedCursor;
                UpdateCursor();
                binMonologueObserv.Observ();
                yield break;
            }
            else
            {
                _isActivated = true;
                GetComponent<SpriteRenderer>().sprite = _activatedSprite;
                binMonologueInteraction.Action();
                AudioClip clip = FindObjectOfType<SoundManager>().LoadClip(SoundManager.NameOfSound.PlasticBag);
                FindObjectOfType<AudioSource>().PlayOneShot(clip);

                _isAvailable = false;
                FindObjectOfType<GarbageContainers>().SetAvailable(true);
                SetDefaultCursor();
                yield break;
            }
        }
    }

}
