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
        Vector3 direction = (squirrel.transform.position - squirrel.player.transform.position).normalized;
        squirrel.rb.velocity = direction * squirrel.speed;
    }

    public override void OncollisionEnter(SquirrelManager squirrel)
    {

    }
}
