using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class YourBook : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI bookname;
    [SerializeField] public TextMeshProUGUI bookdescription;
    [SerializeField] public TextMeshProUGUI bookauthor;
    [SerializeField] public Image bookImage;
    [SerializeField] public int typeofBook;
    [SerializeField] public Button bookButton;
    private TextMeshProUGUI bookButtonText;
     private GameObject readingAnimation;//{ get; set; }
     private TextMeshProUGUI firstText;
     private TextMeshProUGUI secondText;

     public string bookName;
     public string authorName; 
    
    private PlayerStats stats;
     private TimeManager timeManager;

    private void Start()
    {
        bookButton = this.gameObject.transform.GetChild(0).GetComponent<Button>();
        bookButton.onClick.AddListener(ReadBook);
       
        stats=GameObject.Find("Player").GetComponent<PlayerStats>();
        timeManager = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        readingAnimation = GameObject.Find("BookReadingCanvas").transform.GetChild(0).gameObject;
        bookButtonText = bookButton.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    }
    private void Update()
    {
        if(stats.energy<11)
        {
            bookButton.interactable = false;
            bookButtonText.text = "ENERGY TOO LOW";
        }
        else
        {
            bookButton.interactable = true;
            bookButtonText.text = "READ";

        }
            
        
    }

    public void ReadBook()
    {
        readingAnimation.SetActive(true);
        firstText = GameObject.Find("BookTextAnimation").GetComponent<TextMeshProUGUI>();
        secondText = GameObject.Find("YouGained").GetComponent<TextMeshProUGUI>();

        firstText.text = "Reading '" + "<b>" + bookName +"</b>" +"' by " + authorName;
        if (typeofBook == 1)
            secondText.text = "You gained charisma (+1)";
         else if (typeofBook == 2)
            secondText.text = "You gained endurance (+1)";
        else if (typeofBook == 3)
            secondText.text = "You gained intelligence (+1)";
        timeManager.hours += 2;
        if (typeofBook == 1)
            stats.UpdateCharisma();
        else if (typeofBook == 2)
            stats.UpdateEndurance();
        else if (typeofBook == 3)
            stats.UpdateIntelligence();
        stats.UpdateEnergy(-10);
        Destroy(this.gameObject);
    }
    

}
