using UnityEngine;
using System.Collections;

[RequireComponent(typeof(WobbleRotation))]
public class Egg : Bird
{
    /// <summary>
    /// Used for wobble animation
    /// </summary>
    private WobbleRotation wobble;

    [SerializeField]
    private float hatchDelay = 2.5f;
    
    // Use this for initialization
    void Start()
    {
        if(!TryGetComponent(out wobble)) {
            Debug.LogError(name + " | missing WobbleRotation component");
            return;
        }

        StartCoroutine(Hatch());
    }

    private IEnumerator Hatch()
    {
        // Wait a few seconds before starting to hatch
        yield return new WaitForSeconds(hatchDelay);

        // Fire animation trigger to start hatch animation
        animator.SetTrigger("Hatch");
    }
}
