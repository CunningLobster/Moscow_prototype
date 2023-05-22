using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public abstract class InteractableObject : MonoBehaviour
{
    protected NavMeshAgent _player;
    protected Raycaster _raycaster;
    protected bool _isPointed;
    protected bool _isActivated;

    [SerializeField] private float _distance = 1f;
    [SerializeField] private InputAction MouseClickAction;

    public void OnEnable()
    {
        MouseClickAction.Enable();
        MouseClickAction.performed += Interact;
    }

    public void OnDisable()
    {
        MouseClickAction.performed += Interact;
        MouseClickAction.Enable();
    }

    public void Start()
    {
        _raycaster = FindObjectOfType<Raycaster>();
        _player = FindObjectOfType<PlayerMover>().GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (_raycaster.Hit.transform == null) return;
        _isPointed = _raycaster.Hit.transform != null && _raycaster.Hit.transform.Equals(transform);

        if (_isPointed)
            Debug.Log(gameObject.name);
    }

    public abstract void Interact(InputAction.CallbackContext context);

    protected async Task ComeAlong()
    {
        _player.stoppingDistance = _distance;
        _player.destination = _raycaster.Hit.point;

        while (Vector3.Distance(_player.transform.position, _player.destination) >= _distance)
            await Task.Yield();
    }
}
