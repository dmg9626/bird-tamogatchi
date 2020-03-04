using UnityEngine;
using System.Collections;

public class SingAction : Action
{
    Animator animator;
    private void Awake()
    {
        type = Type.SING;

        if (!TryGetComponent(out animator))
            Debug.LogError("SingAction | missing Animator component");
    }

    protected override IEnumerator ActionCoroutine()
    {
        // Trigger animation and play sound effect
        animator.SetTrigger("Sing");
        SoundController.Instance.PlaySoundEffect(SoundType.CHIRP);

        // Wait a few seconds before marking coroutine as finished
        yield return new WaitForSeconds(2f);
        state = State.FINISHED;
    }
}
