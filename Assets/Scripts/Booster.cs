using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public bool water;
    int i1, i2;
    // not working
    public void Init(string set_cell){
        var splitted = set_cell.Split('_');
        i1 = Convert.ToInt32(splitted[1]);
        i2 = Convert.ToInt32(splitted[2]);
        if(i1!=0)GameObject.Find("fland_"+(i1-1)+"_"+i2).GetComponent<Cell>().Plug();
        if(i1!=13)GameObject.Find("fland_"+(i1+1)+"_"+i2).GetComponent<Cell>().Plug();
        if(i2!=0)GameObject.Find("fland_"+i1+"_"+(i2-1)).GetComponent<Cell>().Plug();
        if(i2!=6)GameObject.Find("fland_"+i1+"_"+(i2+1)).GetComponent<Cell>().Plug();
    }
    //void Awake(){
        //Init("fland_1_0");
    //}
    public void Kill(){
        if(water){
            GameObject.Find("fland_"+(transform.position.x-0.5f)+"_"+(transform.position.y-0.5f)).GetComponent<Cell>().UnderWaterPump = false;
            GameObject.Find("fland_"+(transform.position.x-0.5f)+"_"+(transform.position.y+0.5f)).GetComponent<Cell>().UnderWaterPump = false;
            GameObject.Find("fland_"+(transform.position.x+0.5f)+"_"+(transform.position.y-0.5f)).GetComponent<Cell>().UnderWaterPump = false;
            GameObject.Find("fland_"+(transform.position.x+0.5f)+"_"+(transform.position.y+0.5f)).GetComponent<Cell>().UnderWaterPump = false;
        }else{
            GameObject.Find("fland_"+(transform.position.x-0.5f)+"_"+(transform.position.y-0.5f)).GetComponent<Cell>().UnderLightLamp = false;
            GameObject.Find("fland_"+(transform.position.x-0.5f)+"_"+(transform.position.y+0.5f)).GetComponent<Cell>().UnderLightLamp = false;
            GameObject.Find("fland_"+(transform.position.x+0.5f)+"_"+(transform.position.y-0.5f)).GetComponent<Cell>().UnderLightLamp = false;
            GameObject.Find("fland_"+(transform.position.x+0.5f)+"_"+(transform.position.y+0.5f)).GetComponent<Cell>().UnderLightLamp = false;
        Destroy(gameObject);
        }
    }
}
