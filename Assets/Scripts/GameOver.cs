using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;

    public void GameOverActive()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
