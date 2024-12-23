using UnityEngine;

public class LookTarget : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb2d;
    [SerializeField] float speed;
    private bool isLooking = false;

    Vector2 startPos;

    private void Update()
    {
        if (InputHandler.Instance.IsLooking() && !isLooking)
        {
            isLooking = true;
            transform.position = startPos;
        }
        else if (!InputHandler.Instance.IsLooking() && isLooking)
        {
            isLooking = false;
            transform.position = startPos;
        }        
    }

    private void FixedUpdate()
    {
        if (isLooking)
        {
            rb2d.velocity = new Vector2(speed * InputHandler.Instance.Move().x, 0f);
        }
        else
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
