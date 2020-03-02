using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Bird : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start()
    {
        if (!TryGetComponent(out spriteRenderer))
            Debug.LogError(name + " | missing SpriteRenderer component");
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}
