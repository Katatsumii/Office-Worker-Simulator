using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TransactionList : MonoBehaviour
{
    [SerializeField]
    private GameObject historyTemplate;

   
    public void AddTransaction(string data,string name,string price)
    {
        GameObject transaction = Instantiate(historyTemplate, transform);
        transaction.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = name;
        transaction.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = price;
        transaction.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = data;
        if(transform.childCount>20)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
    }
   
}
