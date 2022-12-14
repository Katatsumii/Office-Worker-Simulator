using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoughtBooksCript : MonoBehaviour
{
    private List<YourBook> books = new List<YourBook>();
    [SerializeField]private GameObject boughtBookPrefab;
    [SerializeField]private GameObject boughtBookHolder;
    [SerializeField] private Sprite sprite1, sprite2, sprite3;
    [SerializeField] public int typeofBook;
 

   


    public void BuyBook(SpawnedBookScript book)
    {
     var boughtbook=Instantiate(boughtBookPrefab);
        boughtbook.transform.SetParent(boughtBookHolder.transform, false);
        var boughtbookscript = boughtbook.GetComponent<YourBook>();
        books.Add(boughtbookscript);
        boughtbookscript.bookname.text = book.bookNameS;
        boughtbookscript.bookauthor.text = book.bookAuthorS;
        boughtbookscript.bookdescription.text = book.bookDescriptionS;
        boughtbookscript.typeofBook = book.typeofBook;
        boughtbookscript.bookName = book.bookNameS;
        boughtbookscript.authorName = book.bookAuthorS;
        if (book.typeofBook == 1)
            boughtbookscript.bookImage.sprite = sprite1;
        else if (book.typeofBook == 2)
            boughtbookscript.bookImage.sprite = sprite2;
        else if (book.typeofBook == 3)
            boughtbookscript.bookImage.sprite = sprite3;
    }

}
