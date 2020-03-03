using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer), typeof(Animator))]
public abstract class Bird : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        if (!TryGetComponent(out spriteRenderer))
            Debug.LogError(name + " | missing SpriteRenderer component");
        if (!TryGetComponent(out animator))
            Debug.LogError(name + " | missing Animator component");
    }
}
