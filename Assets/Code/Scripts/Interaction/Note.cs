using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;

public class Note : InteractableObject
{
    [SerializeField] private MonologueComponent noteMonologue;
    
    protected override IEnumerator RunInteractionRoutine()
    {
        while (_isAvailable)
        {
            _player.GetComponent<PlayerMover>().Target = gameObject;
            yield return ComeToInteractionPoint();

            Debug.Log("Got the note");
            LevelManager.Instance.HasNote = true;
            noteMonologue.Observ();
            SoundManager.Instance.PlaySceneMusic();

            FindObjectOfType<SoundManager>().OldSituationSound(SoundManager.NameOfSound.ReadingBook);
            _isAvailable = false;
            _spriteRenderer.enabled = false;
        }
    }
}
