using System.Collections;
using Code.Scripts.Systems;
using UnityEngine;

public class Portal : InteractableObject
{
    [SerializeField] string _sceneName;

    enum Destinations { A, B, C, D }
    [SerializeField] Destinations destination;

    protected override IEnumerator RunInteractionRoutine()
    {
        _player.GetComponent<PlayerMover>().Target = gameObject;
        yield return ComeToInteractionPoint();

        if (string.IsNullOrEmpty(_sceneName))
        {
            Debug.LogError("Scene name is empty");
            yield return null;
        }

        DontDestroyOnLoad(gameObject);
        yield return FindObjectOfType<LevelManager>().LoadSceneAsync(_sceneName);

        Portal otherPortal = GetOtherPortal();
        if (otherPortal != null)
            UpdatePlayer(otherPortal);

        Destroy(gameObject);
    }

    private void UpdatePlayer(Portal otherPortal)
    {
        GameObject player = GameObject.FindObjectOfType<PlayerMover>().gameObject;
        player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        player.transform.position = otherPortal._interactionPoint.position;
        player.transform.rotation = otherPortal._interactionPoint.rotation;
        player.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;

    }

    private Portal GetOtherPortal()
    {
        try
        {
            foreach (Portal portal in FindObjectsOfType<Portal>())
            {
                if (portal == this || portal.destination != this.destination)
                    continue;

                return portal;
            }
            return null;
        }
        catch
        {
            return null;
        }
    }
}
