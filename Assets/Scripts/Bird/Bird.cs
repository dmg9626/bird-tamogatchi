﻿using UnityEngine;
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
    /// Actions that can be performed by this bird (both idle and player-triggered)
    /// </summary>
    protected Action[] actions;

    /// <summary>
    /// Action queued up to perform after current one
    /// </summary>
    public Action.Type nextAction { get; set; }

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

    // Update is called once per frame
    void Update()
    {
        // Perform actions at random
        if (actions.Length > 0 && !IsPerformingAction())
        {
            Debug.Log("Performing action...");

            // Perform queued up action if there's one present
            Action action;
            if (nextAction != Action.Type.NONE) {
                action = GetActionByType(nextAction);
                nextAction = Action.Type.NONE;
            }
            // or just select a random idle action
            else
                action = SelectIdleAction();

            // Check that we found an action with the specified type before executing
            if(action)
                action.Execute();
        }
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
    
    private Action SelectIdleAction()
    {
        if (actions.Length == 0)
            return null;

        // Keep fishing until we find an idle action
        Action action = null;
        int numTries = 0;
        while(action == null || !action.idle)
        {
            int actionIndex = Random.Range(0, actions.Length);
            action = actions[actionIndex];
            
            // If we can't find one after 7 tries, just return null
            numTries++;
            if (numTries > 7)
                return null;
        }
        return action;
    }

    /// <summary>
    /// Returns true if bird currently performing action, false otherwise
    /// </summary>
    protected bool IsPerformingAction()
    {
        foreach(Action action in actions)
        {
            if (action.state == Action.State.IN_PROGRESS)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Returns action with associated type, or null if none found
    /// </summary>
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
