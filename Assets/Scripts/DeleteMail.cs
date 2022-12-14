using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using System;

public class DeleteMail : MonoBehaviour
{

    MailSpawner mailSpawner;
    [SerializeField]
    private GameObject bigMailHolder;
    private void Start()
    {
        mailSpawner = GameObject.Find("TimeManager").GetComponent<MailSpawner>();
        
    }

    public void DeleteEmails()
    {
        for (int i = mailSpawner.mailButtons.Count-1; i >= 0;i--)
        {
            if (mailSpawner.mailButtons[i].isSelected)
            {
                mailSpawner.mailButtons[i].DeleteThisMail();
                mailSpawner.mailButtons.RemoveAt(i);
                bigMailHolder.SetActive(false);

            }
              
        }
        for(int i=mailSpawner.mailButtonsPromotion.Count-1; i >= 0;i--)
        {
            if(mailSpawner.mailButtonsPromotion[i].isSelected)
            {
                mailSpawner.mailButtonsPromotion[i].DeleteThisMail();
                mailSpawner.mailButtonsPromotion.RemoveAt(i);
                bigMailHolder.SetActive(false);
            }
        }
    }
}
