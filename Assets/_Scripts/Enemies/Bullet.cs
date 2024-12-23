using UnityEngine;

public class Bullet : MonoBehaviour, IInstatiable
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] SpriteRenderer sprite;

    private Vector3 _direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Destroy(gameObject, 3f);
    }

    private void FixedUpdate()
    {
        rb.velocity = _direction * speed;
    }

    public void SetUp(Vector3 direction)
    {
        _direction = direction;
    }

    public void SetUp(Color newColor)
    {
        sprite.color = newColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
