using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float aggroRange;
    public float speed;
    public float jumpCooldown;
    public float jumpForce;

    float lastJump;

    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < aggroRange)
        {
            // movement and flip
            if (player.transform.position.x < transform.position.x)
            {
                transform.Translate(Vector2.left * Time.deltaTime * speed);
                spriteRenderer.flipX = true; // left
            }
            else
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                spriteRenderer.flipX = false; //right
            }

            animator.Play("Run"); //animation for running

            // jump
            if (Time.time > lastJump + jumpCooldown)
            {
                lastJump = Time.time;
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        else
        {
            animator.Play("Idle");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<PlayerMovement>())
        {
            collision.collider.GetComponent<PlayerMovement>().Die();
        }
    }
}
