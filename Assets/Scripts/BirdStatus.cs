using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdStatus : Singleton<BirdStatus>
{
    public Need hunger;

    public Need fun;

    public Need love;

    private SatisfactionLevel satisfactionLevel;

    void Start()
    {
        
    }
}
