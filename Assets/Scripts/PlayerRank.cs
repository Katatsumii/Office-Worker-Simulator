using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerRank : MonoBehaviour,ISavingManager
{
   public enum playerRank
    {
        Intern,
        Junior,
        Senior,

    }
    public playerRank currentRank = playerRank.Intern;

    [SerializeField] private PlayerStats stats;
    [SerializeField] private GameObject internMail;
    [SerializeField] private GameObject juniorMail;
    [SerializeField] private MailSpawner mailSpawner;
    [SerializeField] private GameObject smallcoffe;
    [SerializeField] private GameObject largecoffe;
    [SerializeField] private TextMeshProUGUI rankTextinCV;
    
    public float payment = 0f;

    public void Save(GameData gamedata)
    {
        gamedata.currentRank=this.currentRank;
        gamedata.payment = this.payment;
    }
    public void Load(GameData gamedata)
    {
        this.currentRank=gamedata.currentRank;
        this.payment=gamedata.payment;

    }
    private void Update()
    {
        switch(currentRank)
        {
            case playerRank.Intern:
                InternUpdate();
                break;
            case playerRank.Junior:
                JuniorUpdate();
                break;
            case playerRank.Senior:
                SeniorUpdate();
                break;
        }
        
    }
    //===============Intern====================
    private void InternStart() 
    {
        payment= 0f;
    }
    private void InternUpdate() 
    {
        if (stats.toPromotion>=100)
        {
            ChangeRank(playerRank.Junior);
            stats.toPromotion = 30f;

        }

    }
    private void InternEnd() 
    {

        mailSpawner.SendPromotionMail(0);
       // var intern = juniorMail.GetComponent<MailButton>();
       // mailSpawner.mailButtons.Add(intern);
    }
    //==============Junionr====================
    private void JuniorStart() 
    {
        payment =100f;
        smallcoffe.SetActive(true);
        rankTextinCV.text = "Junior Salesman";
    }
    private void JuniorUpdate() 
    {
        if (stats.toPromotion >= 100 && stats.charisma >= 5) 
        {
            ChangeRank(playerRank.Senior);
            stats.toPromotion = 30f;

        }
    }
    private void JuniorEnd() 
    {
        mailSpawner.SendPromotionMail(0);
        //var junior = juniorMail.GetComponent<MailButton>();
        //mailSpawner.mailButtons.Add(junior);
    }
    //==============Senior=====================
    private void SeniorStart() 
    {
        smallcoffe.SetActive(false);
        largecoffe.SetActive(true) ;
        payment = 200f;
        rankTextinCV.text = "Senior Salesman";
    }
    private void SeniorUpdate() { }
    private void SeniorEnd() { }


private void ChangeRank(playerRank rank)
{
        switch(currentRank)
        {
            case playerRank.Intern:
                InternEnd();
                break;
            case playerRank.Junior:
                JuniorEnd();
                break;
            case playerRank.Senior:
                SeniorEnd();
                break;


        }
        switch(rank)
        {
            case playerRank.Intern:
                InternStart();
                break;
            case playerRank.Junior:
                JuniorStart();
                break;
            case playerRank.Senior:
                SeniorStart();
                break;

        }
        currentRank = rank;
}
}
