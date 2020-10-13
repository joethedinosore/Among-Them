using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AITest : MonoBehaviour
{

    public NavMeshAgent agent;

    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(target);
    }
}
