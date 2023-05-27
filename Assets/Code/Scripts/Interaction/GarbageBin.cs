using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBin : InteractableObject
{
    [SerializeField] private Sprite _activatedSprite;
    [SerializeField] private Texture2D _activatedCursor;

    protected override IEnumerator RunInteractionRoutine()
    {
        if (_isActivated) yield return null;

        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeAlong();

        Debug.Log("Came to garbage bag");

        while (_isAvailable)
        {
            if (!_isObserved)
            {
                _isObserved = true;
                _pointCursor = _activatedCursor;
                UpdateCursor();
                yield break;
            }
            else
            {
                _isActivated = true;
                GetComponent<SpriteRenderer>().sprite = _activatedSprite;
                _isAvailable = false;
                FindObjectOfType<GarbageContainers>().SetAvailable(true);
                SetDefaultCursor();
                yield break;
            }

        }
    }

}
