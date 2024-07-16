using UnityEngine;

public class MemberActiveMenu : MonoBehaviour
{
    public GameObject f, s, t;
    public string active_cell = "";
    private void Start()
    {
        f = transform.GetChild(0).gameObject;
        s = transform.GetChild(1).gameObject;
        t = transform.GetChild(2).gameObject;
    }
    public void Sbros_menu()
    {
        gameObject.SetActive(false);
        f.SetActive(false);
        s.SetActive(false);
        t.SetActive(false);
        t.transform.GetChild(0).gameObject.SetActive(false);
        t.transform.GetChild(1).gameObject.SetActive(false);
        t.transform.GetChild(2).gameObject.SetActive(false);
    }
    public void Plug()
    {
        GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Plug();
        Sbros_menu();
    }
    public void Water()
    {
        GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Water();
        Sbros_menu();
    }
    public void Plant(string name)
    {
        GameObject.Find(active_cell).gameObject.GetComponent<Cell>().ToPlant(name);
        Sbros_menu();
    }
    public void Collect()
    {
        GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Collect();
    }
    public void Clean()
    {
        GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Clean();
    }
    public void MenuStart()
    {
        if (!GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Pluged)
        {
            f.SetActive(true);
        }
        else if (GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Plant == "")
        {
            s.SetActive(true);
        }
        else
        {
            t.SetActive(true);
            if (!GameObject.Find(active_cell).gameObject.GetComponent<Cell>().watered)
            {
                t.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (GameObject.Find(active_cell).gameObject.GetComponent<SpriteRenderer>().sprite == GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Die)
            {
                t.transform.GetChild(1).gameObject.SetActive(true);
            }
            if (GameObject.Find(active_cell).gameObject.GetComponent<Cell>().PlantReady)
            {
                t.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
}
 