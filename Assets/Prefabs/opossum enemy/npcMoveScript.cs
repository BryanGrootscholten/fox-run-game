using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMoveScript : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    private SpriteRenderer mySpriteRenderer;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();


        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

    }

    void Update()
    {
        if (isWalking)
        {
            walkCounter -= Time.deltaTime;



            switch (WalkDirection)
            {

                case 0:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    mySpriteRenderer.flipX = true;
                    break;

                case 1:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
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

            myRigidbody.velocity = Vector2.zero;

            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }


    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 2);
        isWalking = true;
        walkCounter = walkTime;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}


