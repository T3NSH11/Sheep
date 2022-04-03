using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
   
    public Camera cam;
    Collider planecollider;
    public Rigidbody rb;

    public GameObject visualCue; //the center of the radius 
    public GameObject slowingRadius; //the radius

    public Collider GroundCollider;

    public float SprintSpeed, speed, WalkSpeed;
    public float SteeringForce;
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
        slowingRadius.gameObject.transform.position = targetPosition;

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


            if (visualCue.transform.position == targetPosition)
            {

                //visualCue.SetActive(false);
            }
        }

        if (Vector3.Distance(targetPosition, transform.position) > 2)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity.normalized, new Vector3(0, 0, 1));
            DesiredVelocity = (targetPosition - transform.position).normalized * speed * Time.deltaTime;
            Steering = DesiredVelocity - rb.velocity;
            Steering = Vector3.ClampMagnitude(Steering, SteeringForce);
            Steering /= rb.mass;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity + Steering, speed);
        }
        else
        {
            visualCue.SetActive(false);
            speed = WalkSpeed;
        }

        //this.gameObject.transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        //bruh


        //DesiredVelocity = targetPosition - transform.position; 

       

















    }

    private void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
    }
}
