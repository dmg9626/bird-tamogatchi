using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdStatus : MonoBehaviour
{
    

    [SerializeField]
    public Need hunger;

    [SerializeField]
    public Need fun;

    [SerializeField]
    public Need love;

    private SatisfactionLevel satisfactionLevel;

    void Start()
    {
        
    }
}
