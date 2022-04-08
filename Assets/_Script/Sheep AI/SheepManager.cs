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
    public Vector3 velocity;
    public GameObject player;
    public Rigidbody AiRb;
    public LayerMask SheepMask;
    public float FlockRadius = 10f;
    public GameObject Wolf;
    float ypos;

    #region Bark Action
    ParticleSystem m_ParticleSystem;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    Vector3 AiPos;
    float MoveSpeed = 5;
    public bool barkMove;
    public bool BarkedAt;
    // public Vector3 triggerPos;
    public int PushForce;
    #endregion

    #region Scared
    public int BarkNum;
    //public float ScareTimer;
    #endregion

    [Header("Wander and Obstacle Avoidance")]

    public float MaxVelocity = 5.0f;
    public float MaxForce = 15.0f;
    public bool UseAvoidance;
    public float[] avoidanceAngles;
    public float maxAhead = 5.0f;
    public LayerMask layersToAvoid;
    public float AvoidForce = 10.0f;

    /*
        private float wanderAngle = 10;
        public float circleDis = 10;
        public float circleRadius = 10;
        public float angleRate = 10; //change rate

        */
    void Start()
    {
        #region Wander State
        wanderState.wanderAngle = 10f;
        wanderState.circleDis = 0.60f;
        wanderState.angleRate = 3f;
        #endregion

        AI = transform;
        player = GameObject.FindGameObjectWithTag("Player");
        AiRb = this.gameObject.GetComponent<Rigidbody>();
        Wolf = GameObject.FindGameObjectWithTag("Wolf");
        ypos = transform.position.y;

        PrimaryState = wanderState;
        PrimaryState = new wanderState();
        SecondaryState = new IdleSheepState();

        PrimaryState.EnterState(this);
        SecondaryState.EnterState(this);
    }
    void Update()
    {
        PrimaryState.UpdateState(this);
        // transform.position = new Vector3(transform.position.x, ypos, transform.position.z);
        // transform.localRotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
        if (SecondaryState != null)
        {
            SecondaryState.UpdateState(this);
        }

        if (gameObject.layer == LayerMask.NameToLayer("Sheep"))
        {
            Flock();
        }
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
        Collider FollowingSheep;
        //Choosing what sheep to follow
        Collider[] NearbySheep = Physics.OverlapSphere(transform.position, FlockRadius, SheepMask);
        Debug.Log(NearbySheep.Length);
        //Debug.Log(NearbySheep.Length);
        int random = Random.Range(0, NearbySheep.Length);

        if (NearbySheep.Length != 0)
        {
            FollowingSheep = NearbySheep[random];
            Vector3 DirectionToSheep = FollowingSheep.transform.position - AI.position;

            //Following sheep
            AiRb.AddForce(DirectionToSheep.normalized * 0.2f);
        }

    }
    public Vector3 Seek(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = targetPosition - AiRb.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;
        Vector3 steeringForce = desiredVelocity - velocity;

        Debug.DrawRay(AiRb.transform.position, desiredVelocity.normalized * 5.0f, Color.red);

        return steeringForce;
    }
    public Vector3 CollisionAvoid(float angle)
    {
        Vector3 dir = Quaternion.AngleAxis(angle, transform.up) * transform.forward; //direction

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, maxAhead, layersToAvoid))
        {
            Debug.DrawLine(transform.position, hit.point, Color.blue);
            return hit.normal * (((1f - hit.distance) / maxAhead) * AvoidForce);
           // float force = 1.0f - (hit.distance / maxAhead) * AvoidForce;
           // Vector3 directionForce = Vector3.Reflect(dir, hit.normal) * -1 * force;
           // directionForce.y = 0.0f;
           // return directionForce;
        }
        Debug.DrawLine(transform.position, transform.position + dir * maxAhead, Color.yellow);

        return Vector3.zero;
    }
    public void ApplyForce(Vector3 steeringForce)
    {
        if (UseAvoidance)
            for (int i = 0; i < avoidanceAngles.Length; i++)
            {
                steeringForce += CollisionAvoid(avoidanceAngles[i]);
            }
        steeringForce = Vector3.ClampMagnitude(steeringForce, MaxForce);
        steeringForce /= AiRb.mass;

        velocity = Vector3.ClampMagnitude(velocity + steeringForce, MaxVelocity);

       // AiRb.MovePosition(AiRb.transform.position + velocity * Time.deltaTime);
        AiRb.velocity += velocity * Time.deltaTime;
        //Vector3.ClampMagnitude(AiRb.velocity, MaxVelocity);

        if (velocity.magnitude != 0)
        {
            AiRb.MoveRotation(Quaternion.LookRotation(AiRb.velocity.normalized));
        }
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