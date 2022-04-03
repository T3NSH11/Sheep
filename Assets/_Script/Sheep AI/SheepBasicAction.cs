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
        manager.transform.LookAt(manager.transform.position - (manager.player.transform.position - manager.transform.position));

        if(Vector3.Distance(manager.player.transform.position, manager.transform.position) > 5)
        {
            manager.SwitchState(manager.wanderState);
        }
    }
}
