using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimRandomizer : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("idleindex", Random.Range(0, 2));
    }
}
