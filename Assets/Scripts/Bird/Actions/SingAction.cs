using UnityEngine;
using System.Collections;

public class SingAction : AnimationAction
{
    protected override void Awake()
    {
        type = Type.SING;
        soundType = SoundType.CHIRP;
        animationTrigger = "Sing";
        duration = 2.5f;

        base.Awake();
    }
}
