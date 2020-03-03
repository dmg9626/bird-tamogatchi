using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class NeedViewElement : MonoBehaviour
{
    /// <summary>
    /// Indicates level of satisfaction for this Need
    /// </summary>
    [SerializeField]
    private Image image;

    [Header("Sprites")]
    /// <summary>
    /// Sprite shown when satisfaction is LOW
    /// </summary>
    [SerializeField]
    private Sprite unhappySprite;

    /// <summary>
    /// Sprite shown when satisfaction is MEDIUM
    /// </summary>
    [SerializeField]
    private Sprite neutralSprite;

    /// <summary>
    /// Sprite shown when satisfaction is HIGH
    /// </summary>
    [SerializeField]
    private Sprite happySprite;

    /// <summary>
    /// Sprite shown when satisfaction is MAX
    /// </summary>
    [SerializeField]
    private Sprite maxHappySprite;

    private Dictionary<SatisfactionLevel, Sprite> satisfactionSpriteDict;


    // Use this for initialization
    void Start()
    {
        if (!image)
            Debug.LogError(name + " | missing reference to Image component");

        satisfactionSpriteDict = new Dictionary<SatisfactionLevel, Sprite> {
            { SatisfactionLevel.LOW, unhappySprite },
            { SatisfactionLevel.MEDIUM, neutralSprite },
            { SatisfactionLevel.HIGH, happySprite },
            { SatisfactionLevel.MAX, maxHappySprite },
        };
    }

    /// <summary>
    /// Updates UI sprite according to satisfaction level
    /// </summary>
    /// <param name="satisfactionLevel"></param>
    public void UpdateSprite(SatisfactionLevel satisfactionLevel)
    {
        // Pull sprite from dictionary
        if (!satisfactionSpriteDict.TryGetValue(satisfactionLevel, out Sprite sprite)) {
            Debug.LogErrorFormat(name + " | Bird.UpdateSprite() failed to pull {0} sprite from dictionary", satisfactionLevel);
            return;
        }

        if (image.sprite != sprite)
            Debug.LogFormat("{0} | updating sprite to {1}", name, satisfactionLevel);

        // Update image
        image.sprite = sprite;
        Color color;
        switch(satisfactionLevel) {
            case SatisfactionLevel.MAX:
                color = Color.white;
                break;
            case SatisfactionLevel.HIGH:
                color = Color.cyan;
                break;
            case SatisfactionLevel.MEDIUM:
                color = Color.blue;
                break;
            case SatisfactionLevel.LOW:
                color = Color.grey;
                break;
            default:
                color = Color.black;
                break;
        }
        image.color = color;
    }
}
