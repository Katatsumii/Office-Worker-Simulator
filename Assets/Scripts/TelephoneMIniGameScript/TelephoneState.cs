using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TelephoneState : MonoBehaviour
{
    public enum telephoneStates
    {
        idle,
        calling,
        talking
    }
    public telephoneStates currentTelephoneState;
    public AudioSource telSound;
    [SerializeField]
    private float callTimer;
    private float callTime = 15f;
    [SerializeField]
    private float cooldownTimer;
    [SerializeField]
    private float cooldownTime;
    public GameObject callingImage;
    public GameObject talkingImage;
    public GameObject callingComponents;
    [SerializeField] GameObject callingCamera;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject sitCamera;
    [SerializeField] GameObject ui;
    [SerializeField] Chair chair;

    private void Start()
    {
        currentTelephoneState = telephoneStates.idle;
        startIdleState();
    }

    private void Update()
    {
        switch (currentTelephoneState)
        {
            case telephoneStates.idle: UpdateIdleState();
                break;
            case telephoneStates.calling: UpdateCallingState();
                break;
            case telephoneStates.talking: UpdateTalkingState();
                break;
        }
    }
    void startIdleState()
    {
        cooldownTimer = 0;
        cooldownTime = Random.Range(60f,180f);
    }
    void startCallingState()
    {
        telSound.Play();
        callingImage.SetActive(true);

        callTimer = 0;

    }
    void startTalkingState()
    {
        talkingImage.SetActive(true);
    }
    void UpdateIdleState()
    {
        cooldownTimer+=Time.deltaTime;
        if(cooldownTimer>cooldownTime)
        {
        ChangeState(telephoneStates.calling);

        }
    }
    void UpdateCallingState()
    {
        callTimer+=Time.deltaTime;
        if(callTimer>callTime)
        {
            ChangeState(telephoneStates.idle);
            if(chair.isSiting==true)
                sitCamera.SetActive(true);
            else
                mainCamera.SetActive(true);
            callingCamera.SetActive(false);
            ui.SetActive(true);
            Cursor.visible = false;


            
        }



    }
    void UpdateTalkingState()
    {

    }

    void EndTalkingState()
    {
        talkingImage?.SetActive(false);
    }
    void EndIdleState()
    {
        
    }
    void EndCallingState()
    {
        telSound.Stop();
        callingImage.SetActive(false);
    }


    public void ChangeState(telephoneStates state)
    {
        switch (currentTelephoneState)
        {
            case telephoneStates.idle: EndIdleState();
                break;
            case telephoneStates.calling: EndCallingState();
                break;
            case telephoneStates.talking: EndTalkingState();
                break;
        }
        switch (state)
        {
            case telephoneStates.idle: startIdleState();
                break;
            case telephoneStates.calling: startCallingState();
                break;
            case telephoneStates.talking: startTalkingState();
                break;
        }
        currentTelephoneState = state;
    }
    public void ChangeToIdle()
    {
        ChangeState(telephoneStates.idle);
    }

}
