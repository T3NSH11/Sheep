using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SquirrelBaseState 
{
    public abstract void EnterState(SquirrelManager squirrel);

    public abstract void UpdateState(SquirrelManager squirrel);

    public abstract void OncollisionEnter(SquirrelManager squirrel);
}
