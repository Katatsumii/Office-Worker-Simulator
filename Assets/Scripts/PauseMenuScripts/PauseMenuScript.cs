using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;
    [SerializeField]
    private GameObject Ui;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject buttons;
    [SerializeField]
    private GameObject optionsPanel;
    [SerializeField] Monitor monitor;
    public void OpenPauseMenu()
    {
        Ui.SetActive(false);
        pauseMenu.SetActive(true);
        inputManager.onFoot.Disable();
        inputManager.inPauseMenu.Enable();
        Time.timeScale = 0f;
        Cursor.visible = true;
        

    }
    public void ClosePauseMenu()
    {
        Ui.SetActive(true);
        pauseMenu.SetActive(false);
        inputManager.onFoot.Enable();
        inputManager.inPauseMenu.Disable();
        Time.timeScale = 1f;
        optionsPanel.SetActive(false);
        buttons.SetActive(true);

        if(monitor.isUsingMonitor==false)
        Cursor.visible = false;
        


    }
}
