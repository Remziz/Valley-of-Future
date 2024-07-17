using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public bool water = true;
    [SerializeField] private Sprite lampo;
    
    int i1, i2;
    public void Init(string set_cell, bool wtr){
        var splitted = set_cell.Split('_');
        i1 = Convert.ToInt32(splitted[1]);
        i2 = Convert.ToInt32(splitted[2]);
        water = wtr;
        if(water){
        if(i1!=0)GameObject.Find("fland_"+(i1-1)+"_"+i2).GetComponent<Cell>().underBoost(true, true);
        if(i1!=13)GameObject.Find("fland_"+(i1+1)+"_"+i2).GetComponent<Cell>().underBoost(true, true);
        if(i2!=0)GameObject.Find("fland_"+i1+"_"+(i2-1)).GetComponent<Cell>().underBoost(true, true);
        if(i2!=6)GameObject.Find("fland_"+i1+"_"+(i2+1)).GetComponent<Cell>().underBoost(true, true);
        }else{
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = lampo;
        if(i1!=0)GameObject.Find("fland_"+(i1-1)+"_"+i2).GetComponent<Cell>().underBoost(true, false);
        if(i1!=13)GameObject.Find("fland_"+(i1+1)+"_"+i2).GetComponent<Cell>().underBoost(true, false);
        if(i2!=0)GameObject.Find("fland_"+i1+"_"+(i2-1)).GetComponent<Cell>().underBoost(true, false);
        if(i2!=6)GameObject.Find("fland_"+i1+"_"+(i2+1)).GetComponent<Cell>().underBoost(true, false);
        }
    }
    public void Kill(string set_cell)
    {
        var splitted = set_cell.Split('_');
        i1 = Convert.ToInt32(splitted[1]);
        i2 = Convert.ToInt32(splitted[2]);
        if(water){
        if (i1 != 0) GameObject.Find("fland_" + (i1 - 1) + "_" + i2).GetComponent<Cell>().underBoost(false, true);
        if (i1 != 13) GameObject.Find("fland_" + (i1 + 1) + "_" + i2).GetComponent<Cell>().underBoost(false, true);
        if (i2 != 0) GameObject.Find("fland_" + i1 + "_" + (i2 - 1)).GetComponent<Cell>().underBoost(false, true);
        if (i2 != 6) GameObject.Find("fland_" + i1 + "_" + (i2 + 1)).GetComponent<Cell>().underBoost(false, true);
        }else{
        if (i1 != 0) GameObject.Find("fland_" + (i1 - 1) + "_" + i2).GetComponent<Cell>().underBoost(false, false);
        if (i1 != 13) GameObject.Find("fland_" + (i1 + 1) + "_" + i2).GetComponent<Cell>().underBoost(false, false);
        if (i2 != 0) GameObject.Find("fland_" + i1 + "_" + (i2 - 1)).GetComponent<Cell>().underBoost(false, false);
        if (i2 != 6) GameObject.Find("fland_" + i1 + "_" + (i2 + 1)).GetComponent<Cell>().underBoost(false, false);
        }
    }
}
