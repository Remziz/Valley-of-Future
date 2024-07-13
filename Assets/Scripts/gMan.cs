using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gMan : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI board;
    // Start is called before the first frame update
    public void mnChange(int amount){
        money+=amount;
        board.SetText("$:"+money);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
