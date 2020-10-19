using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(NavMeshObstacle))]
public class EnemyAI : MonoBehaviour
{
    [Header("Readouts")]
    public int lastTask;

    [Header("Interfaces")]
    public Transform[] tasks;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        getNextTask();
    }

    public void OnReachTask(float delay, float taskValue)
    {
        StartCoroutine(waitForTask(delay, taskValue));
    }

    void getNextTask()
    {
        int nextTesk = getNextIndex();
        lastTask = nextTesk;

        agent.SetDestination(tasks[nextTesk].position);
    }

    int getNextIndex()
    {
        //get random task
        int x = Random.Range(0, tasks.Length);

        //try again if it is the last done task
        if (x == lastTask)
        {
            return (getNextIndex());
        }

        //else, return x
        return (x);
    }

    IEnumerator waitForTask(float delay, float taskValue)
    {
        //wait the delay
        yield return new WaitForSeconds(delay);

        //add the task value to the counter
        //up task counter

        //start pathing to the next task
        getNextTask();
    }
}
