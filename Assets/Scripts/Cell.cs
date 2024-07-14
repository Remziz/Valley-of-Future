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
    public bool Render;
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
    //private Dictionary<string, Dictionary<int, Sprite>> map = new Dictionary<string, Dictionary<int, Sprite>>()
    //{
        //["Hay"] = new Dictionary<int, Sprite>()
        //{
            //[1] = Hay1,
            //[2] = Hay2,
            //[3] = Hay3
        //},
        //["Cabbage"] = new Dictionary<int, Sprite>()
        //{
            //[1] = Cabbage1,
            //[2] = Cabbage2,
            //[3] = Cabbage3
        //},
        //["Potato"] = new Dictionary<int, Sprite>()
        //{
            //[1] = Potato1,
            //[2] = Potato2,
            //[3] = Potato3
        //}
    //};

    public void tRender()
    {
        Render = true;
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
    private void Update()
    {
        if (Render)
        {
            if (watered) gameObject.GetComponent<SpriteRenderer>().sprite = Watered;
            else if (plugged) gameObject.GetComponent<SpriteRenderer>().sprite = Pluged;
            else gameObject.GetComponent<SpriteRenderer>().sprite = Unpluged;
            if (state == 0) transform.GetChild(0).gameObject.GetComponentInParent<SpriteRenderer>().sprite = null;
            else transform.GetChild(0).GetComponentInParent<SpriteRenderer>().sprite = map[Plant][state];
            Render = false;
        }
    }

}
