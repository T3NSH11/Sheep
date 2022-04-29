using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : SheepState
{
    float fleetimer;
    Vector3 DirectionAway;
    public override void EnterState(SheepManager manager)
    {

    }
    public override void UpdateState(SheepManager manager)
    {
        DirectionAway = manager.AI.position - manager.player.transform.position;
        DirectionAway.y = manager.transform.position.y;

        if (fleetimer > 0)
        {
            manager.AiRb.AddForce(DirectionAway.normalized * manager.MaxForce);
            Vector3.ClampMagnitude(manager.AiRb.velocity, manager.MaxVelocity);
        }

        if (fleetimer > 5)
        {
            manager.SwitchState(manager.wanderState);
            fleetimer = 0;
        }
    }

}
