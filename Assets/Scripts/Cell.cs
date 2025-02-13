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
        private Dictionary<string, int> buycost = new Dictionary<string, int>()
    {
        ["hay"] = 20,
        ["cabbage"] = 30,
        ["potato"] = 70,
        ["beet"] = 100,
        ["corn"] = 140
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
        if(gman.money>=buycost[name]){
        gman.mnChange(-buycost[name]);
        state = 1;
        Plant = name;
        watered = true;
        StartCoroutine(TimeLine(Time.time));
        tRender();
        }
    }
    public void SetWaterer()
    {
        if(gman.money>=200){
            gman.mnChange(-200);
            BWater = true;
            waterer = Instantiate(bsterP);
            waterer.transform.position = transform.position;
            waterer.GetComponent<Booster>().Init(gameObject.name, true);
        }
    }
    public void SetLamp()
    {
        if (gman.money>=400){
            gman.mnChange(-400);
            BLamp = true;
            waterer = Instantiate(bsterP);
            waterer.transform.position = transform.position;
            waterer.GetComponent<Booster>().Init(gameObject.name, false);
        }
    }
    public void underBoost(bool value, bool wtr){
        if (wtr) UnderWaterPump = value;
        if (wtr) watered = value;
        else
        {
            UnderLightLamp = value;
        }
        tRender();
    }
    public void Water()
    {
        watered = true;
        tRender();
    }
    public void Collect()
    {
        gman.mnChange(buycost[Plant]*3/2);
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
        if (UnderWaterPump) watered = true;
        tRender(); 
    }
    public void Clean(){
        plugged = false;
        watered = false;
        if (BWater){waterer.GetComponent<Booster>().Kill(gameObject.name); Destroy(waterer);}
        if (BLamp){waterer.GetComponent<Booster>().Kill(gameObject.name); Destroy(waterer);}
        BLamp = false;
        BWater = false;
        Plant = "";
        state = 0;
        tRender();
    }
    IEnumerator TimeLine(float StartTime)
    {
        float rt = map[Plant];
        float WaterTime = StartTime;
        bool NoPolFrame = false;
        float NoWaterTime = 0f;
        bool PolFrame = true;
        while(true)
        {
            float time = Time.time;
            float delta = time - StartTime;
            float Watdelta = time - WaterTime; 
            if(delta >= rt / 2 && state == 1)
            {
                state++;
                tRender();
            }
            if (UnderWaterPump)
            {
                WaterTime = Time.time;
            }
            if (!UnderLightLamp && rt != map[Plant])
            {
                rt = map[Plant];
            }
            if (UnderLightLamp && rt == map[Plant])
            {
                rt *= 0.8f;
            }
            else if(delta >= rt && state == 2) {
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
    public void MouseDown()
    {
        Menu.GetComponent<MemberActiveMenu>().Sbros_menu();
        gameObject.GetComponent<Animator>().SetTrigger("Go");
        Menu.GetComponent<MemberActiveMenu>().active_cell = gameObject.name;
        Menu.GetComponent<MemberActiveMenu>().MenuStart();
    }
}
