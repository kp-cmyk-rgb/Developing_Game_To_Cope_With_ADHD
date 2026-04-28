using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayPipeGame()
    {
        SceneManager.LoadScene("PipeGame");
    }

    public void PlayDiningGame()
    {
        SceneManager.LoadScene("DiningGame");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}