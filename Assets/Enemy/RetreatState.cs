using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : BaseState
{
    public void EnterState(EnemyScript enemy)
    {
        Debug.Log("Start Retreating");
    }

    public void UpdateState(EnemyScript enemy)
    {
        Debug.Log("Retreating");
    }

    public void ExitState(EnemyScript enemy)
    {
        Debug.Log("Stop Retreating");
    }
}
