using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public void EnterState(EnemyScript enemy)
    {
        Debug.Log("Start Patrol");
    }

    public void UpdateState(EnemyScript enemy)
    {
        Debug.Log("Patrolling");
    }

    public void ExitState(EnemyScript enemy)
    {
        Debug.Log("Stop Patrol");
    }
}
