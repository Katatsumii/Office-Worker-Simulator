using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BooksPanelScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI selectAllButton;
    [SerializeField]
    private Button selectAll;
    [SerializeField]
   private List<GameObject>books=new List<GameObject>();
    [SerializeField]
    private Toggle charismaToogle, enduranceToogle, intToogle;
    private void Start()
    {
        selectAll.onClick.AddListener(SelectAll);
    }
    private void Update()
    {
        if (charismaToogle.isOn == true)
        {
            foreach (GameObject book in books)
                if (book.GetComponent<BookScript>().typeOfBook == 1)
                    book.SetActive(true);
        }
        else if(charismaToogle.isOn==false)
        {
            foreach (GameObject book in books)
                if (book.GetComponent<BookScript>().typeOfBook == 1)
                book.SetActive(false);
        }
        if (enduranceToogle.isOn == true)
        {
            foreach (GameObject book in books)
                if (book.GetComponent<BookScript>().typeOfBook == 2)
                    book.SetActive(true);
        }
        else if (enduranceToogle.isOn == false)
        {
            foreach (GameObject book in books)
                if (book.GetComponent<BookScript>().typeOfBook == 2)
                    book.SetActive(false);
        }
        if (intToogle.isOn == true)
        {
            foreach (GameObject book in books)
                if (book.GetComponent<BookScript>().typeOfBook == 3)
                    book.SetActive(true);
        }
        else if (intToogle.isOn == false)
        {
            foreach (GameObject book in books)
                if (book.GetComponent<BookScript>().typeOfBook == 3)
                    book.SetActive(false);
        }
        if (charismaToogle.isOn == true && enduranceToogle.isOn == true && intToogle.isOn == true)
            SelectAll();
        if (charismaToogle.isOn == false && enduranceToogle.isOn == false && intToogle.isOn == false)
            DeselectAll();

    }

    public void SelectAll()
    {
        charismaToogle.isOn = true;
        enduranceToogle.isOn = true;
        intToogle.isOn = true;
        selectAllButton.text = "Deselect all";
        selectAll.onClick.RemoveAllListeners();
        selectAll.onClick.AddListener(DeselectAll);

    }
    public void DeselectAll()
    {
        charismaToogle.isOn = false;
        enduranceToogle.isOn = false;
        intToogle.isOn = false;
        selectAllButton.text = "Select all";
        selectAll.onClick.RemoveAllListeners();
        selectAll.onClick.AddListener(SelectAll);
    }
    
    

 

}
