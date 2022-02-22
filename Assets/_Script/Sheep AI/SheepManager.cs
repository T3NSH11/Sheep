using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    SheepState currentState;
    public IdleTestScript idleTestScript = new IdleTestScript();
    public wanderState wanderState = new wanderState();
    public Transform AI;
    public Transform player;

    void Start()
    {
        wanderState.wanderAngleDisplacement = 0.2f;
        wanderState.wanderStrength = 0.60f;
        wanderState.speed = 1f;
        //starting the state 
        currentState = idleTestScript;
        //"this" is a reference to the context (this exact script)
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(SheepState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
