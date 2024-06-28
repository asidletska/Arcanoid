using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer {  get; private set; }
    public Sprite[] states;
    public int health {  get; private set; }
    public int points = 100;
    public bool unbreakable;

    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        ResetBrick();
    }
    public void ResetBrick()
    {
        gameObject.SetActive(true);
        if (!unbreakable)
        {
            health = states.Length;
            SpriteRenderer.sprite = states[health - 1];
        }
    }
    private void Hit()
    {
        if (unbreakable)
        {
            return;
        }
        health--;
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            SpriteRenderer.sprite = states[health - 1];
        }
        FindObjectOfType<GameManager>().Hit(this);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }
    }
        
    
}
