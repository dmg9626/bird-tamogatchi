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

    public SatisfactionLevel satisfactionLevel => CalculateSatisfaction();

    [SerializeField]
    protected NeedViewElement viewElement;

    [SerializeField]
    protected bool decreaseOverTime = true;

    [SerializeField]
    /// <summary>
    /// Hold min/max time to wait before decreasing this stat
    /// </summary>
    protected Vector2 decreaseFrequency = new Vector2(5, 10);

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
        viewElement.UpdateSatisfaction(satisfactionLevel);
    }

    /// <summary>
    /// Updates SatisfactionLevel according to value of level
    /// </summary>
    protected virtual SatisfactionLevel CalculateSatisfaction()
    {
        if (level <= .3f)
            return SatisfactionLevel.LOW;
        else if (level <= .6f)
            return SatisfactionLevel.MEDIUM;
        else if (level <= .9f)
            return SatisfactionLevel.HIGH;
        else
            return SatisfactionLevel.MAX;
    }

    private IEnumerator DecreaseOverTime()
    {
        while(true) {
            // Generate delay between min/max ends of decreaseFrequency
            float delay = Random.Range(decreaseFrequency.x, decreaseFrequency.y);
            
            // Wait delay, then decrease stat
            yield return new WaitForSeconds(delay);
            Decrease(decreaseAmount);
        }
    }

    public void Increase(float amount)
    {
        //Debug.Log(name + " | changing from " + level + " to " + Mathf.Clamp(level + amount, 0, 1));
        level = Mathf.Clamp(level + amount, 0, 1);
    }

    public void Decrease(float amount)
    {
        Increase(-amount);
    }

}
