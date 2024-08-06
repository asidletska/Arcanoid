using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayHandler()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(1);
    }
    public void MenuHandler()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
