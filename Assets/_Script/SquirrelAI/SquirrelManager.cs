using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelManager : MonoBehaviour
{
    public GameObject targetSheep;
    public float DetectionRadius;
    public LayerMask SheepMask;
    public Collider[] NearbySheep;
    public SquirrelBaseState currentState;
    public SquirrelBaseState SeekAndAvoid = new SquirrelSeekAndAvoid();
    public GameObject AcornBullet;


    private void Start()
    {
        currentState = new SquirrelFollowPath();
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
         NearbySheep = Physics.OverlapSphere(transform.position, DetectionRadius, SheepMask);
    }

    public void switchState(SquirrelBaseState newstate)
    {
        currentState = newstate;
    }

    public void instantiateAcorn()
    {
        Instantiate(AcornBullet, transform.position, Quaternion.identity);

    }


}
