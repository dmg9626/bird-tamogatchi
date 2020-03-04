using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class ChirpAction : Action
{
    Animator animator;
    private void Awake()
    {
        type = Type.CHIRP;

        if (!TryGetComponent(out animator))
            Debug.LogError("ChirpAction | missing Animator component");
    }

    protected override IEnumerator ActionCoroutine()
    {
        // Trigger chirp animation
        animator.SetTrigger("Chirp");

        // Wait a few seconds before marking coroutine as finished
        yield return new WaitForSeconds(2.5f);
        state = State.FINISHED;
    }
}
