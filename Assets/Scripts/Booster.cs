using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public bool water;
    // not working
    void Awake(){
        if(water){
            GameObject.Find("fland_"+(transform.position.x-0.5f)+"_"+(transform.position.y-0.5f)).GetComponent<Cell>().UnderWaterPump = true;
            GameObject.Find("fland_"+(transform.position.x-0.5f)+"_"+(transform.position.y+0.5f)).GetComponent<Cell>().UnderWaterPump = true;
            GameObject.Find("fland_"+(transform.position.x+0.5f)+"_"+(transform.position.y-0.5f)).GetComponent<Cell>().UnderWaterPump = true;
            GameObject.Find("fland_"+(transform.position.x+0.5f)+"_"+(transform.position.y+0.5f)).GetComponent<Cell>().UnderWaterPump = true;
        }else{
            GameObject.Find("fland_"+(transform.position.x-0.5f)+"_"+(transform.position.y-0.5f)).GetComponent<Cell>().UnderLightLamp = true;
            GameObject.Find("fland_"+(transform.position.x-0.5f)+"_"+(transform.position.y+0.5f)).GetComponent<Cell>().UnderLightLamp = true;
            GameObject.Find("fland_"+(transform.position.x+0.5f)+"_"+(transform.position.y-0.5f)).GetComponent<Cell>().UnderLightLamp = true;
            GameObject.Find("fland_"+(transform.position.x+0.5f)+"_"+(transform.position.y+0.5f)).GetComponent<Cell>().UnderLightLamp = true;
        }
    }
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
