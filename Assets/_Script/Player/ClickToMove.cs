using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{

    public Camera cam;
    Collider planecollider;
    public Rigidbody rb;

    public GameObject visualCue; //the center of the radius 

    public Collider GroundCollider;

    public float SprintSpeed, speed, WalkSpeed, RotationSpeed;
    public float SteeringForce, ArriveSpeed;
    float Clicktimer;
    bool StartTimer;

    Vector3 DesiredVelocity;
    Vector3 targetPosition;
    Vector3 Steering;



    private void Start()
    {
        visualCue.SetActive(false);
        targetPosition = transform.position;
    }

    void Update()
    {
        //transform.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));

        visualCue.gameObject.transform.position = targetPosition;

        if (StartTimer)
        {
            Clicktimer += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && Clicktimer < 1 && Clicktimer > 0)
        {
            speed = SprintSpeed;
            StartTimer = false;
            Clicktimer = 0;
        }

        if (Clicktimer > 1)
        {
            Clicktimer = 0;
            StartTimer = false;
        }


        if (Input.GetMouseButtonDown(0))
        {
            StartTimer = true;
            RaycastHit hit;
            Ray ray;

            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider == GroundCollider)
            {
                visualCue.SetActive(true);
                targetPosition = hit.point;

            }
        }

        if (Vector3.Distance(targetPosition, transform.position) > 1)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity.normalized, new Vector3(0, 0, 1));
            if (Vector3.Distance(targetPosition, transform.position) > 5)
            {
                DesiredVelocity = (targetPosition - transform.position).normalized * speed * ((Vector3.Distance(targetPosition, transform.position) / 5) * Time.deltaTime);
            }
            else
            {
                DesiredVelocity = (targetPosition - transform.position).normalized * speed * Time.deltaTime;
            }

            Steering = DesiredVelocity - rb.velocity; 
            Steering = Vector3.ClampMagnitude(Steering, SteeringForce);
            Steering /= rb.mass;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity + Steering, speed);

        }
        
        if (Vector3.Distance(targetPosition, transform.position) < 1)
        {
            visualCue.SetActive(false);
            speed = WalkSpeed;
        }

        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray;
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider == GroundCollider)
            {
                 Vector3 LookAwayRotation = (hit.point - transform.position);
                 LookAwayRotation.y = 0f;
                 transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(LookAwayRotation), Time.deltaTime * RotationSpeed);
            }

        }
    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
