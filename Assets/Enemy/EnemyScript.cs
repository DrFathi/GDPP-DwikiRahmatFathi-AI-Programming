using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private BaseState currentState;

    public PatrolState patrolState = new PatrolState();
    public ChaseState chaseState = new ChaseState();
    public RetreatState retreatState = new RetreatState();

    [SerializeField]
    public List<GameObject> Waypoints = new List<GameObject>();

    [HideInInspector]
    public NavMeshAgent NavMashAgent;

    [SerializeField]
    public float ChaseDistance;

    [SerializeField]
    public PlayerScript Player;

    private void Awake()
    {
        NavMashAgent = GetComponent<NavMeshAgent>();
        currentState = patrolState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }
    }

    public void SwitchState(BaseState newState)
    {
       
        currentState.ExitState(this);
        currentState = newState;
        
        currentState.EnterState(this);

    }

}
