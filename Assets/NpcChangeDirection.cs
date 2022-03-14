using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcChangeDirection : MonoBehaviour
{
    public npcMoveScript moveNpc;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            moveNpc.ChooseDirection();
        }
    }
}
