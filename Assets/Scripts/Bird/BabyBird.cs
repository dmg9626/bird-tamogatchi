using UnityEngine;
using System.Collections;

public class BabyBird : Bird
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(EvolveWhenLoveMax());
    }

    private IEnumerator EvolveWhenLoveMax()
    {
        // Wait until love is maxed out
        while (birdStatus.love.satisfactionLevel != SatisfactionLevel.MAX)
            yield return null;

        Debug.Log("Love maxed out, evolving into " + nextPhase);
        Evolve();
    }
}
