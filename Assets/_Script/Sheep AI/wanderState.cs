using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderState : SheepState
{
    // public float speed = 0.3f;
    // public float wanderStrength = 0.60f;                // basically the radius
    // public float wanderAngleDisplacement = 0.09f;       //going to be the thing that changes time to time
    Rigidbody rb;
    public float wanderAngle = 10;
    public float circleDis = 10;
    public float angleRate = 10; //change rate
    //public SheepManager manager;


    public override void EnterState(SheepManager manager)
    {
        Debug.Log("Wander State Initiated");

        rb = manager.AI.gameObject.GetComponent<Rigidbody>();
        manager.velocity = rb.transform.forward;
        //float initalAngle = Random.Range(0.0f, Mathf.PI * 2); // we use PI * 2 because we are dealing with cos, sin, we are dealing with angles in the radian format, not in the degree format.
        //rb.velocity = new Vector3(Mathf.Cos(initalAngle) * speed, 0, Mathf.Sin(initalAngle) * speed);
    }
    public override void UpdateState(SheepManager manager)
    {
        Debug.Log("started wandering");
        //StartWandering(manager.AI, manager);
        manager.ApplyForce(Wander(manager));

        if (manager.BarkedAt)
        {
            manager.SwitchState(new BarkActionScript());
        }

        if (Vector3.Distance(manager.player.transform.position, manager.transform.position) < 5)
        {
            manager.SwitchState(new SheepBasicAction());
        }
    }

    public Vector3 Wander(SheepManager manager)
    {
        Vector3 circleCenter = manager.transform.position + manager.velocity.normalized * circleDis;

        wanderAngle += Random.Range(-angleRate, angleRate);

        Vector3 displacement = Vector3.forward;
        displacement.x = circleDis * Mathf.Cos(wanderAngle * Mathf.Deg2Rad);
        displacement.z = circleDis * Mathf.Sin(wanderAngle * Mathf.Deg2Rad);

        Vector3 wanderTarget = circleCenter + displacement;

        return manager.Seek(wanderTarget);
    }
    public override void FixedUpdateState(SheepManager manager)
    {

    }
}




// void StartWandering(Transform AI, SheepManager manager)
//  {
/*
wanderAngle += Random.Range(-wanderAngleDisplacement, wanderAngleDisplacement);

Vector3 displacementForce = new Vector3(Mathf.Cos(wanderAngle) * wanderStrength, 0, Mathf.Sin(wanderAngle) * wanderStrength);

Vector3 newVelocity = (rb.velocity + displacementForce).normalized * speed;
rb.velocity += displacementForce.normalized * speed * Time.deltaTime;
Vector3.ClampMagnitude(rb.velocity, speed); // fix with mazen
//newVelocity.y = 0;

Quaternion desiredRotation = Quaternion.LookRotation(new Vector3(rb.velocity.x,0f , rb.velocity.z));
AI.transform.rotation = Quaternion.Slerp(AI.transform.rotation, desiredRotation, Time.deltaTime);
*/
// }