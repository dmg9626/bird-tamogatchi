using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bird : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    public Need hunger;

    [SerializeField]
    public Need fun;

    [SerializeField]
    public Need love;
    
    [SerializeField]
    private Sprite unhappySprite;
    
    [SerializeField]
    private Sprite neutralSprite;
    
    [SerializeField]
    private Sprite happySprite;
    
    [SerializeField]
    private Sprite maxHappySprite;

    private Dictionary<SatisfactionLevel, Sprite> satisfactionSpriteDict;

    private SatisfactionLevel satisfactionLevel;

    void Start()
    {
        satisfactionSpriteDict = new Dictionary<SatisfactionLevel, Sprite> {
            { SatisfactionLevel.LOW, unhappySprite },
            { SatisfactionLevel.MEDIUM, neutralSprite },
            { SatisfactionLevel.HIGH, happySprite },
            { SatisfactionLevel.MAX, maxHappySprite },
        };

        if (!TryGetComponent(out spriteRenderer))
            Debug.LogError(name + " | missing SpriteRenderer component");
    }

    void Update()
    {
        if(satisfactionLevel != love.satisfactionLevel) {
            satisfactionLevel = love.satisfactionLevel;
            UpdateSprite();
        }
    }

    void UpdateSprite()
    {
        if(!satisfactionSpriteDict.TryGetValue(satisfactionLevel, out Sprite sprite)) {
            Debug.LogError(name + " | Bird.UpdateSprite() failed to pull sprite from dictionary");
            return;
        }
        spriteRenderer.sprite = sprite;
    }
}
