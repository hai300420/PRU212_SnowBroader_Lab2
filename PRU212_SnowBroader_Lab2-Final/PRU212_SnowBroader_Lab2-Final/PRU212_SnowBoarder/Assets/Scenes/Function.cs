using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroFunction : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public void IntroScene()
    {
        SceneManager.LoadScene("Intro");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
    }
    public void Continue()
    {
        pauseMenu.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

