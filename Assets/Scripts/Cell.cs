using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool UnderWaterPump;
    public bool plugged;
    public bool watered;
    public bool UnderLightLamp;
    public string Plant;
    public bool PlantReady;
    public int state;
    public float speed;
    public Sprite Unpluged;
    public Sprite Pluged;
    public Sprite Watered;
    public Sprite Hay1;
    public Sprite Hay2;
    public Sprite Hay3;
    public Sprite Cabbage1;
    public Sprite Cabbage2;
    public Sprite Cabbage3;
    public Sprite Potato1;
    public Sprite Potato2;
    public Sprite Potato3;
    public Sprite Svekla1;
    public Sprite Svekla2;
    public Sprite Svekla3;
    public Sprite Cucumber1;
    public Sprite Cucumber2;
    public Sprite Cucumber3;
    public void tRender()
    {
        if (watered) gameObject.GetComponent<SpriteRenderer>().sprite = Watered;
            else if (plugged) gameObject.GetComponent<SpriteRenderer>().sprite = Pluged;
            else gameObject.GetComponent<SpriteRenderer>().sprite = Unpluged;
            if (state == 0) transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = null;
            else if (state == 1){
                if (Plant == "hay") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Hay1;
                else if(Plant == "cabbage") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Cabbage1;
                else if(Plant == "potato") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Potato1;
                else if(Plant == "svekla") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Svekla1;
                else transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Cucumber1;
            }
            else if (state == 2){
                if (Plant == "hay") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Hay2;
                else if(Plant == "cabbage") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Cabbage2;
                else if(Plant == "potato") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Potato2;
                else if(Plant == "svekla") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Svekla2;
                else transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Cucumber2;
            }
            else {
                if (Plant == "hay") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Hay3;
                else if(Plant == "cabbage") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Cabbage3;
                else if(Plant == "potato") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Potato3;
                else if(Plant == "svekla") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Svekla3;
                else transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Cucumber3;
            }
    }
    public void ToPlant(string name)
    {
        state = 1;
        Plant = name;
        tRender();
    }
    public void Water()
    {
        watered = true;
        tRender();
    }
    public void Collect()
    {
        state = 0;
        plugged = false;
        PlantReady = false;
        Plant = "";
        tRender();
    }
    public void Plug()
    {
        plugged = true; 
        tRender(); 
    }
}
