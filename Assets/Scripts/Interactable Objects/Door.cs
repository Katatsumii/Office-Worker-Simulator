using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private GameObject nextDay;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private PlayerSkills playerskills;

    protected override void Interact()
    {
        if (timeManager.hours < 15 && playerskills.ninjaBought == false)
            gameOver.gameOver.Invoke(5);
        else if (timeManager.hours < 12 && playerskills.ninjaBought == true)
            gameOver.gameOver.Invoke(5);
        else
        nextDay.SetActive(true);
    }
}
