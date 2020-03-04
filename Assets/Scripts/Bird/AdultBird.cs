using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ChirpAction))]
public class AdultBird : Bird
{

    // Update is called once per frame
    void Update()
    {
        if(!IsPerformingAction())
        {
            Debug.Log("performing Chirp action");
            Action chirpAction = GetActionByType(Action.Type.CHIRP);
            chirpAction.Execute();
        }
    }

    private Action SelectRandomAction()
    {
        Action.Type actionType = (Action.Type)Random.Range(0, 3);
        return GetActionByType(actionType);
    }
}
