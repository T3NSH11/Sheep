using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : SheepState
{
    Vector3 DirectionAway;
    public override void EnterState(SheepManager manager)
    {

    }
    public override void UpdateState(SheepManager manager)
    {
        DirectionAway = manager.AI.position - manager.player.position;

        if (Vector3.Distance(manager.AI.position, manager.player.position) < 200)
        {
            manager.AiRb.AddForce(DirectionAway.normalized);
        }
    }
}
