using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{
    private BaseState currentState;

    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();
    public RetreatState retreatState = new RetreatState();

    private void Awake()
    {
        currentState = patrolState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

}
