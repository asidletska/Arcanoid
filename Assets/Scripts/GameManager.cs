using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    private void NewGame()
    {
        this.score = 0;
        this.lives = 3;
        LoadLevel(1);
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
        //SceneManager.LoadScene();
        NewGame();
    }
    public void Miss()
    {
        lives--;

        if (lives > 0)
        {
            ResetLevel();
        }
        else
        {
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
