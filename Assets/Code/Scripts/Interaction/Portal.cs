using System.Collections;
using System.Collections.Generic;
using Code.Scripts.Systems;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Portal : InteractableObject
{
    [SerializeField] string _sceneName;

    enum Destinations { A, B, C, D }
    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Destinations destination;

    protected override async Task RunInteractionTask()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        await ComeToInteractionPoint();

        Debug.Log("Open door");

        if (string.IsNullOrEmpty(_sceneName))
        {
            Debug.LogError("Scene name is empty");
            return;
        }

        //await Task.Run(() => FindObjectOfType<LevelManager>().LoadScene(_sceneName));
        await Task.Run(() => Debug.Log("runrurnurnurn"));

        Portal otherPortal = GetOtherPortal();
    }

    private void UpdatePlayer(Portal otherPortal)
    {
        GameObject player = GameObject.FindObjectOfType<PlayerMover>().gameObject;
        //player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position);
        player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        player.transform.position = otherPortal._interactionPoint.position;
        player.transform.rotation = otherPortal._interactionPoint.rotation;
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
