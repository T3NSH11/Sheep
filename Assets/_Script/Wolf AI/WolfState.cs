using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WolfState
{

    public abstract void EnterState(WolfManager manager);
    public abstract void UpdateState(WolfManager manager);
    //public abstract void OnCollisionEnter(SheepManager manager);

}
