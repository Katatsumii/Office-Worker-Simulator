using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneSM : StateMachine
{
    public TelephoneIdle idleState;
    public TelephoneCalling callingState;

    private void Awake()
    {
        idleState = new TelephoneIdle(this);
        callingState = new TelephoneCalling(this);  
    }
    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}
