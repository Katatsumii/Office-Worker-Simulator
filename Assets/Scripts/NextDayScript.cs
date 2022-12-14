using UnityEngine;
using TMPro;


public class NextDayScript : MonoBehaviour
{
[SerializeField] private SavingManager savingManager;
[SerializeField] private smallCoffeCup smallCoffeCups;
[SerializeField] private bigCoffeeCup bigCoffeCup;
[SerializeField] private Camera camCam;
[SerializeField] private GameObject player;
[SerializeField] private PlayerStats playerStats;
[SerializeField] private InputManager inputManager;
[SerializeField] private PlayerLook playerLook;
[SerializeField] private TimeManager timeManager;
[SerializeField] private DebtCollector collector;
[SerializeField] private PlayerRank rank;
[SerializeField] private TextMeshProUGUI secondline;
[SerializeField] private TextMeshProUGUI thirdline;
[SerializeField] private PlayerSkills playerskills;
[SerializeField] private GameOver gameOver;





    public void GoNextDay()
    {
            if(bigCoffeCup.isActiveAndEnabled)
                bigCoffeCup.drinkedToday = false;
            if (smallCoffeCups.isActiveAndEnabled)
                smallCoffeCups.drinkedToday = false;
            inputManager.enabled = false ;
            playerLook.enabled = false;
            playerStats.money += rank.payment;
            secondline.text = "Last day you earned $" + rank.payment;
            thirdline.text = "Throught the night you restored " + playerStats.energyRestoration + "% of your energy.";
            playerStats.UpdateEnergy(playerStats.energyRestoration);
            player.transform.position = new Vector3(-46, 1, 1.75f);
            player.transform.eulerAngles = new Vector3(0, 0, 0);
            camCam.transform.localRotation = Quaternion.Euler(0, 0, 0);
            playerLook.xRotation=0;
            collector.instalmentTaken = false;
            savingManager.SaveGame();
        }

    
    public void gameObjectDisable()
    {
        timeManager.minutes = 0;
        timeManager.hours = 7;
        timeManager.days++;
        inputManager.enabled = true;
        playerLook.enabled = true;
        gameObject.SetActive(false);
    }

}
