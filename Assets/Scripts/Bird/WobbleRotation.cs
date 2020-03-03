using UnityEngine;
using System.Collections;

/// <summary>
/// Rotates transform back/forth along z-axis, according to parameters
/// </summary>
public class WobbleRotation : MonoBehaviour
{
    [Header("Wobble Settings")]
    /// <summary>
    /// Speed of wobble animation
    /// </summary>
    [SerializeField]
    private float wobbleSpeed = .5f;

    /// <summary>
    /// How far the egg wobbles left/right (in degrees)
    /// </summary>
    [SerializeField]
    private float wobbleAngle = 30f;

    /// <summary>
    /// Minimum number of wobbles to perform during a Wobble() coroutine
    /// </summary>
    [SerializeField]
    private int minWobbles = 1;

    /// <summary>
    /// Max number of wobbles to perform during a Wobble() coroutine
    /// </summary>
    [SerializeField]
    private int maxWobbles = 2;

    [SerializeField]
    private Vector2 wobbleDelayRange;

    // Update is called once per frame
    void Update()
    {
        if(wobbleCoroutine == null)
        {
            // Wobble a random number of times
            int numWobbles = Random.Range(minWobbles, maxWobbles+1);
            wobbleCoroutine = StartCoroutine(Wobble(numWobbles));
        }
    }

    private Coroutine wobbleCoroutine;
    private IEnumerator Wobble(int numberOfWobbles)
    {
        float t = 0;
        while(t < numberOfWobbles * 2) {
            // Pingpong between -.5 and .5 (starting at 0)
            float pingpong = Mathf.PingPong(t - .5f, 1) - .5f;

            // Calculate angle corresponding to pingpong value
            float angle = pingpong * wobbleAngle;
            transform.eulerAngles = new Vector3(0, 0, angle);

            t += Time.deltaTime * wobbleSpeed;
            yield return null;
        }
        // Make sure we stop exactly at 0 degrees
        transform.eulerAngles = Vector3.zero;

        // Wait a random number of seconds before allowing to wobble again
        float delay = Random.Range(wobbleDelayRange.x, wobbleDelayRange.y);

        yield return new WaitForSeconds(delay);
        wobbleCoroutine = null;
    }
}
