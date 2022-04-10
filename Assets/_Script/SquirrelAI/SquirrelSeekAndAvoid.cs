using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSeekAndAvoid : SquirrelBaseState
{
    public float speed = 10;
    public float stoppingDistance = 5;
    public float scurryDistance = 4;

    private float coolDownTimer = 5;
    private GameObject sheep;
   


    public override void EnterState(SquirrelManager squirrel)
    {
        sheep = squirrel.NearbySheep[0].gameObject;

    }

    public override void UpdateState(SquirrelManager squirrel)
    {

        if (sheep != null && Vector3.Distance(squirrel.transform.position, sheep.transform.position) > stoppingDistance) //will move closer to the target
        {

            squirrel.transform.position = Vector3.MoveTowards(squirrel.transform.position, sheep.transform.position, speed * Time.deltaTime);

        }
        else if (sheep != null && Vector3.Distance(squirrel.transform.position, sheep.transform.position) > stoppingDistance && Vector3.Distance(squirrel.transform.position, sheep.transform.position) > scurryDistance) //if near enough the stop distance it will stop moving
        {

            squirrel.transform.position = squirrel.transform.position; //resseting squirrel pos to make it stop moving at a certain distance 
        }
        else if (sheep != null && Vector3.Distance(squirrel.transform.position, sheep.transform.position) < scurryDistance) //back away
        {

            squirrel.transform.position = Vector3.MoveTowards(squirrel.transform.position, sheep.transform.position, -speed * Time.deltaTime); //makes squirrel back away if too close

        }


        if (coolDownTimer <= 0 && GameObject.FindGameObjectWithTag("Acorn") == null)
        {
            squirrel.instantiateAcorn();
            coolDownTimer = 5;
            squirrel.switchState(new SquirrelReturnToPath());

        }
        else
        {
            coolDownTimer -= Time.deltaTime;
        }

    }

    public override void OncollisionEnter(SquirrelManager squirrel)
    {
       

    }

}
