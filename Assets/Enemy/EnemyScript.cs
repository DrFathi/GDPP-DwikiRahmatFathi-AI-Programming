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

    public Animator Animator;

    private void Awake()
    {
        Animator = GetComponent<Animator>();

        NavMashAgent = GetComponent<NavMeshAgent>();
        currentState = patrolState;
        currentState.EnterState(this);
    }

    private void Start()
    {
        if (Player != null)
        {
            Player.OnPowerUpStart += StartRetreating;
            Player.OnPowerUpStop += StopRetreating;
        }
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

    private void StartRetreating()
    {
        SwitchState(retreatState);
    }

    private void StopRetreating()
    {
        SwitchState(patrolState);
    }

}
