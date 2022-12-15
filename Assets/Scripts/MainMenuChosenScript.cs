using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuChosenScript : MonoBehaviour
{
    public void NewGame()
    {
    GameObject.Find("DontDestroyManager").GetComponent<LoadingScreenSCript>().newGame = true;
    }
    public void LoadGame()
    {
    GameObject.Find("DontDestroyManager").GetComponent<LoadingScreenSCript>().loadGame = true;
    }
}
