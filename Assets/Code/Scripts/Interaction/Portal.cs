using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;
using UnityEngine.InputSystem;

public class Portal : InteractableObject
{
    [SerializeField] string _sceneName;

    enum Destinations { A, B, C, D }
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] Destinations destination;

    [SerializeField] float fadeOutTime = 1f;
    [SerializeField] float fadeInTime = 1f;
    [SerializeField] float timeBetweenFades = .2f;


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

    private void UpdatePlayer(Portal otherPortal)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);
        player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        player.transform.position = otherPortal.spawnPoint.position;
        player.transform.rotation = otherPortal.spawnPoint.rotation;
        player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;

    }

    private Portal GetOtherPortal()
    {
        foreach (Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this || portal.destination != this.destination)
            {
                continue;
            }
            return portal;
        }
        return null;
    }
}
