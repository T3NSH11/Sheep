using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wanderState : SheepState
{
    public float speed;
    public float wanderStrength;                // basically the radius
    public float wanderAngleDisplacement;       //going to be the thing that changes time to time
    public bool isWandering;
    public Transform AI;
    Rigidbody rb;
    private float wanderAngle;


    public override void EnterState(SheepManager manager)
    {
        Debug.Log("Wander State Initiated");

        rb = manager.AI.gameObject.GetComponent<Rigidbody>();
        float initalAngle = Random.Range(0.0f, Mathf.PI * 2); // we use PI * 2 because we are dealing with cos, sin, we are dealing with angles in the radian format, not in the degree format.
        rb.velocity = new Vector3(Mathf.Cos(initalAngle) * speed, 0, Mathf.Sin(initalAngle) * speed);
    }
    public override void UpdateState(SheepManager manager)
    {
        Debug.Log("started wandering");
        StartWandering(manager.AI);
    }


    void StartWandering(Transform AI)
    {
        wanderAngle += Random.Range(-wanderAngleDisplacement, wanderAngleDisplacement);

        Vector3 displacementForce = new Vector3(Mathf.Cos(wanderAngle) * wanderStrength, 0, Mathf.Sin(wanderAngle) * wanderStrength);

        Vector3 newVelocity = (rb.velocity + displacementForce).normalized * speed;
        rb.velocity = newVelocity;


        Quaternion desiredRotation = Quaternion.LookRotation(rb.velocity);
        AI.transform.rotation = Quaternion.Slerp(AI.transform.rotation, desiredRotation, Time.deltaTime);
    }
}
