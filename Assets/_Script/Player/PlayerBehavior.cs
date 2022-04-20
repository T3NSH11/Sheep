using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float Speed = 5f;
    public PathMaker pathMaker;
    Rigidbody rb;
    List<Transform>path{get{return pathMaker.Waypoints;}}

    public bool goToLevel2 = false;

    int currentWaypoints = 0;

    const float distanceToChangeWaypoints = 5;
    GameObject visualCue;

     void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() 
    {
        if(goToLevel2 == true)
        {
            Steer();
            Move();
            CheckWaypoint();
            GetComponent<ClickToMove>().enabled = false;
            GetComponent<ClickToMove>().targetPosition = transform.position;
        }
        else
        {
            GetComponent<ClickToMove>().enabled = true;
        }
    }

    void Move()
    {
        rb.MovePosition(rb.position + (transform.forward * Speed * Time.deltaTime));
    }
    void Steer(){
        Vector3 targetDirection = path[currentWaypoints].position - rb.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Time.fixedDeltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void CheckWaypoint()
    {
        if(Vector3.Distance(rb.position, path[currentWaypoints].position)<distanceToChangeWaypoints)
        {
            currentWaypoints++;
            if(currentWaypoints == path.Count)
            {
                goToLevel2 = false;
            }
        }
    }
}
