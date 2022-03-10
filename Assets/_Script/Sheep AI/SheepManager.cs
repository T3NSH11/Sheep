using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    SheepState currentState;
    
    public IdleTestScript idleTestScript = new IdleTestScript();

    public wanderState wanderState = new wanderState();

    public JumpTowards jumpTowards = new JumpTowards();

    public Transform AI;

    public Transform player;

    public Rigidbody AiRb;

    public LayerMask SheepMask;

    void Start()
    {
        #region Wander State
        wanderState.wanderAngleDisplacement = 0.09f;
        wanderState.wanderStrength = 0.60f;
        wanderState.speed = 0.7f;
        #endregion



        //starting the state 
        currentState = new IdleTestScript();
        //"this" is a reference to the context (this exact script)
        currentState.EnterState(this);
        
        AI = transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        AiRb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        currentState.UpdateState(this);
        //Flock();
    }

    public void SwitchState(SheepState state)
    {
        currentState = state;
        state.EnterState(this);
    }
/*
    void Flock()
    {
        float FlockRadius = 100000;
        //LayerMask SheepMask = LayerMask.NameToLayer("Sheep");

        //Choosing what sheep to follow
        Collider[] NearbySheep = Physics.OverlapSphere(transform.position, FlockRadius, SheepMask);
        Debug.Log(NearbySheep.Length);
        int random = Random.Range(0, NearbySheep.Length);
        Collider FollowingSheep = NearbySheep[random];

        Vector3 DirectionToSheep = FollowingSheep.transform.position - AI.position;

        //Following sheep
        AiRb.AddForce(DirectionToSheep.normalized * 0.2f);

    } */
}
