using UnityEngine;
using System;

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

    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        gameOver += SwapCanvases;
       
    }

    private void SwapCanvases(int index)
    {
        gameOverCanvas.SetActive(true);
        uiCanvas.SetActive(false);
        gameOverScreen = Instantiate(gameOverScreens[index]);
        gameOverScreen.transform.SetParent(gameOverCanvas.transform, false);
    }
}
