using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    PlayerStats playerStats;
    public  Action<int> gameOver;
    [SerializeField]
    private GameObject[] gameOverScreens;
    private GameObject gameOverScreen;
    [SerializeField]
    private GameObject gameOverCanvas;
    [SerializeField]
    private GameObject uiCanvas;
    private InputManager inputManager;
    [SerializeField] GameObject loadingScreen;

    private void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerStats = GetComponent<PlayerStats>();
        gameOver += SwapCanvases;
       
    }

    private void SwapCanvases(int index)
    {
        gameOverCanvas.SetActive(true);
        uiCanvas.SetActive(false);
        gameOverScreen = Instantiate(gameOverScreens[index]);
        gameOverScreen.transform.SetParent(gameOverCanvas.transform, false);
        inputManager.onFoot.Disable();
        inputManager.inGameOver.Enable();

    }
    public void GoToMainMenu()
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadSceneAsync(0);
    }
}
