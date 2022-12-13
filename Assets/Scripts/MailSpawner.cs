using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MailSpawner : MonoBehaviour
{
    public List<MailButton> mailButtons = new List<MailButton>();
    [SerializeField]
    private TextMeshProUGUI activeMailsCount;
    public int activeMails = 0;
    [SerializeField]
    private GameObject countHolder;

    [SerializeField]
    private float mailActivatorTimer = 0f;
    [SerializeField]
    private float mailTimer = 0f;

    private void Start()
    {
        mailTimer = Random.Range(30f, 200);
        mailActivatorTimer = 0f;

    }





    private void Update()
    {
        CheckForActives();

        mailActivatorTimer += Time.deltaTime;
        if(mailActivatorTimer>= mailTimer)
        {
            SetTimerandMail();
        }

    }

    private void SetTimerandMail()
    {
        mailTimer = Random.Range(30f, 200);
        mailActivatorTimer = 0f;
        int number =Random.Range(0, mailButtons.Count);
        mailButtons[number].isActive = true;
        mailButtons[number].gameObject.SetActive(true);
        activeMails++;


    }
    private void CheckForActives()
    {
        activeMailsCount.text = activeMails + "";
        if (activeMails>0)
            countHolder.SetActive(true);
        else 
            countHolder.SetActive(false);
    }
}
