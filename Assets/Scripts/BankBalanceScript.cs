using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BankBalanceScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyAmount;
    [SerializeField] PlayerStats playerStats;
    
    private void Update()
    {
        moneyAmount.text = "<b>" + playerStats.money + "</b>" + "$";
    }
}
