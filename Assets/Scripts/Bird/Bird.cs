using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public abstract class Bird : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;

    protected Animator animator;

    /// <summary>
    /// Reference to next phase of this bird's life (ex. Egg -> Baby, Baby -> Adult)
    /// </summary>
    [SerializeField]
    protected Bird nextPhase;

    protected BirdStatus birdStatus;

    /// <summary>
    /// Actions that can be performed by this bird
    /// </summary>
    protected Action[] actions;

    protected Coroutine actionCoroutine;

    // Use this for initialization
    void Awake()
    {
        // Check for components
        if (!TryGetComponent(out spriteRenderer))
            Debug.LogError(name + " | missing SpriteRenderer component");
        if (!TryGetComponent(out animator))
            Debug.LogError(name + " | missing Animator component");

        // Get all actions
        actions = GetComponents<Action>();

        // Set reference to bird status
        birdStatus = BirdStatus.Instance;
    }

    public bool Evolve()
    {
        // Return false if there's no phase to evolve to
        if (!nextPhase) {
            Debug.LogFormat("{0} | Bird.Evolve() - no Bird specified in nextPhase, cannot evolve", name);
            return false;
        }

        // Instantiate the next bird and destroy this one
        Bird next = Instantiate(nextPhase, transform.position, Quaternion.Euler(Vector3.zero));
        Destroy(gameObject);
        return true;
    }

    protected bool IsPerformingAction()
    {
        foreach(Action action in actions)
        {
            if (action.state == Action.State.IN_PROGRESS)
                return true;
        }
        return false;
    }

    protected Action GetActionByType(Action.Type type)
    {
        // If an action coroutine is in progress, return true
        foreach (Action action in actions)
        {
            if (action.type == type)
                return action;
        }
        return null;
    }
}
