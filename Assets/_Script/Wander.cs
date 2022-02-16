using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : MonoBehaviour
{
    public float speed = 2f;
    public float wanderStrength;      // basically the radius
    public float wanderAngleDisplacement;       //going to be the thing that changes time to time

    Rigidbody rb;
    private float wanderAngle;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        float initalAngle = Random.Range(0.0f, Mathf.PI * 2); // we use PI * 2 because we are dealing with cos, sin, we are dealing with angles in the radiant format, not in the degree format.
        rb.velocity = new Vector3(Mathf.Cos(initalAngle) * speed,0, Mathf.Sin(initalAngle) * speed);
    }

    // Update is called once per frame
    void Update()
    {
        StartWander();
    }

    void StartWander()
    {
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
