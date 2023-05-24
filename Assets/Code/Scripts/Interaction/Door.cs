using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;
using UnityEngine.InputSystem;

public class Door : InteractableObject
{
    [SerializeField] string _sceneName;

    public override async void Interact(InputAction.CallbackContext context)
    {
        Debug.Log(_interactionPoint.position);
        try
        {
            if (_isPointed)
            {
                _player.GetComponent<PlayerMover>().Target = gameObject;
                await ComeToInteractionPoint();

                Debug.Log("Open door");

                if (string.IsNullOrEmpty(_sceneName))
                {
                    Debug.LogError("Scene name is empty");
                    return;
                }
                FindObjectOfType<LevelManager>().LoadScene(_sceneName);

            }
        }
        catch
        {
            return;
        }

    }
}
