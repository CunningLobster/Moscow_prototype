using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private GameObject plain;
    [SerializeField] private GameObject player;
    [SerializeField] private float velocity = 10;
    private Rigidbody playerRigidBody;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vertical = player.transform.forward * playerDirection.y;
        Vector3 horizontal = player.transform.right * playerDirection.x;
        playerRigidBody.velocity = (vertical + horizontal) * velocity;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerDirection = context.ReadValue<Vector2>();
    }
}
