using UnityEngine;
using System.Collections;

public abstract class NeedViewElement : MonoBehaviour
{

    /// <summary>
    /// Updates UI according to satisfaction level
    /// </summary>
    /// <param name="satisfactionLevel"></param>
    public abstract void UpdateSatisfaction(SatisfactionLevel satisfactionLevel);
}
