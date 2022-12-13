using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControls : MonoBehaviour
{
    [SerializeField] GameObject cV;
    [SerializeField] GameObject uI;
    [SerializeField] InputManager playerInput;

    public void OpenStatsWindow()
    {
        cV.SetActive(true);
        uI.SetActive(false);
        Time.timeScale = 0f;
        playerInput.onFoot.Disable();
        playerInput.inPauseMenu.Enable();
    }
    public void CloseStatsWindow()
    {
        cV.SetActive(false);
        uI.SetActive(true);
        Time.timeScale = 1f;
        playerInput.onFoot.Enable();
        playerInput.inPauseMenu.Disable();
    }
}
