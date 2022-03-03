using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndFlee : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float seekStrength;
    public bool isFlee;
    private Rigidbody rb;

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, target.transform.position);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody> ();
        rb.velocity = new Vector3(speed, 0, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredVelocity = (target.transform.position - transform.position).normalized * speed;
            if(isFlee)
            {
                desiredVelocity *= -1;
                transform.rotation = Quaternion.LookRotation(transform.position - target.position);
            }
            Vector3 currentVelocity = rb.velocity;

            Vector3 seekForce = (desiredVelocity - currentVelocity).normalized * seekStrength;
            Vector3 newVelocity = (currentVelocity + seekForce).normalized * speed;
            rb.velocity = newVelocity;

        }
    }
}
