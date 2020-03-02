using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NeedViewElement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;


    [SerializeField]
    private Sprite unhappySprite;

    [SerializeField]
    private Sprite neutralSprite;

    [SerializeField]
    private Sprite happySprite;

    [SerializeField]
    private Sprite maxHappySprite;

    private Dictionary<SatisfactionLevel, Sprite> satisfactionSpriteDict;


    // Use this for initialization
    void Start()
    {
        if (!TryGetComponent(out spriteRenderer))
            Debug.LogError(name + " | missing SpriteRenderer component");

        satisfactionSpriteDict = new Dictionary<SatisfactionLevel, Sprite> {
            { SatisfactionLevel.LOW, unhappySprite },
            { SatisfactionLevel.MEDIUM, neutralSprite },
            { SatisfactionLevel.HIGH, happySprite },
            { SatisfactionLevel.MAX, maxHappySprite },
        };
    }

    public void UpdateSprite(SatisfactionLevel satisfactionLevel)
    {
        if (!satisfactionSpriteDict.TryGetValue(satisfactionLevel, out Sprite sprite))
        {
            Debug.LogErrorFormat(name + " | Bird.UpdateSprite() failed to pull {0} sprite from dictionary", satisfactionLevel);
            return;
        }
    }
}
