using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
  public GameObject pauseMenu;
  public Button resumeButton;
  public Button mainMenuButton;

  void Start()
  {
    // Инициализация кнопок
    resumeButton.onClick.AddListener(Resume);
    mainMenuButton.onClick.AddListener(MainMenu);
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      if (Time.timeScale == 1)
      {
        Pause();
      }
      else
      {
        Resume();
      }
    }
  }

  public void Pause()
  {
    Time.timeScale = 0;
    pauseMenu.SetActive(true);
  }

  public void Resume()
  {
    // Продолжение игры
    Time.timeScale = 1;
    pauseMenu.SetActive(false);
  }
  public void MainMenu()
  {
    SceneManager.LoadScene("menu");
  }
}