using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public void EnterState(EnemyScript enemy)
    {
        Debug.Log("Start Chasing");
    }

    public void UpdateState(EnemyScript enemy)
    {
        Debug.Log("Chasing");
    }

    public void ExitState(EnemyScript enemy)
    {
        Debug.Log("Stop Chasing");
    }
}
