using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItchAction : AnimationAction
{
    protected override void Awake()
    {
        type = Type.ITCH;
        animationTrigger = "Itch";
        duration = 2.5f;

        base.Awake();
    }
}
