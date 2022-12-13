using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    #region Player Stats Variables
    public float toPromotion;
    public float energy;
    public float social;
    public float money;
    public float energyRestoration;
    public float charisma;
    public float endurance;
    public float intelligence;
    public float maxSocial;
    public float maxEnergy;
    public int numberofcalls;
    public int numberofContract;
    public int freeDays;
    public int mailsAnswered;
    #endregion
    #region Player Skills Variables
    public bool skipBought;
    public bool restartBought;
    public bool changeBought;
    public bool boostCoffee;
    public bool ninjaBought;
    public bool boostBreak;
    #endregion
    #region Player Rank Variables
    public float payment;
    public PlayerRank.playerRank currentRank;
    #endregion
    #region Time Manager Variables
    public float day;
    public float month;
    public float year;
    #endregion
    #region Debt Collector Variables
    public float weeklyRate;
    public float amountsofRates;
    public bool instalmentTaken;
    #endregion
    public GameData()
    {
     toPromotion=50;
     energy=100;
     social=100;
     money=0;
     energyRestoration=30;
     charisma=1;
     endurance=1;
     intelligence=1;
     maxSocial=100;
     maxEnergy=100;
     numberofcalls=0;
     numberofContract=0;
     freeDays=0;
     mailsAnswered=0;

     skipBought = false;
     restartBought=false;
     changeBought=false;
     boostCoffee=false;
     ninjaBought = false;
     boostBreak=false;

     payment=0;
     currentRank = PlayerRank.playerRank.Intern;

     day=1;
     month=1;
     year=1;

     weeklyRate=0;
     amountsofRates=0;
     instalmentTaken=false;



}
}
