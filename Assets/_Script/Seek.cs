using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float seekStrength;
    private Rigidbody rb;
    public float arrivalRadius;
    public float gravity = 30f;


    public float AvoidSpeed = 300;
    Sensor sensor;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.velocity = new Vector3(speed, 0, speed);

        sensor = GetComponent<Sensor>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float avoid = sensor.Check();
        if (avoid == 0)
        {
            StandardSteer();
        }
        else
        {
            AvoidSteer(avoid);
        }

        //Debug.Log(avoid);
    }

    public void AvoidSteer(float avoid)
    {
        transform.RotateAround(transform.position, transform.up, AvoidSpeed * Time.fixedDeltaTime * avoid ); 
    }

    void StandardSteer()
    {
        float avoid = sensor.Check();
        if (target != null)
        {
            Vector3 desiredVelocity = (target.transform.position - transform.position).normalized * speed;
            desiredVelocity.y = 0;

            Vector3 currentVelocity = rb.velocity;

            Vector3 seekForce = (desiredVelocity - currentVelocity).normalized * seekStrength;
            Vector3 newVelocity = (currentVelocity + seekForce).normalized * speed;
            rb.velocity = newVelocity;

            transform.rotation = Quaternion.LookRotation(desiredVelocity);

            if (arrivalRadius > 0)
            {
                float distance = Vector3.Distance(target.transform.position, transform.position);

                desiredVelocity.y -= gravity * Time.deltaTime;

                if (distance < arrivalRadius)
                {
                    float multiplier = distance / arrivalRadius;
                    rb.velocity = rb.velocity.normalized * multiplier;
                }

                if (distance < 3)
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }
}
