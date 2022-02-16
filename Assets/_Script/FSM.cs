using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    enum State
    {
        Idle,
        Wander,
        State3
    }
    State currentState = State.Idle;

    

}
