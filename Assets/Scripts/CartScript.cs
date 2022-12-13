using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CartScript : MonoBehaviour
{
    [SerializeField] private BoughtBooksCript boughBooksScript;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private BooksInCartManager booksInCartManager;
    public List <SpawnedBookScript> booksInCart=new List<SpawnedBookScript>();
    [SerializeField] private TextMeshProUGUI selectedAmount;
    [SerializeField] private TextMeshProUGUI totalPrice;
    private int totalAmount;
    private float totalPricef;
    [SerializeField] private GameObject cartBookPrefab;
    [SerializeField] private GameObject cartBookHolder;
    [SerializeField] private Sprite sprite1, sprite2, sprite3;
    [SerializeField] private Button buyAllButton;
    [SerializeField] private TextMeshProUGUI buyAllText;


    private void Update()
    {
        totalPrice.text = "Total amount: " + totalPricef + "$";
        selectedAmount.text = totalAmount + "";

        if (stats.money < totalPricef)
        {
            buyAllButton.interactable = false;
            buyAllText.text = "NO FUNDS";

        }
        else if(stats.money>totalPricef && totalAmount<=0 )
        {
            buyAllButton.interactable = false;
        }
        else
        {
            buyAllButton.interactable = true;
            buyAllText.text = "BUY";
        }


    }

    public void CalculateAmount()
    {
        totalAmount = 0;
         foreach (var book in booksInCart)
        {
            if (book.toggle.isOn)
                book.isSelected = true;
            else
                book.isSelected = false;
        
            if (book.isSelected == true)
                totalAmount++;
            else
                continue;
            
        }
    }
    public void CalculatePrice()
    {
        totalPricef = 0;
        foreach (var book in booksInCart)
        {
            if (book.toggle.isOn)
                book.isSelected = true;
            else
                book.isSelected = false;
            if (book.isSelected == true)
                totalPricef += book.bookPricef;
            else
                continue;

        }
    }
    public void DeleteBooksFromCart()
    {
        for(int i =booksInCart.Count-1;i>=0; i--)
        {
            var book = booksInCart[i];
            if (book.isSelected == true)
            {
                booksInCartManager.bookinCart[book.bookIndex] = false;
                booksInCart.Remove(booksInCart[i]);
                Destroy(book.gameObject);
            }
            else
                continue;
        }
        CalculateAmount();
        CalculatePrice();
    }
    public  void BuySelectedBooks()
    {
        for(int i =booksInCart.Count-1;i>=0;i--)
        {
            var book=booksInCart[i];
            if(book.isSelected==true)
            {
                booksInCartManager.bookBought[book.bookIndex] = true;
                booksInCartManager.bookinCart[book.bookIndex] = false;
                booksInCart.Remove(booksInCart[i]);
                boughBooksScript.BuyBook(book);
                Destroy(book.gameObject);
                

            }
        }
        CalculateAmount();
        CalculatePrice();
    }

    public void AddBook(BookScript book)
    {
        
        var spawnedbook=Instantiate(cartBookPrefab);
        booksInCart.Add(spawnedbook.GetComponent<SpawnedBookScript>());
        spawnedbook.transform.SetParent(cartBookHolder.transform, false);
        spawnedbook.GetComponent<SpawnedBookScript>().bookName.text = book.bookname;
        spawnedbook.GetComponent<SpawnedBookScript>().bookAuthor.text = book.author;
        spawnedbook.GetComponent<SpawnedBookScript>().bookIndex = book.bookIndex;
        spawnedbook.GetComponent<SpawnedBookScript>().bookDescription.text = book.description;
        spawnedbook.GetComponent<SpawnedBookScript>().bookPrice.text = book.bookPricef + "$";
        spawnedbook.GetComponent<SpawnedBookScript>().bookPricef = book.bookPricef;
        spawnedbook.GetComponent<SpawnedBookScript>().typeofBook = book.typeOfBook;
        spawnedbook.GetComponent<SpawnedBookScript>().bookAuthorS = book.author;
        spawnedbook.GetComponent<SpawnedBookScript>().bookNameS = book.bookname;
        spawnedbook.GetComponent<SpawnedBookScript>().bookDescriptionS= book.description;
        if (book.typeOfBook == 1)
            spawnedbook.GetComponent<SpawnedBookScript>().imagu.sprite = sprite1;
        else if(book.typeOfBook==2)
            spawnedbook.GetComponent<SpawnedBookScript>().imagu.sprite = sprite2;
        else if (book.typeOfBook==3)
            spawnedbook.GetComponent <SpawnedBookScript>().imagu.sprite = sprite3;

    }
   
}
