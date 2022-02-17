using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderState : SheepState
{
    public override void SheepUpdate(SheepManager manager)
    {

        manager.wanderAngle += Random.Range(-manager.wanderAngleDisplacement, manager.wanderAngleDisplacement);

        Vector3 displacementForce = new Vector3(Mathf.Cos(manager.wanderAngle) * manager.wanderStrength, 0, Mathf.Sin(manager.wanderAngle) * manager.wanderStrength);

        Vector3 newVelocity = (manager.rb.velocity + displacementForce).normalized * manager.speed;
        manager.rb.velocity = newVelocity;

        if (manager.player)
        {
            float dist = Vector3.Distance(manager.player.position, manager.AI.position);
            Debug.Log("Distance is : " + dist);
            if (dist < 20)
            {
                Debug.Log("i should be switching states now");
                manager.SwitchState(new FleeState());
            }
        }
    }
}
