using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    public void EnterState(EnemyScript enemy)
    {
        enemy.Animator.SetTrigger("RetreatState");
        Debug.Log("Start Retreating");
    }

    public void UpdateState(EnemyScript enemy)
    {
        if (enemy.Player != null)
        {
            Vector3 directionToPlayer = enemy.transform.position - enemy.Player.transform.position;
            Vector3 retreatPosition = enemy.transform.position + directionToPlayer.normalized * enemy.ChaseDistance;
            enemy.NavMashAgent.SetDestination(retreatPosition);
        }   
    }

    public void ExitState(EnemyScript enemy)
    {
        Debug.Log("Stop Retreating");
    }
}
