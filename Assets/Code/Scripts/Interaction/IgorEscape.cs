using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgorEscape : InteractableObject
{
    [SerializeField] private Animator igorAnimator;
    private static readonly int Escape = Animator.StringToHash("Escape");

    protected override IEnumerator RunInteractionRoutine()
    {
        igorAnimator.SetTrigger(Escape);
        yield return null;
    }
}
