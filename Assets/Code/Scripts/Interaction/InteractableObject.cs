using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InteractableObject : MonoBehaviour
{
    private Raycaster _raycaster;
    protected bool _isActive;
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
    }

    public void Update()
    {
        _isActive = _raycaster.Hit.transform != null && _raycaster.Hit.transform.Equals(transform);

        if (_isActive)
            Debug.Log(gameObject.name + " is active");
    }

    public abstract void Interact(InputAction.CallbackContext context);
}
