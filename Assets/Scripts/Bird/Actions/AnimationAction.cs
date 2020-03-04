using UnityEngine;
using System.Collections;

public class AnimationAction : Action
{
    [SerializeField]
    protected string animationTrigger;

    [SerializeField]
    protected SoundType soundType = SoundType.NONE;

    [SerializeField]
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

        // Trigger animation and play sound effect
        animator.SetTrigger(animationTrigger);
        SoundController.Instance.PlaySoundEffect(soundType);

        // Wait a few seconds before marking coroutine as finished
        yield return new WaitForSeconds(duration);
        state = State.FINISHED;
    }
}
