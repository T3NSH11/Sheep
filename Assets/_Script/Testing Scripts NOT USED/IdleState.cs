using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public WanderState wanderState;
    public bool canSeePlayer = false;
    public Transform player;
    public Transform AI;

    public override State RunCurrentState()
    {
        if (canSeePlayer)
        {
            return wanderState; 
        }
        else
        {
            CheckPlayer();
            return this;
        }
    }
    private void CheckPlayer()
    {
        if (player)
        {
            float dist = Vector3.Distance(player.position, AI.position);
            Debug.Log("Distance is : " + dist);
            if (dist < 20)
            {
                canSeePlayer = true;
               //return followState;
               Debug.Log("i should be switching states now");
            }
            else
            {
                canSeePlayer = false;
            }
        }

    }
}
