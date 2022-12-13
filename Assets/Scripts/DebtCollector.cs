using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebtCollector : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] PlayerStats stats;
    [SerializeField] TransactionList transactionList;
    

    public float weeklyRate;
    public float amountofRates;
    public bool instalmentTaken = false;
    void Update()
    {
     
        if(timeManager.days%7==0 && amountofRates>0&&instalmentTaken==false)
        {
            stats.UpdateMoney(-weeklyRate);
            transactionList.AddTransaction(timeManager.currentDate, "Instalment", "-"+weeklyRate);
            amountofRates--;
            instalmentTaken = true;
        }
        }
    }

