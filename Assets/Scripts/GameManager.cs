using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent BallMiss;
    public Ball ball {  get; private set; }
    public Paddle paddle { get; private set; }
    public Brick[] bricks { get; private set; }
    public int level = 1;
    public int score = 0;
    public int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void Start()
    {
        NewGame();
    }
    public void NewGame()
    {
        score = 0;
        lives = 3;
        LoadLevel(level);
    }
    private void LoadLevel (int level)
    {
        this.level = level;
        SceneManager.LoadScene("Level" + level) ;

    }
    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        bricks = FindObjectsOfType<Brick>();
    }
    private void ResetLevel()
    {
        ball.ResetBall();
        paddle.ResetPaddle();

       /* for (int i = 0; i < bricks.Length; i++)
        {
            bricks[i].ResetBrick();
        }*/
    }
    private void GameOver()
    {
        NewGame();
    }
    public void Miss()
    {
        lives--;

        if (lives > 0)
        {
            BallMiss.Invoke();
            ResetLevel();
        }
        else
        {
            BallMiss.Invoke();
            GameOver();
        }

    }
    public void Hit(Brick brick)
    {
        score += brick.points;
        if (Cleared())
        {
            LoadLevel(level + 1);
        }
    }
    private bool Cleared()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if (bricks[i].gameObject.activeInHierarchy && !bricks[i].unbreakable)
            {
                return false;
            }
        }
        return true;
    }
}
