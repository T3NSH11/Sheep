using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    SheepState currentState;
    wanderState wanderState = new wanderState();
    public float speed = 2f;
    public float wanderStrength;                // basically the radius
    public float wanderAngleDisplacement;       //going to be the thing that changes time to time
    public bool isWandering;
    public Transform AI;

    public Rigidbody rb;
    public float wanderAngle;
    public bool isDone = false;
    public Transform player;

    void Start()
    {
        float initalAngle = Random.Range(0.0f, Mathf.PI * 2);
        rb.velocity = new Vector3(Mathf.Cos(initalAngle) * speed, 0, Mathf.Sin(initalAngle) * speed);      // we use PI * 2 because we are dealing with cos, sin, we are dealing with angles in the radiant format, not in the degree format.
        currentState = new wanderState();
        rb = AI.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        // float dist = Vector3.Distance(player.position, AI.position);
        currentState.SheepUpdate(this);
        Debug.Log(currentState);
    }

    public void SwitchState(SheepState nextState)
    {
        currentState = nextState;
    }
}
