using UnityEngine;
using System.Collections;

public class WatchTVAction : AnimationAction
{
    private Need fun => BirdStatus.Instance.fun;

    private SpriteRenderer TVSpriteRenderer;

    [SerializeField]
    private float satisfactionBoost = .4f;

    protected override void Awake()
    {
        type = Type.TV;
        animationTrigger = "TV";
        duration = 2f;
        idle = false;

        base.Awake();

        // Get reference to TV
        TVSpriteRenderer = TV.Instance.GetComponent<SpriteRenderer>();
    }

    protected override IEnumerator ActionCoroutine()
    {
        Debug.LogFormat("performing {0} action", type);

        // Call animation and show TV
        Animate();
        TVSpriteRenderer.enabled = true;

        // Increase fun meter halfway through animation
        yield return new WaitForSeconds(duration / 2);
        fun.Increase(satisfactionBoost);
        yield return new WaitForSeconds(duration / 2);

        // Hide TV and mark coroutine as finished
        TVSpriteRenderer.enabled = false;
        state = State.FINISHED;
    }
}
