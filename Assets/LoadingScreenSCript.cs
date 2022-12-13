using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreenSCript : MonoBehaviour
{
    private static LoadingScreenSCript instance;
    [SerializeField] GameObject loadingscreen;
    public bool newGame;
    public bool loadGame;
    private void Awake()
    { if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
        if (loadingscreen == null)
            loadingscreen = GameObject.Find("LoadingScreen");
    }
    private void Start()
    {
        { if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(gameObject);
    }
        if (loadingscreen == null)
            loadingscreen = GameObject.Find("LoadingScreen");
    }
    public void newGameChosen()
    {
        newGame=true;
    }
    public void continueChosen()
    {
        loadGame=true;
    }
   
}
