using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelSeekAndAvoid : SquirrelBaseState
{
    
    public float stoppingDistance = 5;
    public float scurryDistance = 4;

    private float coolDownTimer = 5;
    



    public override void EnterState(SquirrelManager squirrel)
    {
        squirrel.targetSheep = squirrel.NearbySheep[0].gameObject;
        squirrel.ReturnLocation = squirrel.transform.position; 
    }

    public override void UpdateState(SquirrelManager squirrel)
    {

        if (squirrel.targetSheep != null && Vector3.Distance(squirrel.transform.position, squirrel.targetSheep.transform.position) > stoppingDistance) //will move closer to the target
        {

            squirrel.transform.position = Vector3.MoveTowards(squirrel.transform.position, squirrel.targetSheep.transform.position, squirrel.speed * Time.deltaTime);

        }
        else if (squirrel.targetSheep != null && Vector3.Distance(squirrel.transform.position, squirrel.targetSheep.transform.position) > stoppingDistance && Vector3.Distance(squirrel.transform.position, squirrel.targetSheep.transform.position) > scurryDistance) //if near enough the stop distance it will stop moving
        {

            squirrel.transform.position = squirrel.transform.position; //resseting squirrel pos to make it stop moving at a certain distance 
        }
        else if (squirrel.targetSheep != null && Vector3.Distance(squirrel.transform.position, squirrel.targetSheep.transform.position) < scurryDistance) //back away
        {

            squirrel.transform.position = Vector3.MoveTowards(squirrel.transform.position, squirrel.targetSheep.transform.position, -squirrel.speed * Time.deltaTime); //makes squirrel back away if too close

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
