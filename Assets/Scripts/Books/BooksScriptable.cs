using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Book",menuName ="ScriptableObjects/Book")]
public class BooksScriptable : ScriptableObject
{
    public string bookTitle;
    public string bookAuthor;
    [TextArea] public string bookDescription;
    public float bookPrice;
    public Sprite bookTypeSprite;
    public int typeOfBook;
    public int bookIndex;
}
