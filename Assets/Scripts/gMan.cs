using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class gMan : MonoBehaviour
{
    public int money;
    public TextMeshProUGUI board;
    [SerializeField] private GameObject flandP;
    [SerializeField] private GameObject bsterP;
    // Start is called before the first frame update
    public void mnChange(int amount){
        money+=amount;
        board.SetText("$:"+money);
    }
    void Start(){
        Time.timeScale = 1;
        // field script
        for (int i1 = 0; i1 < 14; i1++){
            for (int i2 = 0; i2 < 7; i2++){
                GameObject fland = Instantiate(flandP);           
                fland.transform.position = new Vector2(3.5f+i1,5.5f-i2);
                fland.name = "fland_"+i1 + "_"+i2;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
