using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Saving;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour, ISaveable
{
    public GameObject Target { get; set; }

    public object CaptureState()
    {
        return new SerializableVector3(transform.position);
    }

    public void RestoreState(object state)
    {
        SerializableVector3 position = (SerializableVector3)state;
        GetComponent<NavMeshAgent>().enabled = false;
        transform.position = position.ToVector();
        GetComponent<NavMeshAgent>().enabled = true;
    }

}
