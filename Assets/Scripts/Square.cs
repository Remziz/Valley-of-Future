using UnityEngine;

public class Square : MonoBehaviour
{
    public bool UnderWaterPump;
    public bool plugged;
    public bool watered;
    public bool UnderLightLamp;
    public string Plant;
    public bool PlantReady;
    public int state;
    public float speed;
    private bool Render;
    public Sprite Unpluged;
    public Sprite Pluged;
    public Sprite Watered;
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
            Render = false;
        }
    }

}
