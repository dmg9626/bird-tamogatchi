using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour
{
    public enum Type
    {
        HOP = 0,
        CHIRP = 1,
        STEPPY = 2,
        ITCH = 3,
        SING = 4,
        FEED = 5
    }

    public Type type { get; protected set; }

    public enum State { FINISHED, IN_PROGRESS }
    
    public State state { get; protected set; }

    /// <summary>
    /// True if this is an action performed while idle (ex. chirping/stepping),
    /// or false if it's triggered by player interaction (ex. feeding/playing)
    /// </summary>
    public bool idle = true;

    public void Execute()
    {
        state = State.IN_PROGRESS;
        StartCoroutine(ActionCoroutine());
    }

    protected abstract IEnumerator ActionCoroutine();
}
