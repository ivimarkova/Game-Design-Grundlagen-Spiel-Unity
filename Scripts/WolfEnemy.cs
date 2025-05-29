
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float aggroRange;
    public float speed;
    public float jumpCooldown;
    public float jumpForce;
    public Animations animations;

    float lastJump;

    Animator animator;

    private void Awake()
    {

        animator = GetComponent<Animator>();

    }

    void Update()
    {

        if (Vector2.Distance(player.transform.position, transform.position) < aggroRange)
        {

            if (player.transform.position.x < transform.position.x)
            {

                transform.Translate(Vector2.left * Time.deltaTime * speed);

                animator.Play(animations.goLeft.name);

            }
            else
            {

                transform.Translate(Vector2.right * Time.deltaTime * speed);

                animator.Play(animations.goRight.name);

            }

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


    [System.Serializable]
    public struct Animations
    {

        public AnimationClip goLeft;
        public AnimationClip goRight;

    }

}