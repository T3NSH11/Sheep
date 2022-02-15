using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    enum State
    {
        State1,
        State2,
        State3
    }
    State currentState = State.State1;

}
