using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkActionScript : SheepState
{
    bool switchState = false;
    float switchTimer = 0;
    Vector3 SheepOffsett;

    public override void EnterState(SheepManager manager)
    {
        switchTimer = 0;
    }
    public override void UpdateState(SheepManager manager)
    {

    }


    /*    public void CheckPlayer(Transform player, Transform AI)
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
        */

    public override void FixedUpdateState(SheepManager manager)
    {
        switchTimer += Time.deltaTime;

        if (manager.barkMove == true)
        {
            //manager.gameObject.GetComponent<Rigidbody>().AddForce(-(manager.triggerPos - manager.transform.position).normalized * moveSpeed, ForceMode.VelocityChange);
            manager.gameObject.GetComponent<Rigidbody>().AddForce(manager.transform.forward * manager.PushForce);
            //manager.gameObject.GetComponent<Rigidbody>().velocity *= moveSpeed;

            //manager.gameObject.GetComponent<Rigidbody>().velocity = manager.gameObject.GetComponent<Rigidbody>().velocity * moveSpeed;
            manager.barkMove = false;
        }
         if (switchState == false)
        {
            if (switchTimer > 3)
            {
                manager.SwitchState(manager.wanderState);
            }

        }
    }
}
