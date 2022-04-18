using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfManager : MonoBehaviour
{
    WolfState currentState;
    public Rigidbody rb;
    public GameObject player;
    public Transform AI;
    public LayerMask SheepMask;
    public float speed;
    public float AttackRadius;
    public float StalkSpeed;
    public float RotationSpeed;
    public Collider[] NearbySheep;
    public Collider TargetSheep;

    #region ReturnToPath
    FollowPath _followpath;
    Vector3 SavedPos;
    #endregion


    void Start()
    {
        currentState = new FollowPath();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = gameObject.GetComponent<Rigidbody>();
        currentState.EnterState(this);
    }
    void Update()
    {
        NearbySheep = Physics.OverlapSphere(transform.position, AttackRadius, SheepMask);
        currentState.UpdateState(this);
        Debug.Log(currentState);
    }

    public void SwitchState(WolfState state)
    {
        if (currentState == _followpath)
        {
            SavedPos = transform.position;
        }
        currentState = state;
        state.EnterState(this);
    }
}
