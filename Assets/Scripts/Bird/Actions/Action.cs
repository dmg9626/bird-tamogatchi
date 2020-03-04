using UnityEngine;
using System.Collections;

public abstract class Action : MonoBehaviour
{
    public enum Type
    {
        HOP = 0,
        CHIRP = 1,
        STEPPY = 2
    }
    public Type type { get; protected set; }

    public enum State { FINISHED, IN_PROGRESS }
    
    public State state { get; protected set; }

    public void Execute()
    {
        state = State.IN_PROGRESS;
        StartCoroutine(ActionCoroutine());
    }

    protected abstract IEnumerator ActionCoroutine();
}
