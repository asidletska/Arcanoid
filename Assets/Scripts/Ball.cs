using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;

    public UnityEvent Brick;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;

        CancelInvoke();
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2(Random.Range(-1f, 1f), -1f);
        rb.AddForce(force.normalized * speed, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Brick")
        {
            Brick.Invoke();
        }
    }
}
