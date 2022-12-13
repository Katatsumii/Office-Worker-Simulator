using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCode : MonoBehaviour
{
    SceneLoading sceneLoading;
    private void Start()
    {
        sceneLoading = GetComponent<SceneLoading>();
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void NewGame()
    {
       sceneLoading.LoadScene(1);
    }
    public void Continue()
    {
        sceneLoading.LoadScene(1);
        
    }
}
