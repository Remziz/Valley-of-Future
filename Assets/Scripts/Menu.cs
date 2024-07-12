using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
