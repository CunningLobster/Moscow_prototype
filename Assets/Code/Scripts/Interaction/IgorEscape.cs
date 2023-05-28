using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;

public class IgorEscape : InteractableObject
{
    [SerializeField] private Animator igorAnimator;
    [SerializeField] private MonologueComponent monologueComponent;
    private static readonly int Escape = Animator.StringToHash("Escape");

    protected override IEnumerator RunInteractionRoutine()
    {
        igorAnimator.SetTrigger(Escape);
        MonologueManager.Instance.ShowMonologue(monologueComponent);
        yield return null;
    }
}
