using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    public float moveSpeed;
    [Header("Player Jumpforce")]
    private bool canDoubleJump;
    public float jumpForce = 5f;

    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Player Ground Check")]
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    [Header("Animations")]
    private Animator anim;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
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

            }
            else
            {
                if (canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x));
        //anim.SetBool("isGrounded", isGrounded);

    }
}
