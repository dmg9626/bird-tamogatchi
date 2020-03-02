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
        // Calculate love level (avg. of other 2 stats)
        level = (fun.level + hunger.level) / 2f;

        // Update sprite accordingly
        viewElement.UpdateSprite(satisfactionLevel);
    }
}
