using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
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
    public Sprite Beet1;
    public Sprite Beet2;
    public Sprite Beet3;
    public Sprite Corn1;
    public Sprite Corn2;
    public Sprite Corn3;
    private Dictionary<string, int> map = new Dictionary<string, int>()
    {
        ["hay"] = 130,
        ["cabbage"] = 100,
        ["potato"] = 130,
        ["beet"] = 110,
        ["corn"] = 100 //��������
    };
    //private void Awake(){tRender();}

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
                else if(Plant == "beet") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Beet1;
                else transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Corn1;
            }
            else if (state == 2){
                if (Plant == "hay") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Hay2;
                else if(Plant == "cabbage") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Cabbage2;
                else if(Plant == "potato") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Potato2;
                else if(Plant == "beet") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Beet2;
                else transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Corn2;
            }
            else {
                if (Plant == "hay") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Hay3;
                else if(Plant == "cabbage") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Cabbage3;
                else if(Plant == "potato") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Potato3;
                else if(Plant == "beet") transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Beet3;
                else transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = Corn3;
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
    IEnumerator TimeLine(float StartTime)
    {
        float WaterTime = StartTime;
        bool PolFrame = true;
        while(true)
        {
            float time = Time.time;
            float delta = time - StartTime;
            float Watdelta = time - WaterTime; 
            if(delta >= map[Plant] / 2 && state == 1)
            {
                state++;
                tRender();
            }
            else if(delta >= map[Plant] && state == 2) {
                state++;
                PlantReady = true;
                tRender();
                break;
            }
            if(PolFrame && Watdelta >= 30)
            {
                watered = false;
                tRender();
                PolFrame = false;
            }
            else if(watered && !PolFrame)
            {
                PolFrame = true;
                WaterTime = time;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
