using UnityEngine;
using System.Collections;

public class AnimationAction : Action
{
    protected string animationTrigger;

    protected SoundType soundType = SoundType.NONE;

    protected float duration;

    Animator animator;

    protected virtual void Awake()
    {
        if (!TryGetComponent(out animator))
            Debug.LogErrorFormat("{0} Action | missing Animator component", type);
    }

    protected override IEnumerator ActionCoroutine()
    {
        Debug.LogFormat("performing {0} action", type);
        Animate();
        SoundController.Instance.PlaySoundEffect(soundType);

        // Wait a few seconds before marking coroutine as finished
        yield return new WaitForSeconds(duration);
        state = State.FINISHED;
    }

    protected virtual void Animate()
    {
        // Trigger animation and play sound effect
        animator.SetTrigger(animationTrigger);
    }
}
