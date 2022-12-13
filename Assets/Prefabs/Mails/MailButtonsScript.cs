using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailButtonsScript : MonoBehaviour
{
    private GameOver gameOver;
    private PlayerStats playerStats;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameOver=player.GetComponent<GameOver>();
        playerStats = player.GetComponent<PlayerStats>();
    }
    public void mail1Button1()
    {
        playerStats.UpdateEnergy(-10);
        playerStats.UpdateMoney(-20);
        playerStats.UpdateSocial(10);
    }
    public void mail1Button2()
    {
        gameOver.gameOver.Invoke(4);
    }
    public void mail2Button1()
    {
        playerStats.UpdateMoney(-1000);
        playerStats.UpdateSocial(-30);
    }
    public void mail2Button2()
    {
        playerStats.UpdateMoney(-100);
    }
    public void mail2Button3()
    {
        playerStats.UpdateSocial(10);
    }
}
