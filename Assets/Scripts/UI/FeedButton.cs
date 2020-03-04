    using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class FeedButton : MonoBehaviour
{
    private Bird bird;
    private Button button;

    // Use this for initialization
    void Start()
    {
        if (!TryGetComponent(out button))
            Debug.LogError("Missing button");

        button.onClick.AddListener(() =>
        {
            if(!bird)
            {
                Debug.Log("Lost reference to bird, trying to find it again...");
                bird = FindObjectOfType<Bird>();
            }
            bird.nextAction = Action.Type.FEED;
        });
    }
}
