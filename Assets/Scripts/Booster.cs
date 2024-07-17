using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public bool water;
    int i1, i2;
    public void Init(string set_cell){
        var splitted = set_cell.Split('_');
        i1 = Convert.ToInt32(splitted[1]);
        i2 = Convert.ToInt32(splitted[2]);
        if(i1!=0)GameObject.Find("fland_"+(i1-1)+"_"+i2).GetComponent<Cell>().underBoost(true);
        if(i1!=13)GameObject.Find("fland_"+(i1+1)+"_"+i2).GetComponent<Cell>().underBoost(true);
        if(i2!=0)GameObject.Find("fland_"+i1+"_"+(i2-1)).GetComponent<Cell>().underBoost(true);
        if(i2!=6)GameObject.Find("fland_"+i1+"_"+(i2+1)).GetComponent<Cell>().underBoost(true);
    }
    public void Kill(string set_cell)
    {
        var splitted = set_cell.Split('_');
        i1 = Convert.ToInt32(splitted[1]);
        i2 = Convert.ToInt32(splitted[2]);
        if (i1 != 0) GameObject.Find("fland_" + (i1 - 1) + "_" + i2).GetComponent<Cell>().underBoost(false);
        if (i1 != 13) GameObject.Find("fland_" + (i1 + 1) + "_" + i2).GetComponent<Cell>().underBoost(false);
        if (i2 != 0) GameObject.Find("fland_" + i1 + "_" + (i2 - 1)).GetComponent<Cell>().underBoost(false);
        if (i2 != 6) GameObject.Find("fland_" + i1 + "_" + (i2 + 1)).GetComponent<Cell>().underBoost(false);
    }
}
