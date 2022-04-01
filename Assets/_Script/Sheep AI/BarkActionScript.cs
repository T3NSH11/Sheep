using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarkActionScript : SheepState
{
    public WanderState wanderState;
    public Transform player;
    public Transform AI;
    bool switchState = false;
    float switchTimer = 0;
    public float moveSpeed = 5f;

    public override void EnterState(SheepManager manager)
    {
    }
    public override void UpdateState(SheepManager manager)
    {
        switchTimer++;

        if (manager.barkMove == true)
        {
            manager.gameObject.GetComponent<Rigidbody>().velocity += (manager.triggerpos + manager.gameObject.transform.position).normalized * moveSpeed;
            manager.barkMove=false;
        }
        if (switchState == false)
        {
            if (switchTimer > 3)
            {
                manager.SwitchState(manager.wanderState);
            }

        }
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
}
