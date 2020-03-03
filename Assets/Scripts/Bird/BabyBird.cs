using UnityEngine;
using System.Collections;

public class BabyBird : Bird
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(EvolveWhenLoveMax());
    }

    // Update is called once per frame
    void Update()
    {
        
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
