using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoanButtonScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Button button;
    [SerializeField] DebtCollector collector;

    private void Update()
    {
        if (collector.amountofRates>0)
        {
            text.text = "You already have a loan.";
            button.interactable = false;
        }
        else
        {
            text.text = "Get up to 2500$";
            button.interactable = true;
        }
    }
}
