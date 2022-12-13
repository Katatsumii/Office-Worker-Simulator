using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = GetInitialState();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }
    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState=newState;
        currentState.Start();
    }
    protected virtual BaseState GetInitialState()
    {
        return null;
    }
}
