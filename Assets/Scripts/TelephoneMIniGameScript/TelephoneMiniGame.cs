using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneMiniGame : MonoBehaviour
{
    TelephoneState telephoneState;
    void Start()
    {
        telephoneState = GameObject.Find("Telephone").GetComponent<TelephoneState>();
    }

    public void PickUpPhone()
    {
        telephoneState.ChangeState(TelephoneState.telephoneStates.talking);
    }
    public void StopTalking()
    {
        telephoneState.ChangeState(TelephoneState.telephoneStates.idle);
    }
}
