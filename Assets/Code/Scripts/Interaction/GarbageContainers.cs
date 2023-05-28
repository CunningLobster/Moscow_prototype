using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;

public class GarbageContainers : InteractableObject
{
    [SerializeField] private MonologueComponent containerMonologue;
    
    protected override IEnumerator RunInteractionRoutine()
    {
        while (_isAvailable)
        {
            _player.GetComponent<PlayerMover>().Target = gameObject;
            yield return ComeToInteractionPoint();
            
            containerMonologue.Action();
            FindObjectOfType<SoundManager>().OldSituationSound(SoundManager.NameOfSound.CheckGarbage);

            _isAvailable = false;
            SetDefaultCursor();
        }
    }
}
