using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
  public GameObject pauseMenu; // Панель меню паузы
  public Button resumeButton; // Кнопка продолжения игры
  public Button mainMenuButton; // Кнопка выхода в главное меню

  void Start()
  {
    // Инициализация кнопок
    resumeButton.onClick.AddListener(Resume);
    mainMenuButton.onClick.AddListener(MainMenu);
  }

  void Update()
  {
    // Проверка нажатия на кнопку ESC
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
    // Пауза игры
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
    // Выход в главное меню
    SceneManager.LoadScene("menu");
  }
}