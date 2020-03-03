using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(HorizontalLayoutGroup))]
public class NeedViewElement : MonoBehaviour
{
    /// <summary>
    /// Prefab for layout element to populate within this layout group
    /// </summary>
    [SerializeField]
    private Image layoutElementPrefab;


    /// <summary>
    /// Sprite shown to indicate what need this is
    /// </summary>
    [SerializeField]
    private Sprite needIndicatorSprite;

    private SatisfactionLevel satisfactionLevel;

    /// <summary>
    /// Links satisfaction level to number of icons
    /// </summary>
    private Dictionary<SatisfactionLevel, int> satisfactionSpriteDict = new Dictionary<SatisfactionLevel, int> {
            { SatisfactionLevel.LOW, 1 },
            { SatisfactionLevel.MEDIUM, 2 },
            { SatisfactionLevel.HIGH, 3 },
            { SatisfactionLevel.MAX, 4 },
        };


    // Use this for initialization
    void Start()
    {
        // Make sure we have reference to layout element prefab
        if (!layoutElementPrefab)
            Debug.LogError(name + " | missing reference to layout element prefab; cannot populate this LayoutGroup");


        // Initialize icon count
        if (!satisfactionSpriteDict.TryGetValue(satisfactionLevel, out int numberOfIcons)) 
            return;
        RefreshChildren(numberOfIcons);
    }

    /// <summary>
    /// Updates UI according to satisfaction level
    /// </summary>
    /// <param name="satisfactionLevel"></param>
    public void UpdateSatisfaction(SatisfactionLevel satisfactionLevel)
    {
        // Pull number of icons from dictionary
        if (!satisfactionSpriteDict.TryGetValue(satisfactionLevel, out int numberOfIcons)) {
            Debug.LogErrorFormat(name + " | Bird.UpdateSprite() failed to pull {0} sprite from dictionary", satisfactionLevel);
            return;
        }

        // Ignore if satisfaction level hasn't changed
        if (satisfactionLevel == this.satisfactionLevel)
            return;

        // Remember it so we don't update until it changes
        this.satisfactionLevel = satisfactionLevel;

        RefreshChildren(numberOfIcons);
    }

    private void RefreshChildren(int numberOfIcons)
    {
        // Destroy existing children
        for (int i = 0; i < transform.childCount; i++)
        {
            Debug.Log("Destroying child " + i);
            Transform child = transform.GetChild(i);
            Destroy(child.gameObject);
        }

        // Create number of children according to satisfaction level
        for (int i = 0; i < numberOfIcons; i++)
        {
            Image icon = Instantiate(layoutElementPrefab);
            icon.name = string.Format("{0}_{1}", layoutElementPrefab.name, i + 1);

            // Set the sprite
            icon.sprite = needIndicatorSprite;

            // Child it to this
            icon.transform.SetParent(transform);
        }
    }
}
