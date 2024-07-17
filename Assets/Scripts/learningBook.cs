using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class learningBook : MonoBehaviour
{
    public bool bookOpen = false;
    private GameObject Book;

    public Sprite openedButton;
    public Sprite closedButton;

    public Sprite openedBook;
    public Sprite closedBook;

    private void Start()
    {
         Book = transform.GetChild(0).gameObject;
    }

    public void Clic()
    {
        if (!bookOpen)
        {
            GetComponent<SpriteRenderer>().sprite = openedButton;
            Book.GetComponent<SpriteRenderer>().sprite = openedBook;
            bookOpen = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = closedButton;
            Book.GetComponent<SpriteRenderer>().sprite = closedBook;
            bookOpen = false;
        }
    }

}
