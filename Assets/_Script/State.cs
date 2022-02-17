using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    //this is the base class, (we using abstract cause we not going to use it, but others will inherit from this class.)
    public abstract State RunCurrentState();
}

