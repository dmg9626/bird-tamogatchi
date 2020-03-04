using UnityEngine;
using System.Collections;

public class FeedAction : AnimationAction
{
    [SerializeField]
    protected SpriteRenderer foodItem;

    [SerializeField]
    protected float foodVisibleDuration = 1.25f;
    
    /// <summary>
    /// Food starts from here
    /// </summary>
    [SerializeField]
    protected Transform start;
    
    /// <summary>
    /// Food moved towards here (should be at bird's mouth)
    /// </summary>
    [SerializeField]
    protected Transform end;

    protected override void Awake()
    {
        type = Type.FEED;
        animationTrigger = "Feed";
        duration = 2f;

        base.Awake();
    }

    protected override IEnumerator ActionCoroutine()
    {
        Debug.LogFormat("performing {0} action", type);

        // Animate bird eating and show food
        Animate();
        foodItem.enabled = true;

        // Move food towards bird's mouth
        float t = 0;
        while(t < duration) {
            Vector3 position = Vector3.Lerp(start.position, end.position, t);
            foodItem.transform.position = position;

            // Hide after visible duration elapsed
            if (t >= foodVisibleDuration)
                foodItem.enabled = false;

            t += Time.deltaTime / duration;
            yield return null;
        }

        // Hide food and mark coroutine as finished
        foodItem.enabled = false;
        state = State.FINISHED;
    }
}
