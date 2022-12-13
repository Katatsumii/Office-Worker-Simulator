using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoanAmoutButton : MonoBehaviour
{
    public float loanAmount;
    [SerializeField] private LoanManager loanManager;
    [SerializeField] private Image image;
    [SerializeField] private Sprite selectedSprite;


    public void OnClick()
    {
        loanManager.ResetAmountButtons();
        image.sprite = selectedSprite;
        loanManager.SetLoanAmount(loanAmount);
    }





}
