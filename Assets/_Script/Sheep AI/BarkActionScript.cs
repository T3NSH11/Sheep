using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkActionScript : SheepState
{
    float switchTimer = 0;
    Vector3 SheepOffsett;

    public override void EnterState(SheepManager manager)
    {
        switchTimer = 0;
    }
    public override void UpdateState(SheepManager manager)
    {
        switchTimer += Time.deltaTime;

        if (manager.barkMove == true)
        {
            manager.BarkNum++;
            manager.gameObject.GetComponent<Rigidbody>().AddForce(manager.transform.forward * manager.PushForce);
            Debug.Log("moved");

            manager.barkMove = false;
        }

        if (switchTimer > 3)
        {
            manager.BarkedAt = false;
            manager.SwitchState(manager.wanderState);
        }

        if ((Vector3.Distance(manager.AI.position, manager.Wolf.transform.position) < 5) || (manager.BarkNum > 5))
        {
            manager.SwitchState(new Injured_Scared());
        }
    }
}



