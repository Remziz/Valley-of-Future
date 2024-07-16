using UnityEngine;

public class MemberActiveMenu : MonoBehaviour
{
    public string active_cell = "";
    public void Sbros_menu()
    {
        if (active_cell != "") GameObject.Find(active_cell).GetComponent<Cell>().CloseMenu();
    }
    private void OnMouseDown()
    {
        Sbros_menu();
    }
}
