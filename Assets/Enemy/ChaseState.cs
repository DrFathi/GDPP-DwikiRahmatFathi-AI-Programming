using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : BaseState
{
    public void EnterState(EnemyScript enemy)
    {
        enemy.Animator.SetTrigger("ChaseState");
        Debug.Log("Start Chasing");
    }

    public void UpdateState(EnemyScript enemy)
    {
        if (enemy.Player != null)
        {
            enemy.NavMashAgent.SetDestination(enemy.Player.transform.position);

            if(Vector3.Distance(enemy.transform.position, enemy.Player.transform.position) > enemy.ChaseDistance)
            {
                enemy.SwitchState(enemy.patrolState);
            }
        }
        Debug.Log("Chasing");
    }

    public void ExitState(EnemyScript enemy)
    {
        Debug.Log("Stop Chasing");
    }
}
