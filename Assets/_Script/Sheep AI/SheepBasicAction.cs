using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBasicAction : SheepState
{
    public override void EnterState(SheepManager manager)
    {

    }

    public override void UpdateState(SheepManager manager)
    {
        // make rotation gradual
        manager.transform.LookAt((manager.transform.position - manager.player.transform.position) + manager.transform.position);
        manager.AiRb.velocity = (manager.AiRb.velocity / 5);

        if (Vector3.Distance(manager.player.transform.position, manager.transform.position) > 5)
        {
            manager.SwitchState(manager.wanderState);
        }

        if (manager.BarkedAt)
        {
            manager.SwitchState(new BarkActionScript());
        }
    }

    public override void FixedUpdateState(SheepManager manager)
    {

    }
}
