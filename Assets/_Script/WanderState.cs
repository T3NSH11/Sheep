using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : State
{
    public float speed = 2f;
    public float wanderStrength;      // basically the radius
    public float wanderAngleDisplacement;       //going to be the thing that changes time to time
    public bool isWandering;

    public Transform AI;

    Rigidbody rb;
    private float wanderAngle;
    public IdleState idleState;
    bool isDone = false;


    public override State RunCurrentState()
    {
        if (isWandering)
        {
            return idleState;
        }
        else
        {
            StartWander();
            return this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = AI.gameObject.GetComponent<Rigidbody>();
      //  float initalAngle = Random.Range(0.0f, Mathf.PI * 2); // we use PI * 2 because we are dealing with cos, sin, we are dealing with angles in the radiant format, not in the degree format.
       // rb.velocity = new Vector3(Mathf.Cos(initalAngle) * speed, 0, Mathf.Sin(initalAngle) * speed);
    }

    // Update is called once per frame
    void Update()
    {
        //StartWander();
    }

    void StartWander()
    {
        if (!isDone)
        {
            float initalAngle = Random.Range(0.0f, Mathf.PI * 2);
            rb.velocity = new Vector3(Mathf.Cos(initalAngle) * speed, 0, Mathf.Sin(initalAngle) * speed);      // we use PI * 2 because we are dealing with cos, sin, we are dealing with angles in the radiant format, not in the degree format.
            isDone = true;
        }

        wanderAngle += Random.Range(-wanderAngleDisplacement, wanderAngleDisplacement);

        Vector3 displacementForce = new Vector3(Mathf.Cos(wanderAngle) * wanderStrength, 0, Mathf.Sin(wanderAngle) * wanderStrength);

        Vector3 newVelocity = (rb.velocity + displacementForce).normalized * speed;
        rb.velocity = newVelocity;
    }

    /*  void OnDrawGizmos() 
      {
          Gizmos.color = Color.yellow;
          Gizmos.DrawSphere(transform.position, wanderStrength);
      }*/
}
