using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour
{
    public int nextLvl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LvlController.currentUnlockedLvl < SceneManager.GetActiveScene().buildIndex + 1)
        {
            LvlController.currentUnlockedLvl = SceneManager.GetActiveScene().buildIndex + 1;
        }
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(nextLvl);
        }
    }
}
