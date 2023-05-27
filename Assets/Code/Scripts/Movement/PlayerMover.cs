using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Saving;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour, ISaveable
{
    private NavMeshAgent _navMeshAgent;
    public GameObject Target { get; set; }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public object CaptureState()
    {
        return new SerializableVector3(transform.position);
    }

    public void RestoreState(object state)
    {
        SerializableVector3 position = (SerializableVector3)state;
        _navMeshAgent.enabled = false;
        transform.position = position.ToVector();
        _navMeshAgent.enabled = true;
    }
}
