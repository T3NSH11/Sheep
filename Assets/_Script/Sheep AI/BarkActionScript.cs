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

    }

    public override void FixedUpdateState(SheepManager manager)
    {
        switchTimer += Time.deltaTime;

        if (manager.barkMove == true)
        {
            manager.gameObject.GetComponent<Rigidbody>().AddForce(manager.transform.forward * manager.PushForce);
            Debug.Log("moved");

            manager.barkMove = false;
        }

        if (switchTimer > 3)
        {
            manager.BarkedAt = false;
            manager.SwitchState(manager.wanderState);
        }
    }


}
