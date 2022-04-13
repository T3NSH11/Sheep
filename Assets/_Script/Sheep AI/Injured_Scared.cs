using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Injured_Scared : SheepState
{
    int random;
    float injuretimer;
    public override void EnterState(SheepManager manager)
    {
        
    }

    public override void UpdateState(SheepManager manager)
    {
        if ((Vector3.Distance(manager.AI.position, manager.Wolf.transform.position) < 10 && random == 0) || (manager.BarkNum > 5 && random == 0))
        {
            random = Random.Range(1, 100);
        }

        if (random >= 1 && random <= 50)
        {
            if(injuretimer < 20)
            {
                injuretimer += Time.deltaTime;
            }

            if (injuretimer >= 20)
            {
                manager.BarkNum = 0;
                injuretimer = 0;
            }
        }

        if (random >= 51 && random <= 100)
        {
            manager.BarkNum = 0;
            manager.SwitchState(new FleeState());
        }

        if (injuretimer <= 0)
        {
            manager.SwitchState(manager.wanderState);
        }
    }

    public override void FixedUpdateState(SheepManager manager)
    {

    }
}
