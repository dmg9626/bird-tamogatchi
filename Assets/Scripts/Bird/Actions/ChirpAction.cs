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
        Debug.Log("performing Chirp action");

        // Trigger chirp animation and play sound effect
        animator.SetTrigger("Chirp");
        SoundController.Instance.PlaySoundEffect(SoundType.CHIRP);

        // Wait a few seconds before marking coroutine as finished
        yield return new WaitForSeconds(2.5f);
        state = State.FINISHED;
    }
}
