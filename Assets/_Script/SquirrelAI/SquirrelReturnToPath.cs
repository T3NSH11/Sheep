using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelReturnToPath : SquirrelBaseState
{
    
    
    public override void EnterState(SquirrelManager squirrel)
    {


    }

    public override void UpdateState(SquirrelManager squirrel)
    {
        if (Vector3.Distance(squirrel.transform.position, squirrel.ReturnLocation) > 1)
        {
            Vector3 desiredVelocity = (squirrel.ReturnLocation - squirrel.transform.position) * squirrel.returnSpeed;
            squirrel.gameObject.GetComponent<Rigidbody>().velocity += desiredVelocity;
            // :D ^_^ :P :O XD
        }
        else
        {
            squirrel.switchState(new SquirrelFollowPath());
        }
    }

    public override void OncollisionEnter(SquirrelManager squirrel)
    {

    }
}
