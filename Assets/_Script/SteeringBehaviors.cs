using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviors : MonoBehaviour
{
    #region seek
    public float Mass = 15.0f;
    public float MaxVelocity = 5.0f;
    public float MaxForce = 15.0f;
    public Transform target;
    #endregion

    #region obstacle avoidance
    public bool UseAvoidance;
    public float[] avoidanceAngles;
    public float maxAhead = 5.0f;
    public LayerMask layersToAvoid;
    public float AvoidForce = 10.0f;
    #endregion

    #region Wander
    public float circleDis;
    private float wanderAngle;
    public float angleRate; //change rate
    #endregion

    private Vector3 velocity;
    private Rigidbody rb;

    public SteerMode steerMode = SteerMode.Seek;
    public enum SteerMode { None, Seek, Wander };


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = Mass;
        velocity = rb.transform.forward;
    }

    // Update is called once per frame

    public Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = targetPosition - rb.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;
        Vector3 steeringForce = desiredVelocity - velocity;

        Debug.DrawRay(rb.transform.position, desiredVelocity.normalized * 5.0f, Color.red);

        return steeringForce;
    }

    public Vector3 CollisionAvoid(float angle)
    {
        Vector3 dir = Quaternion.AngleAxis(angle, transform.up) * transform.forward; //direction

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, maxAhead, layersToAvoid))
        {
            float force = 1.0f - (hit.distance / maxAhead) * AvoidForce;
            Vector3 directionForce = Vector3.Reflect(dir, hit.normal) * -1 * force;
            directionForce.y = 0.0f;
            return directionForce;
        }

        Debug.DrawLine(transform.position, transform.position + dir * maxAhead, Color.yellow);

        return Vector3.zero;
    }
    public Vector3 Wander()
    {
        Vector3 circleCenter = transform.position + velocity.normalized * circleDis;

        wanderAngle += Random.Range(-angleRate, angleRate);

        Vector3 displacement = Vector3.forward;
        displacement.x = circleDis * Mathf.Cos(wanderAngle * Mathf.Deg2Rad);
        displacement.z = circleDis * Mathf.Sin(wanderAngle * Mathf.Deg2Rad);

        Vector3 wanderTarget = circleCenter + displacement;

        return Seek(wanderTarget);
    }

    public void ApplyForce(Vector3 steeringForce)
    {
        if (UseAvoidance)
            for (int i = 0; i < avoidanceAngles.Length; i++)
            {
                steeringForce += CollisionAvoid(avoidanceAngles[i]);
            }
        steeringForce = Vector3.ClampMagnitude(steeringForce, MaxForce);
        steeringForce /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steeringForce, MaxVelocity);

        rb.MovePosition(rb.transform.position + velocity * Time.deltaTime);
       // rb.velocity += velocity * Time.deltaTime;

        if (velocity.magnitude != 0)
        {
            rb.MoveRotation(Quaternion.LookRotation(velocity.normalized));
        }
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        switch (steerMode)
        {
            case SteerMode.None:
                break;
            case SteerMode.Seek:
                ApplyForce(Seek(target.position));
                break;
            case SteerMode.Wander:
                ApplyForce(Wander());
                break;
        }
    }
}
