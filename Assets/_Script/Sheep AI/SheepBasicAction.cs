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
        Vector3 LookAwayPosition = (manager.transform.position - manager.player.transform.position) + manager.transform.position;
        LookAwayPosition.y = manager.transform.position.y;
        manager.transform.LookAt(LookAwayPosition);
        manager.AiRb.velocity = (manager.AiRb.velocity / 5);

        if (Vector3.Distance(manager.player.transform.position, manager.transform.position) > 5)
        {
            manager.SwitchState(manager.wanderState);
        }

        if (manager.BarkedAt)
        {
            manager.SwitchState(new BarkActionScript());
        }

        if ((Vector3.Distance(manager.AI.position, manager.Wolf.transform.position) < 5) || (manager.BarkNum > 5))
        {
            manager.SwitchState(new Injured_Scared());
        }
    }

    public override void FixedUpdateState(SheepManager manager)
    {

    }
}
