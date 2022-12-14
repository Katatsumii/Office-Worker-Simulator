using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : Interactable
{
    [SerializeField] Chair chair;
    [SerializeField] GameObject monitorCamera;
    [SerializeField] GameObject sittingCamera;
    [SerializeField] GameObject UI;
    public bool isUsingMonitor = false;
    private void Update()
    {
        if (chair.isSiting == true)
            promptMessage = "Press <color=yellow>E</color> to use.";
        else
            promptMessage = "";
    }
    protected override void Interact()
    {
        if(chair.isSiting == true)
        {
            monitorCamera.SetActive(true);
            sittingCamera.SetActive(false);
            UI.SetActive(false);
            isUsingMonitor = true;
            Cursor.visible = true;
        }    

    }
    public void DisableCamera()
    {
        monitorCamera.SetActive(false);
        sittingCamera.SetActive(true );
        UI.SetActive(true);
        isUsingMonitor=false;
        Cursor.visible = false;
    }
}
