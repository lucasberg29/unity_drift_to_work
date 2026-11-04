using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FakeAnimation : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("FinishedFaking", true);
        animator.SetBool("FakeStart", false);

        Rigidbody rbPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
   
        //rbPlayer.constraints = RigidbodyConstraints.None;
        //rbPlayer.freezeRotation = true;
        //rbPlayer.constraints = RigidbodyConstraints.FreezeAll;

        //rbPlayer.constraints = RigidbodyConstraints.FreezePositionY;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
