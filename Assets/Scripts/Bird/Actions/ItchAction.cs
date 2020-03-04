using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItchAction : Action
{
    Animator animator;
    private void Awake()
    {
        type = Type.ITCH;

        if (!TryGetComponent(out animator))
            Debug.LogError("ItchAction | missing Animator component");
    }

    protected override IEnumerator ActionCoroutine()
    {
        // Trigger steppy animation
        animator.SetTrigger("Itch");

        // Wait a few seconds before marking coroutine as finished
        yield return new WaitForSeconds(2f);
        state = State.FINISHED;
    }
}
