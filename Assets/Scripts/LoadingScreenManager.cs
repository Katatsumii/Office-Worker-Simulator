using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenManager : MonoBehaviour
{
    private GameObject LoadingScreen;
    void Start()
    {
        Cursor.visible = false;
        
        if(LoadingScreen == null)
        {
        LoadingScreen = GameObject.Find("LoadingScreen");
            if(LoadingScreen != null)
        LoadingScreen.SetActive(false);

        }
    }

    
}
