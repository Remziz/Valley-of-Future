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
    /*void Start(){
        // field script
        for (int i1 = 0; i1 < 14; i1++){
            for (int i2 = 0; i2 < 7; i2++){
                GameObject fland = Instantiate(flandP);           
                fland.transform.position = new Vector2(3.5f+i1,5.5f-i2);
                fland.name = "fland_"+fland.transform.position.x + "_"+fland.transform.position.y;
            }
        }
        //booster set test
        /*
        for (int i1 = 0; i1 < 13; i1++){
            for (int i2 = 0; i2 < 6; i2++){
                GameObject bster = Instantiate(bsterP);           
                bster.transform.position = new Vector2(4f+i1,5f-i2);
                bster.name = "bster_"+bster.transform.position.x + "_"+bster.transform.position.y;
            }
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
