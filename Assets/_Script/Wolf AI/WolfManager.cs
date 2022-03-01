using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfManager : MonoBehaviour
{
    WolfState currentState;
    public Transform AI;
    public Transform player;

    void Start()
    {
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(WolfState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
