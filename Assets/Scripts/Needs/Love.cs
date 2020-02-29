using UnityEngine;
using System.Collections;

public class Love : Need
{
    [SerializeField]
    protected Need hunger;

    [SerializeField]
    protected Need fun;

    // Use this for initialization
    protected override void Start()
    {
        decreaseOverTime = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        level = (fun.level + hunger.level) / 2f;
    }
}
