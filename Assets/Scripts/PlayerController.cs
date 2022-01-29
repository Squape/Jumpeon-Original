using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;

    public Animator playerAnimator;

    public bool canMove = true;

    [SerializeField]public AudioSource[] jumpEffects;

    // Start is called before the first frame update
    void Start()
    {
        //rb.AddForce(1)
        extraJump = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if(Mathf.Abs(rb.velocity.x) < 0.3)
		{
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (canMove == true)
        {
            float horizontalVelocity = rb.velocity.x;
            horizontalVelocity += Input.GetAxisRaw("Horizontal");
            horizontalVelocity *= Mathf.Pow(0.5f, Time.deltaTime * 10f);
            rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        }

        if(rb.velocity.x < 0)
		{
            sr.flipX = true;
		} else if(rb.velocity.x > 0)
		{
            sr.flipX = false;
		}

        /*
        OLD MOVEMENT
        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2((moveInput * velocity) * speed, rb.velocity.y);*/

        /*
        Old FLipping method
        if (facingRight == false && moveInput > 0)
        {
            sr.flipX = true;
        }
        else if (facingRight == true && moveInput < 0)
        {
            sr.flipX = false;
        }*/
    }

    void Update()
    {
        if (Mathf.Abs(rb.velocity.x) > 0.00000001)
        {
            playerAnimator.SetBool("movingX", true);
        } else
        {
            playerAnimator.SetBool("movingX", false);
        }

        if (canMove == true)
		{
            if (isGrounded)
            {
                extraJump = extraJumpValue;
            }

            /*if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y + 1) * jumpForce);
                extraJump--;
                jumpEffects[Random.Range(0, jumpEffects.Length)].Play();
            }*/
            if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
            {
                rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y + 1) * jumpForce);
                jumpEffects[Random.Range(0, jumpEffects.Length)].Play();
            }
        }

        
        /*
        OLD MOVEMENT
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {

            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }*/
    }
}