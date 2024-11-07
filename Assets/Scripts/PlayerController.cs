using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("Player Movement")]
    public float moveSpeed;
    [Header("Player Jumpforce")]
    private bool canDoubleJump;
    public float jumpForce = 5f;
    public float bounceForce;

    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Player Ground Check")]
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    [Header("Animations")]
    private Animator anim;
    private SpriteRenderer sr;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.instance.isPaused)
        {
            if (knockBackCounter <= 0)
            {
                rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);

                isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, whatIsGround);

                if (isGrounded)
                {
                    canDoubleJump = true;
                }

                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {

                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        AudioManager.instance.PlaySFX(10);

                    }
                    else
                    {
                        if (canDoubleJump)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                            AudioManager.instance.PlaySFX(10);
                            canDoubleJump = false;
                        }
                    }
                }

                if (rb.velocity.x > 0)
                {
                    sr.flipX = false;
                }
                else if (rb.velocity.x < 0)
                {
                    sr.flipX = true;
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;

                if (!sr.flipX)
                {
                    rb.velocity = new Vector2(-knockBackForce, rb.velocity.y);
                }
                else
                {
                    rb.velocity = new Vector2(knockBackForce, rb.velocity.y);
                }
            }
        }


        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        rb.velocity = new Vector2(0f, knockBackForce);
    }

    public void Bounce()
    {
        rb.velocity = new Vector2(rb.velocity.x, bounceForce);
    }
}
