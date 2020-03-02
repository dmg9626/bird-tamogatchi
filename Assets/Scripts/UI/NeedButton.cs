using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class NeedButton : MonoBehaviour
{
    public Need need;

    private Button button;

    // Use this for initialization
    void Start()
    {
        if (!TryGetComponent(out button))
            Debug.LogError("Missing button");

        button.onClick.AddListener(() =>
        {
            need.Increase(.2f);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
