using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("game");
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
