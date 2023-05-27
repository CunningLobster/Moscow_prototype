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

        if (_isObserved == false)
        {
            _isObserved = true;
            _pointCursor = _activatedCursor;
            Cursor.SetCursor(_pointCursor, _hotspot, CursorMode.Auto);
        }
        else
        {
            _isActivated = true;
            GetComponent<SpriteRenderer>().sprite = _activatedSprite;
        }
    }

}
