using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTestScript : SheepState
{
    public WanderState wanderState;
    public Transform player;
    public Transform AI;
    bool switchState = false;

    public override void EnterState(SheepManager manager)
    {
        Debug.Log("test");
    }
    public override void UpdateState(SheepManager manager)
    {
        if(switchState == false)
        {
            CheckPlayer(manager.player, manager.AI);
        }
        else
        {
            manager.SwitchState(manager.wanderState);
        }
    }


    public void CheckPlayer(Transform player, Transform AI)
    {
        if (player)
        {
            float dist = Vector3.Distance(player.position, AI.position);
            //Debug.Log("Distance is : " + dist);
            if (dist < 20)
            {
                Debug.Log("i should be switching states now");
                switchState = true;
            }
        }

    }
}
