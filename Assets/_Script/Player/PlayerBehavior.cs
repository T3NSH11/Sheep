using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float Speed = 5f;
    public PathMaker pathMaker;

    Rigidbody rb;
    List<Transform> currentPath { get { return pathMaker.Waypoints; } }

    public bool goToLevel = false;

    int currentWaypoints = 0;
    public Quest QuestSystem;

    public PathMaker Level2;
    public PathMaker Level3;
    public PathMaker Level4;
    const float distanceToChangeWaypoints = 5;
    GameObject visualCue;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        CheckLevel();
        if (goToLevel == true)
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
    void Steer()
    {
        Vector3 targetDirection = currentPath[currentWaypoints].position - rb.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, Time.fixedDeltaTime, 0);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    void CheckWaypoint()
    {
        if (Vector3.Distance(rb.position, currentPath[currentWaypoints].position) < distanceToChangeWaypoints)
        {
            currentWaypoints++;
            if (currentWaypoints == currentPath.Count)
            {
                goToLevel = false;
            }
        }
    }
    void CheckLevel()
    {
        if (QuestSystem.GetComponent<Quest>().CurrentLevel == 1)
        {
            pathMaker = Level2;
        }
        if (QuestSystem.GetComponent<Quest>().CurrentLevel == 2)
        {
            pathMaker = Level3;
        }
        if (QuestSystem.GetComponent<Quest>().CurrentLevel == 3)
        {
            pathMaker = Level4;
        }
    }
}
