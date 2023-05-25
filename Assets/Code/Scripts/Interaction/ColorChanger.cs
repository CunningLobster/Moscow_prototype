using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using System.Threading;

public class ColorChanger : InteractableObject
{
    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return StartCoroutine(ComeAlong());

        if (_player.GetComponent<PlayerMover>().Target.Equals(gameObject))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            yield return new WaitForSeconds(1f);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(1f);
            gameObject.GetComponent<Renderer>().material.color = Color.green;

        }
    }

}
