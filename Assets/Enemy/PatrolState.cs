using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    private bool isPatrolling;
    private Vector3 destination;
    private int index;
    public void EnterState(EnemyScript enemy)
    {
        isPatrolling = false;
        index = 0;
    }

    public void UpdateState(EnemyScript enemy)
    {
        if (index < enemy.Waypoints.Count)
        {
            if (!isPatrolling)
            {
                destination = enemy.Waypoints[index].transform.position;
                enemy.NavMashAgent.SetDestination(destination);
                isPatrolling = true;
                index++;
            }
            else
            {
                if (Vector3.Distance(enemy.transform.position, destination) < 0.1f)
                {
                    isPatrolling = false;
                }
            }
        }
        else
        {
            index = 0;
        }
        
    }

    public void ExitState(EnemyScript enemy)
    {
        Debug.Log("Stop Patrol");
    }
}
