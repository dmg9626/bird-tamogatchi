using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SteppyAction : AnimationAction
{
    protected override void Awake()
    {
        type = Type.STEPPY;
        animationTrigger = "Steppy";
        duration = 2f;

        base.Awake();
    }
}
