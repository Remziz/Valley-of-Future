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
        f = transform.GetChild(0).gameObject;
        s = transform.GetChild(1).gameObject;
        t = transform.GetChild(2).gameObject;
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
        Sbros_menu();
    }
    public void Clean()
    {
        GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Clean();
        Sbros_menu();
    }
    public void SetWaterer()
    {
        GameObject.Find(active_cell).gameObject.GetComponent<Cell>().SetBooster(true);
        Sbros_menu();
    }
    public void SetLamp()
    {
        GameObject.Find(active_cell).gameObject.GetComponent<Cell>().SetBooster(false);
        Sbros_menu();
    }

    public void MenuStart()
    {
        gameObject.SetActive(true);
        if (!GameObject.Find(active_cell).gameObject.GetComponent<Cell>().plugged && !GameObject.Find(active_cell).gameObject.GetComponent<Cell>().BWater && !GameObject.Find(active_cell).gameObject.GetComponent<Cell>().BLamp)
        {
            f.SetActive(true);
        }
        else if (GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Plant == "" && !GameObject.Find(active_cell).gameObject.GetComponent<Cell>().BWater && !GameObject.Find(active_cell).gameObject.GetComponent<Cell>().BLamp)
        {
            s.SetActive(true);
        }
        else
        {
            t.SetActive(true);
            if (GameObject.Find(active_cell).gameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite == GameObject.Find(active_cell).gameObject.GetComponent<Cell>().Die | GameObject.Find(active_cell).gameObject.GetComponent<Cell>().BWater | GameObject.Find(active_cell).gameObject.GetComponent<Cell>().BLamp)
            {
                t.transform.GetChild(1).gameObject.SetActive(true);
            }

            else if (GameObject.Find(active_cell).gameObject.GetComponent<Cell>().PlantReady)
            {
                t.transform.GetChild(2).gameObject.SetActive(true);
            }
            else if (!GameObject.Find(active_cell).gameObject.GetComponent<Cell>().watered)
            {
                t.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
 