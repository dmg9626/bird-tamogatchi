using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SatisfactionLevel { LOW, MEDIUM, HIGH, MAX }



[System.Serializable]
public class Need : MonoBehaviour
{
    /// <summary>
    /// Current level of satisfaction for this need
    /// </summary>
    [SerializeField]
    [Range(0,1)]
    public float level = .3f;

    /// <summary>
    /// Indicates type of need
    /// </summary>
    public enum Type { HUNGER, FUN, LOVE };

    public SatisfactionLevel satisfactionLevel;

    [SerializeField]
    protected NeedViewElement viewElement;

    [SerializeField]
    protected bool decreaseOverTime = true;

    [SerializeField]
    /// <summary>
    /// How often this need will decrease
    /// </summary>
    protected float decreaseFrequency = 15;

    [SerializeField]
    /// <summary>
    /// How much this need will drop when decreased
    /// </summary>
    protected float decreaseAmount = .2f;

    protected virtual void Start()
    {
        if (decreaseOverTime)
            StartCoroutine(DecreaseOverTime());

        if(!viewElement)
            Debug.LogError(name + " | missing reference to NeedViewElement");
    }

    protected virtual void Update()
    {
        // Update sprite according to level of satisfaction
        CalculateSatisfaction();
        viewElement.UpdateSprite(satisfactionLevel);
    }

    /// <summary>
    /// Updates SatisfactionLevel according to value of level
    /// </summary>
    private void CalculateSatisfaction()
    {

        if (level <= .3f)
            satisfactionLevel = SatisfactionLevel.LOW;
        else if (level <= .6f)
            satisfactionLevel = SatisfactionLevel.MEDIUM;
        else if (level <= .9f)
            satisfactionLevel = SatisfactionLevel.HIGH;
        else
            satisfactionLevel = SatisfactionLevel.MAX;
    }

    private IEnumerator DecreaseOverTime()
    {
        while(true)
        {
            // Wait delay, then decrease stat
            yield return new WaitForSeconds(decreaseFrequency);
            Decrease(decreaseAmount);
        }
    }

    public void Increase(float amount)
    {
        Debug.Log(name + " | changing from " + level + " to " + Mathf.Clamp(level + amount, 0, 1));
        level = Mathf.Clamp(level + amount, 0, 1);
    }

    public void Decrease(float amount)
    {
        Increase(-amount);
    }

}
