using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SheepState
{

    public abstract void EnterState(SheepManager manager);
    public abstract void UpdateState(SheepManager manager);
    //public abstract void FixedUpdateState(SheepManager manager);
    //public abstract void OnCollisionEnter(SheepManager manager);

}
