using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded = false;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rb;
    Animator anime;
    //bool pJump;
    public float RunSpeed = 200;
    private float actualSpeed;
    public float jumpSpeed = 7;

    void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //pJump = false;
    }
    

    void Update()
    {
        Run();
        Jump();
        JumpReset();
    }

    void JumpReset()
    {
        if (Input.GetButtonDown("Crouch") && isGrounded == false)
        {
            float positionY = rb.position.y + 0.01f;
            rb.transform.position = new Vector3(rb.position.x, positionY, 0f);
        }
    }

    void Jump()
    {
        // input.getaxis gives huge jumpboost if you are walking and then jump 
        actualSpeed = /*Input.GetAxis("Horizontal") */ 0 * RunSpeed * Time.fixedDeltaTime;
        float jumpVel = 0;
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            jumpVel = jumpSpeed;
            rb.velocity = new Vector2(actualSpeed, rb.velocity.y + jumpVel);
        } 
        if (isGrounded == false) anime.SetBool("pJump", true);
        if (isGrounded == true) anime.SetBool("pJump", false);
    }

    void Run()
    {
        float runSpeed = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        if (runSpeed < 0) {
            anime.SetBool("pRun", true);
            mySpriteRenderer.flipX = true;
        }
        if (runSpeed > 0) {
            mySpriteRenderer.flipX = false;
            anime.SetBool("pRun", true);
        }
        if (runSpeed == 0)
        {
            anime.SetBool("pRun", false);
        }
        if (isGrounded == false){
            anime.SetBool("pRun", false);
            anime.SetBool("pJump", true);
        }
    }
    
}
