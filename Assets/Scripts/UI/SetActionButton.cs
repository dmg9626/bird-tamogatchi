    using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SetActionButton : MonoBehaviour
{
    private Bird bird;
    private Button button;

    [SerializeField]
    private Action.Type action;

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
            bird.nextAction = action;
        });
    }
}
