using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    private float speedMultiplier = 1000;

    private Rigidbody playerRigidBody;
    private Vector2 playerDirection;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 vertical = transform.forward * playerDirection.y;
        Vector3 horizontal = transform.right * playerDirection.x;
        playerRigidBody.velocity = (vertical + horizontal) * speed * speedMultiplier * Time.fixedDeltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerDirection = context.ReadValue<Vector2>();
    }
}
