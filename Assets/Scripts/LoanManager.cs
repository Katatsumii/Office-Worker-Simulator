using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class LoanManager : MonoBehaviour
{
    [SerializeField] private float loanAmount;
    [SerializeField] private float loanWeeks;
    [SerializeField] PlayerStats playerStats;
    [SerializeField] DebtCollector collector;
    [SerializeField] private List<GameObject> amountButtons=new List<GameObject>();
    [SerializeField] private List<GameObject> timeButtons=new List<GameObject>();
    [SerializeField] private Sprite basicSprite;




    public float weeklyRate;
    public float wholeCredit;

   
    public void SetLoanAmount(float amount)
    {
        loanAmount = amount;
    }
    public void SetWeeksAmount(float amount)
    {
        loanWeeks = amount;
    }

    public void GiveLoan()
    {
        if (loanAmount > 0 && loanWeeks > 0)
        {
            playerStats.UpdateMoney(loanAmount);
            wholeCredit = loanAmount + (loanAmount * 8 / 108);
            weeklyRate = wholeCredit / loanWeeks;
            collector.amountofRates = loanWeeks;
            collector.weeklyRate=weeklyRate;
            ResetInstalmentsButtons();
            ResetAmountButtons();
            gameObject.SetActive(false);
        }
        else
            return;
    }
    public void ResetAmountButtons()
    {
        foreach (GameObject button in amountButtons)
            button.GetComponent<Image>().sprite = basicSprite;
    }
    public void ResetInstalmentsButtons()
    {
        foreach (GameObject button in timeButtons)
            button.GetComponent<Image>().sprite = basicSprite;
    }
}
