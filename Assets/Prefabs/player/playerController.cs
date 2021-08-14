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
    }

    void Jump()
    {
        actualSpeed = Input.GetAxis("Horizontal") * RunSpeed * Time.fixedDeltaTime;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }

       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {

            Destroy(collision.gameObject);

        }
    }

    
}
