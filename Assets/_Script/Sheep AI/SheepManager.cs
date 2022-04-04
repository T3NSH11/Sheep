using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepManager : MonoBehaviour
{
    SheepState PrimaryState;
    SheepState SecondaryState;

    public BarkActionScript barkActionScript = new BarkActionScript();
    public wanderState wanderState = new wanderState();
    public JumpTowards jumpTowards = new JumpTowards();
    public Transform AI;
    public GameObject player;
    public Rigidbody AiRb;
    public LayerMask SheepMask;
    public float FlockRadius = 10f;
    public bool BarkedAt;
    public float movetimer;
    public GameObject Wolf;

    #region Bark Action
    ParticleSystem m_ParticleSystem;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    Vector3 AiPos;
    float MoveSpeed = 5;
    public bool barkMove;
    public Vector3 triggerPos;
    #endregion

    #region Scared
    public int BarkNum;
    public float ScareTimer;
    #endregion

    #region BarkAction
    public int PushForce;
    #endregion

    void Start()
    {
        #region Wander State
        wanderState.wanderAngleDisplacement = 0.09f;
        wanderState.wanderStrength = 0.60f;
        wanderState.speed = 0.7f;
        #endregion

        AI = transform;
        player = GameObject.FindGameObjectWithTag("Player");
        AiRb = this.gameObject.GetComponent<Rigidbody>();
        Wolf = GameObject.FindGameObjectWithTag("Wolf");

        PrimaryState = wanderState;
        SecondaryState = new IdleSheepState();

        PrimaryState.EnterState(this);
        SecondaryState.EnterState(this);
    }
    void Update()
    {
        PrimaryState.UpdateState(this);

        gameObject.transform.position += new Vector3(0, -0.001f, 0);
        if (SecondaryState != null)
        {
            SecondaryState.UpdateState(this);
        }

        if (gameObject.layer == LayerMask.NameToLayer("Sheep"))
        {
            Flock();
        }
        //OnDrawGizmos();

        #region movetimer
        if (movetimer > 0)
        {
            if (BarkedAt == true)
            {
                PrimaryState = barkActionScript;
                movetimer -= Time.deltaTime;

                if (movetimer <= 0)
                {
                    BarkedAt = false;
                }
            }
        }
        #endregion
    }

    public void SwitchState(SheepState state)
    {
        PrimaryState = state;
        state.EnterState(this);
    }

    public void SwitchSecondaryState(SheepState state)
    {
        SecondaryState = state;
        state.EnterState(this);
    }

    void Flock()
    {
        //Choosing what sheep to follow
        Collider[] NearbySheep = Physics.OverlapSphere(transform.position, FlockRadius, SheepMask);
        Debug.Log(NearbySheep.Length);
        int random = Random.Range(0, NearbySheep.Length);
        Collider FollowingSheep = NearbySheep[random];

        Vector3 DirectionToSheep = FollowingSheep.transform.position - AI.position;

        //Following sheep
        AiRb.AddForce(DirectionToSheep.normalized * 0.2f);

    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FlockRadius);
    }
    */

    private void FixedUpdate()
    {
        PrimaryState.FixedUpdateState(this);
        SecondaryState.FixedUpdateState(this);
    }
}
