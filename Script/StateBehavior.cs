using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBehavior : StateMachineBehaviour
{
    public FighterState behaviorState;
    public AudioClip soundEffect;
    public float horizontalForce;
    public float verticalForce;
    protected Fighter fighter;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (fighter==null)
        {
            fighter = animator.GetComponent<Fighter>();
        }
        fighter.currentState = behaviorState;
        if (soundEffect != null)
        {
            fighter.playsound(soundEffect);
        }
        fighter.mybody.AddRelativeForce(new Vector3(0,verticalForce,0));
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fighter.mybody.AddRelativeForce(new Vector3(0, 0, horizontalForce));
    }
}
