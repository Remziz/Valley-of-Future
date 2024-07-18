using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class learningBook : MonoBehaviour
{
    public bool bookOpen = false;
    private GameObject Book;

    public Sprite openedButton;
    public Sprite closedButton;
    private void Start()
    {
         Book = transform.GetChild(0).gameObject;
    }

    public void Clic()
    {
        if (!bookOpen)
        {
            GetComponent<Image>().sprite = openedButton;
            Book.SetActive(true);
            bookOpen = true;
        }
        else
        {
            GetComponent<Image>().sprite = closedButton;
            Book.SetActive(false);
            bookOpen = false;
        }
    }

}
