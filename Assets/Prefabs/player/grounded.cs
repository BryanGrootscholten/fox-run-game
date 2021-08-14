using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{

    GameObject Player;
    public bool jump;

    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Ground")
        {
            jump = true;
            Player.GetComponent<playerController>().isGrounded = true;
        }    
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag != "Ground")
        {
            jump = false;
            Player.GetComponent<playerController>().isGrounded = false;
        }
    }

}
