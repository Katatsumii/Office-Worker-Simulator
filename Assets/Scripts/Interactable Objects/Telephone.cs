using UnityEngine;

public class Telephone : Interactable
{
    TelephoneState teleState;
    public GameObject teleCamera;
    public GameObject playerCamera;
    public GameObject sitingCamera;
    public GameObject canvas1;

    private void Start()
    {
        teleState = GameObject.Find("Telephone").GetComponent<TelephoneState>();
    }

    private void Update()
    {
        if (teleState.currentTelephoneState == TelephoneState.telephoneStates.calling)
        {
            promptMessage = "Press <color=yellow>E</color> to pick up";
        }
        else
            promptMessage = "";
    }

    protected override void Interact()
    {
        if (teleState.currentTelephoneState == TelephoneState.telephoneStates.calling)
        {
            //start minigame
            teleCamera.SetActive(true);
            playerCamera.SetActive(false);
            sitingCamera.SetActive(false);
            canvas1.SetActive(false);
            
        }
    }

}
