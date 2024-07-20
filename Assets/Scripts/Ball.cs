using UnityEngine;

public class Ball : MonoBehaviour
{
  public new Rigidbody2D rigidbody {  get; private set; }
    public float speed = 20f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
       ResetBall();
    }
    private void SetRandomTrajectory()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;
        rigidbody.AddForce(force.normalized * speed);

    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidbody.velocity = Vector2.zero;
        Invoke(nameof(SetRandomTrajectory), 1f);
    }

}
