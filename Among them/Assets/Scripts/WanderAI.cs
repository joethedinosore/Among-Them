using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{

    public NavMeshAgent agent;

    public Transform target;

    public Transform targetParent;

    public GameObject targetFab;


    // Start is called before the first frame update
    void Start()
    {
        target = Instantiate(targetFab, targetParent).GetComponent<Transform>();
        target.gameObject.GetComponent<WanderMarker>().parentObject = gameObject;
        target.position = transform.position;
        updateTarget();
    }

    public void updateTarget()
    {
        agent.SetDestination(target.position);
    }
}
