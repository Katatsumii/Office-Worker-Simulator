using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class PlayerSkills: MonoBehaviour, ISavingManager
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private GameObject areYouSure;
    [SerializeField] private Button buyButton;

    [SerializeField] private Button coffeeButton;
    [SerializeField] private Button ninjaButton;
    [SerializeField] private Button monkButton;
    [SerializeField] private Button fastthinkButton;
    [SerializeField] private Button resetButton;
    [SerializeField] private Button skipButton;

    [SerializeField] private List<GameObject> courses=new List<GameObject>();

    [SerializeField] private TransactionList transactionList;
    [SerializeField] private TimeManager timeManager;


    [SerializeField] private GameObject coffePrice;
    [SerializeField] private GameObject coffeePriceUSD;
    [SerializeField] private GameObject coffeSoldOut;
    [SerializeField] private GameObject ninjaPrice;
    [SerializeField] private GameObject ninjaPriceUSD;
    [SerializeField] private GameObject ninjaSoldOut;
    [SerializeField] private GameObject monkPrice;
    [SerializeField] private GameObject monkPriceUSD;
    [SerializeField] private GameObject monkSoldOut;
    [SerializeField] private GameObject skipPrice;
    [SerializeField] private GameObject skipPriceUSD;
    [SerializeField] private GameObject skipSoldOut;
    [SerializeField] private GameObject resetPrice;
    [SerializeField] private GameObject resetPriceUSD;
    [SerializeField] private GameObject resetSoldOut;
    [SerializeField] private GameObject fastPrice;
    [SerializeField] private GameObject fastPriceUSD;
    [SerializeField] private GameObject fastSoldOut;

    private int skillSelected = 0;

    public bool skipbought = false;
    public bool restartbought = false;
    public bool changeBought = false;
    public bool boostCoffeBought = false;
    public bool ninjaBought = false;
    public bool boostBreakBought = false;

    public void Save(GameData gamedata)
    {
        gamedata.skipBought = this.skipbought;
        gamedata.changeBought = this.changeBought;
        gamedata.restartBought = this.restartbought;
        gamedata.boostCoffee = this.boostCoffeBought;
        gamedata.ninjaBought = this.ninjaBought;
        gamedata.boostBreak = this.boostBreakBought;
    }
    public void Load(GameData gamedata)
    {
       skipbought = gamedata.skipBought;
        changeBought = gamedata.changeBought;
        restartbought = gamedata.restartBought;
        boostCoffeBought= gamedata.boostCoffee;
        ninjaBought= gamedata.ninjaBought;
        boostBreakBought = gamedata.boostBreak;

    }

    public void BuySkip() 
    {
        skillSelected = 1;
        areYouSure.SetActive(true);
        if(playerStats.money<3000)
            buyButton.interactable = false;
        else
            buyButton.interactable = true;
    }
    public void BuyRestart()
    {
        skillSelected = 2;
        areYouSure.SetActive(true);
        if (playerStats.money < 5000)
            buyButton.interactable = false;
        else
            buyButton.interactable = true;
    }
    public void BuyChangeAnswers() 
    { 
        skillSelected = 3;
        areYouSure.SetActive(true);
        if (playerStats.money < 2000)
            buyButton.interactable = false;
        else
            buyButton.interactable = true;
    }

    public void BuyCoffeBoost()
    {
        skillSelected = 4;
        areYouSure.SetActive(true);
        if (playerStats.money < 5000)
            buyButton.interactable = false;
        else
            buyButton.interactable = true;
    }

    public void BuyNinjaSkills()
    {
        skillSelected = 5;
        areYouSure.SetActive(true);
        if (playerStats.money < 10000)
            buyButton.interactable = false;
        else
            buyButton.interactable = true;
    }
    public void BoostBreak()
    {
        skillSelected = 6;
        areYouSure.SetActive(true);
        if (playerStats.money < 3000)
            buyButton.interactable = false;
        else
            buyButton.interactable = true;
    }

    public void presssedYes()
    {
        switch(skillSelected)
        {
            case 1:
                if (playerStats.money >= 3000)
                {
                    skipbought = true;
                    playerStats.money -= 3000;
                    transactionList.AddTransaction(timeManager.currentDate, "Splash course", "-3000$");
                    skipButton.interactable = false;
                    skipPriceUSD.SetActive(false);
                    skipPrice.SetActive(false);
                    skipSoldOut.SetActive(true);
                }
                break;
            case 2:
                if (playerStats.money >= 5000)
                {
                    restartbought = true;
                    playerStats.money -= 5000;
                    transactionList.AddTransaction(timeManager.currentDate, "Splash course", "-5000$");
                    resetButton.interactable = false;
                    resetPriceUSD.SetActive(false);
                    resetPrice.SetActive(false);
                    resetSoldOut.SetActive(true);

                }
                break;
            case 3:
                if (playerStats.money >= 2000)
                {
                    changeBought = true;
                    playerStats.money -= 2000;
                    transactionList.AddTransaction(timeManager.currentDate, "Splash course", "-2000$");
                    fastthinkButton.interactable = false;
                    fastPriceUSD.SetActive(false);
                    fastPrice.SetActive(false);
                    fastSoldOut.SetActive(true);

                }
                break;
            case 4:
                if (playerStats.money >= 5000)
                {
                    boostCoffeBought = true;
                    playerStats.money -= 5000;
                    transactionList.AddTransaction(timeManager.currentDate, "Splash course", "-5000$");
                    coffeeButton.interactable = false;
                    coffeePriceUSD.SetActive(false);
                    coffePrice.SetActive(false);
                    coffeSoldOut.SetActive(true);
                
                }
                break;
            case 5:
                if (playerStats.money >= 10000)
                {
                    ninjaBought = true;
                    playerStats.money -= 10000;
                    transactionList.AddTransaction(timeManager.currentDate, "Splash course", "-10000$");
                    ninjaButton.interactable = false;
                    ninjaPriceUSD.SetActive(false);
                    ninjaPrice.SetActive(false);
                    ninjaSoldOut.SetActive(true);


                }
                break;
            case 6:
                if (playerStats.money >= 3000)
                {
                    boostBreakBought = true;
                    playerStats.money -= 3000;
                    transactionList.AddTransaction(timeManager.currentDate, "Splash course", "-3000$");
                    monkButton.interactable = false;
                    monkPriceUSD.SetActive(false);
                    monkPrice.SetActive(false);
                    monkSoldOut.SetActive(true);
                }
                break;
          
        }
        areYouSure.SetActive(false);
        skillSelected = 0;
    }
    public void noPressed()
    {
        areYouSure.SetActive(false);
        skillSelected = 0;
    }

    public void PersonalDevelopmentButton()
    {
        foreach (var course in courses)
        {
            if (course.GetComponent<CourseButtonScript>().courseType == 1)
            {
                course.SetActive(true);
            }
            else
                course.SetActive(false);
            
        }
    }
    public void SocialSkillButton()
    {
        foreach(var course in courses)
        {
            if (course.GetComponent<CourseButtonScript>().courseType == 2)
            {
                course.SetActive(true);
            }
            else
                course.SetActive(false);
        }

    }
    public void AllButton()
    {
        foreach (var course in courses)
            course.SetActive(true);
    }
}
