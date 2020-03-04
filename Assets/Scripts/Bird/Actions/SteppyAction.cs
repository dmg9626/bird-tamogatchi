using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class SteppyAction : Action
{
    Animator animator;
    private void Awake()
    {
        type = Type.STEPPY;

        if (!TryGetComponent(out animator))
            Debug.LogError("SteppyAction | missing Animator component");
    }

    protected override IEnumerator ActionCoroutine()
    {
        Debug.Log("performing Steppy action");

        // Trigger steppy animation
        animator.SetTrigger("Steppy");
        
        // Wait a few seconds before marking coroutine as finished
        yield return new WaitForSeconds(2f);
        state = State.FINISHED;
    }
}
