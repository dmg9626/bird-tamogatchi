using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class ChirpAction : AnimationAction
{
    protected override void Awake()
    {
        type = Type.CHIRP;
        soundType = SoundType.CHIRP;
        animationTrigger = "Chirp";
        duration = 2.5f;

        base.Awake();
    }
}
