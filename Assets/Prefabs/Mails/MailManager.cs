using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MailManager : MonoBehaviour
{
    [SerializeField]
    private Button buttonPrefab;
    [SerializeField]
    private GameObject selectedResponseHolder;
    [SerializeField]
    private GameObject summaryTextHolder;
    [SerializeField]
    private GameObject selectedAnswerHolder;
    [SerializeField]
    private GameObject socialHolder, moneyHolder, enduranceHolder, workHolder, selectedResponse;
    [SerializeField]
    private TextMeshProUGUI consequences;

    [SerializeField]
    private GameObject buttonHolder;
    [SerializeField]
    private GameOver gameOver;
    [SerializeField]
    private PlayerStats playerStats;
    [SerializeField]
    private TextMeshProUGUI bigMail, author, title;
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private TransactionList transactionList;

    public void SetActiveMail(Mails mail)
    {
        bigMail.text = mail.wholeMail;
        author.text = mail.sender;
        title.text = mail.title;
        if (!mail.isAnswered)
        {
            foreach (var btn in mail.Buttons)
            {
                var button = SpawnMailButton(btn);
                button.onClick.AddListener(() => { OnClickButton(btn, mail); });
            }

        }
        else
        {
            socialHolder.SetActive(false);
            workHolder.SetActive(false);
            moneyHolder.SetActive(false);
            enduranceHolder.SetActive(false);
            selectedResponseHolder.SetActive(true);
            foreach (var btn in mail.Buttons)
            {
                if (btn.isChoosen)
                    AssignEverything(btn);
                else
                    continue;
            }
            
        }


    }
    private Button SpawnMailButton(AnswerButtons btn)
    {
        Button button = Instantiate(buttonPrefab);
        button.GetComponentInChildren<TextMeshProUGUI>().text = btn.btnText;
        button.transform.SetParent(buttonHolder.transform, false);
        return button;

    }
    private void OnClickButton(AnswerButtons stats, Mails mail)
    {
        stats.isChoosen = true;
        mail.isAnswered = true;
        playerStats.UpdateEnergy(stats.staminaCost);
        playerStats.UpdateSocial(stats.socialCost);
        playerStats.UpdateMoney(stats.money);
        if(stats.money>0)
            transactionList.AddTransaction(timeManager.currentDate, "Mail", "+" + stats.money.ToString() + "$");
        else if(stats.money<0)
            transactionList.AddTransaction(timeManager.currentDate, "Mail", "-" + stats.money.ToString() + "$");

        playerStats.UpdateWork(stats.work);
        playerStats.mailsAnswered++;
        if (stats.isGameOver != 0)
            gameOver.gameOver(stats.isGameOver);
        foreach (Transform child in buttonHolder.transform)
            child.gameObject.SetActive(false);
        AssignEverything(stats);




    }

     private void AssignEverything(AnswerButtons stats)

        {
            enduranceHolder.SetActive(false);
            moneyHolder.SetActive(false);
            socialHolder.SetActive(false);
            workHolder.SetActive(false);


            selectedResponse.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = stats.btnText;
            selectedResponseHolder.SetActive(true);
            consequences.text = stats.consequences;

        if (stats.staminaCost != 0)
        {
            enduranceHolder.SetActive(true);
            enduranceHolder.GetComponent<TextMeshProUGUI>().text = "Energy: ";
            if (stats.staminaCost > 0)
            {
                enduranceHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + stats.staminaCost;
                enduranceHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(30f / 255f, 101f / 255f, 51f / 255f);

            }
            else
            {
                enduranceHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + stats.staminaCost;
                enduranceHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
            }


        }

            if (stats.socialCost != 0)
                {
                socialHolder.SetActive(true);
                socialHolder.GetComponent<TextMeshProUGUI>().text = "Social: ";
                if (stats.socialCost > 0)
                {
                    socialHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + stats.socialCost;
                    socialHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(30f / 255f, 101f / 255f , 51f / 255f);

            }
                else
                {
                    socialHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + stats.socialCost;
                    socialHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
                }


            }
            if (stats.money == 0)
            {
            moneyHolder.SetActive(false);
            }
            else
            moneyHolder.SetActive(true);
            moneyHolder.GetComponent<TextMeshProUGUI>().text = "Money: ";
            if (stats.money > 0)
            {
            moneyHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + stats.money;
            moneyHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(30f / 255f, 101f / 255f, 51f / 255f);

            }
            else
            {
            moneyHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + stats.money;
            moneyHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
            }



            if (stats.work != 0)
            {
                workHolder.SetActive(true);
                workHolder.GetComponent<TextMeshProUGUI>().text = "Work: ";
                if (stats.work > 0)
                {
                    workHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "+" + stats.work;
                    workHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = new Color(30f / 255f, 101f / 255f, 51f / 255f);

            }
                else
                {
                    workHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "" + stats.work;
                    workHolder.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.red;
                }


            }
            stats = null;

        }
    }


