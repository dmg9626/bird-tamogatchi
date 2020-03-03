using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoveViewElement : NeedViewElement
{
    /// <summary>
    /// Indicates level of satisfaction
    /// </summary>
    private Image image;

    [Header("Sprites")]
    [SerializeField]
    private Sprite unhappySprite;
    
    [SerializeField]
    private Sprite neutralSprite;

    [SerializeField]
    private Sprite happySprite;
    
    [SerializeField]
    private Sprite veryHappySprite;

    /// <summary>
    /// Links satisfaction level to number of icons
    /// </summary>
    private Dictionary<SatisfactionLevel, Sprite> satisfactionSpriteDict;

    private SatisfactionLevel satisfactionLevel;

    // Use this for initialization
    void Start()
    {
        satisfactionSpriteDict = new Dictionary<SatisfactionLevel, Sprite> {
            { SatisfactionLevel.LOW, unhappySprite },
            { SatisfactionLevel.MEDIUM, neutralSprite },
            { SatisfactionLevel.HIGH, happySprite },
            { SatisfactionLevel.MAX, veryHappySprite },
        };

        if(!TryGetComponent(out image))
            Debug.LogError(name + " | missing Image component");
    }

    public override void UpdateSatisfaction(SatisfactionLevel satisfactionLevel)
    {
        if(!satisfactionSpriteDict.TryGetValue(satisfactionLevel, out Sprite sprite)) {
            Debug.LogErrorFormat(name + " | failed to pull {0} sprite from dictionary", satisfactionLevel);
            return;
        }
        if (satisfactionLevel == this.satisfactionLevel)
            return;

        // Set sprite accordingly
        image.sprite = sprite;
    }
}
