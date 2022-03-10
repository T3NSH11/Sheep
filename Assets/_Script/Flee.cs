using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{
    Rigidbody rb;
    public Transform target;
    public Transform AI; 
    public float speed = 1f;
    public float seekStrength = 1f;
    public float gravity = 30f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        // rb.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var dis = Vector3.Distance (AI.position, target.position);

        //Debug.Log(dis);

        if (dis < 10)
        {
            Vector3 desiredVelocity = (transform.position - target.transform.position).normalized * speed;
            desiredVelocity.y = 0;
            
            Vector3 currentVelocity = rb.velocity;

            Vector3 seekForce = (desiredVelocity - currentVelocity).normalized * seekStrength;
            Vector3 newVelocity = (currentVelocity + seekForce).normalized * speed;
            rb.velocity = newVelocity;

            desiredVelocity.y -= gravity * Time.deltaTime;
            
            transform.LookAt(transform.position - target.position);
        }
        else
        {
            //speed = 0;
            //seekStrength = 0;
        }
    }
}
