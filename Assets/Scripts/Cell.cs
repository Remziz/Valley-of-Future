using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private GameObject Menu;
    public bool UnderWaterPump;
    public bool plugged;
    public bool watered;
    public bool UnderLightLamp;
    public string Plant;
    public bool PlantReady;
    public int state;
    public float speed;
    public bool BWater;
    public bool BLamp;
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
    public Sprite Die;
    private GameObject waterer;
    [SerializeField] private GameObject bsterP;
    private gMan gman;
    private Dictionary<string, int> map = new Dictionary<string, int>()
    {
        ["hay"] = 130,
        ["cabbage"] = 100,
        ["potato"] = 130,
        ["beet"] = 110,
        ["corn"] = 100 //��������
    };
    private GameObject plantsprite;
    private void Awake()
    {
        Menu = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        gman = FindObjectOfType<gMan>();
        plantsprite = transform.GetChild(0).gameObject;
    }
    public void tRender()
    {
        if (watered && plugged) gameObject.GetComponent<SpriteRenderer>().sprite = Watered;
            else if (plugged) gameObject.GetComponent<SpriteRenderer>().sprite = Pluged;
            else gameObject.GetComponent<SpriteRenderer>().sprite = Unpluged;
            if (state == 0) plantsprite.GetComponent<SpriteRenderer>().sprite = null;
            else if (state == 1){
                if (Plant == "hay") plantsprite.GetComponent<SpriteRenderer>().sprite = Hay1;
                else if(Plant == "cabbage") plantsprite.GetComponent<SpriteRenderer>().sprite = Cabbage1;
                else if(Plant == "potato") plantsprite.GetComponent<SpriteRenderer>().sprite = Potato1;
                else if(Plant == "beet") plantsprite.GetComponent<SpriteRenderer>().sprite = Beet1;
                else plantsprite.GetComponent<SpriteRenderer>().sprite = Corn1;
            }
            else if (state == 2){
                if (Plant == "hay") plantsprite.GetComponent<SpriteRenderer>().sprite = Hay2;
                else if(Plant == "cabbage") plantsprite.GetComponent<SpriteRenderer>().sprite = Cabbage2;
                else if(Plant == "potato") plantsprite.GetComponent<SpriteRenderer>().sprite = Potato2;
                else if(Plant == "beet") plantsprite.GetComponent<SpriteRenderer>().sprite = Beet2;
                else plantsprite.GetComponent<SpriteRenderer>().sprite = Corn2;
            }
            else {
                if (Plant == "hay") plantsprite.GetComponent<SpriteRenderer>().sprite = Hay3;
                else if(Plant == "cabbage") plantsprite.GetComponent<SpriteRenderer>().sprite = Cabbage3;
                else if(Plant == "potato") plantsprite.GetComponent<SpriteRenderer>().sprite = Potato3;
                else if(Plant == "beet") plantsprite.GetComponent<SpriteRenderer>().sprite = Beet3;
                else plantsprite.GetComponent<SpriteRenderer>().sprite = Corn3;
            }
    }
    public void ToPlant(string name)
    {
        state = 1;
        Plant = name;
        watered = true;
        StartCoroutine(TimeLine(Time.time));
        tRender();
    }
    public void SetWaterer()
    {
        BWater = true;
        waterer = Instantiate(bsterP);
        waterer.transform.position = transform.position;
        waterer.GetComponent<Booster>().Init(gameObject.name);
    }
    public void underBoost(bool value){
        UnderWaterPump = value;
        watered = value;
        tRender();
    }
    public void Water()
    {
        watered = true;
        tRender();
    }
    public void Collect()
    {
        if (Plant == "hay") gman.mnChange(20);
        else if(Plant == "cabbage") gman.mnChange(40);
        else if(Plant == "potato") gman.mnChange(80);
        else if(Plant == "beet") gman.mnChange(100);
        else gman.mnChange(120);
        state = 0;
        plugged = false;
        watered = false;
        PlantReady = false;
        Plant = "";
        tRender();
    }
    public void Plug()
    {
        plugged = true; 
        tRender(); 
    }
    public void Clean(){
        plugged = false;
        watered = false;
        if (BWater) waterer.GetComponent<Booster>().Kill(gameObject.name); Destroy(waterer); UnderWaterPump = false;
        BLamp = false;
        BWater = false;
        Plant = "";
        state = 0;
        tRender();
    }
    IEnumerator TimeLine(float StartTime)
    {
        float WaterTime = StartTime;
        bool NoPolFrame = false;
        float NoWaterTime = 0f;
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
            if (UnderWaterPump)
            {
                WaterTime = Time.time;
            }
            else if(delta >= map[Plant] && state == 2) {
                state++;
                PlantReady = true;
                tRender();
                yield break;
            }
            if(PolFrame && Watdelta >= 30)
            {
                watered = false;
                tRender();
                PolFrame = false;
                NoPolFrame = true;
                NoWaterTime = Time.time;
            }
            else if(watered && !PolFrame)
            {
                PolFrame = true;
                WaterTime = time;
                NoPolFrame = false;
                NoWaterTime = 0;
            }
            if(time - NoWaterTime > 30 && NoPolFrame)
            {
                NoPolFrame = false;
                plantsprite.GetComponent<SpriteRenderer>().sprite = Die;
                yield break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnMouseDown()
    {
        Menu.GetComponent<MemberActiveMenu>().Sbros_menu();
        gameObject.GetComponent<Animator>().SetTrigger("Go");
        Menu.GetComponent<MemberActiveMenu>().active_cell = gameObject.name;
        Menu.GetComponent<MemberActiveMenu>().MenuStart();
    }
}
