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
        Vector3 LookAwayRotation = (manager.transform.position - manager.player.transform.position);
        LookAwayRotation.y = 0f;
        manager.transform.rotation = Quaternion.RotateTowards(manager.transform.rotation ,Quaternion.LookRotation(LookAwayRotation), Time.deltaTime * manager.RotationSpeed);
        manager.AiRb.velocity = manager.transform.forward * manager.BasicActionSpeed;

        if (Vector3.Distance(manager.player.transform.position, manager.transform.position) > 10)
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
