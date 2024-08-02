using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;
    public void PauseButtonPressed()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueHandler()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);
    }
    public void RestartHandler()
    {
        FindObjectOfType<GameManager>().NewGame();
    }
    public void MenuHandler()
    {
        SceneManager.LoadScene(0);
    }
}
