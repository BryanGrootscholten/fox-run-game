using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcMoveScript : MonoBehaviour
{
    public float moveSpeed;
    private SpriteRenderer mySpriteRenderer;
    private Rigidbody2D rb;
    public GameObject test;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    public bool walkTillWall;
    private int WalkDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

    }

    void Update()
    {
        if (isWalking)
        {
            if (!walkTillWall)
            {
                walkCounter -= Time.deltaTime;
            }

            switch (WalkDirection)
            {

                case 0:
                    rb.velocity = new Vector2(moveSpeed, 0);
                    mySpriteRenderer.flipX = true;
                    break;

                case 1:
                    rb.velocity = new Vector2(-moveSpeed, 0);
                    mySpriteRenderer.flipX = false;
                    break;

            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            waitCounter -= Time.deltaTime;

            rb.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }


    }

    public void ChooseDirection()
    {
        if (WalkDirection == 0)
        {
            WalkDirection = 1;
        }
        else if (WalkDirection == 1)
        {
            WalkDirection = 0;
        }

        isWalking = true;
        walkCounter = walkTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Wall")
        {
            if (WalkDirection == 0)
            {
                WalkDirection = 1;
            }
            else if (WalkDirection == 1)
            {
                WalkDirection = 0;
            }
            walkCounter = walkTime;
        }
    }
}


