using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnedBookScript : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI bookName;
    [SerializeField] public TextMeshProUGUI bookDescription;
    [SerializeField] public TextMeshProUGUI bookAuthor;
    [SerializeField] public TextMeshProUGUI bookPrice;
    public string bookNameS;
    public string bookDescriptionS;
    public string bookAuthorS;
    [SerializeField] public Image imagu;
    [SerializeField] public Toggle toggle;
    CartScript cartScript;
    public bool isSelected;
    public float bookPricef;
    public int bookIndex;
    public int typeofBook;

    private void Start()
    {
        cartScript=GameObject.Find("CartPanel").GetComponent<CartScript>();
        toggle.onValueChanged.AddListener((value)=>cartScript.CalculateAmount());
        toggle.onValueChanged.AddListener((value) => cartScript.CalculatePrice());
    }
   
}
