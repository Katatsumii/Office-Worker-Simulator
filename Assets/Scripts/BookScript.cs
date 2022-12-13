using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BookScript : MonoBehaviour
{
    [SerializeField] BooksInCartManager booksInCartManager;
    [SerializeField] BooksScriptable bookScriptable;
    [SerializeField] TextMeshProUGUI bookName;
    [SerializeField] TextMeshProUGUI bookDescription;
    [SerializeField] TextMeshProUGUI bookPrice;
    [SerializeField] TextMeshProUGUI bookAuthor;
    [SerializeField] Image bookImage;
    public float bookPricef;
    public int typeOfBook;
    public string bookname;
    public string description;
    public string author;
    [SerializeField] Button bookButton;
    [SerializeField] TextMeshProUGUI bookButtonText;
    [SerializeField] CartScript cartScript;
    public int bookIndex;




    private void Start()
    {
        bookIndex = bookScriptable.bookIndex;
        bookPricef=bookScriptable.bookPrice;
        bookName.text = bookScriptable.bookTitle;
        bookDescription.text = bookScriptable.bookDescription;
        bookAuthor.text = bookScriptable.bookAuthor;
        bookPrice.text = bookScriptable.bookPrice + "$";
        bookImage.sprite = bookScriptable.bookTypeSprite;
        typeOfBook=bookScriptable.typeOfBook;
        bookname = bookScriptable.bookTitle;
        description = bookScriptable.bookDescription;
        author = bookScriptable.bookAuthor;

        bookButton.onClick.AddListener(()=> cartScript.AddBook(this));
        bookButton.onClick.AddListener(() => SetInCart());


    }
    private void Update()
    {
        if (booksInCartManager.bookinCart[bookIndex]==false && booksInCartManager.bookBought[bookIndex]==false)
        {
            bookButton.interactable = true;
            bookButtonText.text = "ADD TO CART";

        }
            
        else if(booksInCartManager.bookinCart[bookIndex] == true && booksInCartManager.bookBought[bookIndex] == false)
        {
            bookButton.interactable = false;
            bookButtonText.text = "IN CART";

        }
        else if (booksInCartManager.bookinCart[bookIndex] == false && booksInCartManager.bookBought[bookIndex] == true)
        {
            bookButton.interactable = false;
            bookButtonText.text = "OWNED";
        }


    }
    private void SetInCart()
    {
        booksInCartManager.bookinCart[bookIndex] = true;
    }

}
