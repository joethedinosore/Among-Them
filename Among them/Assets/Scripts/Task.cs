using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public float delay;

    public float taskValue;

    public int id;

    //trigger when the task's aoe is entered
    private void OnTriggerEnter(Collider other)
    {
        //check if it was an enemy
        if(other.gameObject.tag == "Enemy")
        {
            //check if this task was their target
            if (other.gameObject.GetComponent<EnemyAI>().lastTask == id)
            {
                //trigger target event
                other.gameObject.GetComponent<EnemyAI>().OnReachTask(delay, taskValue);
            }
        }
    }
}
