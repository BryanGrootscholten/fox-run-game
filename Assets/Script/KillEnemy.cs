using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillEnemy : MonoBehaviour
{
    public GameObject enemy;
    public Text text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerFeet")
        {
            string currentvalue = "";
            int newScoreInt;
            foreach (var letter in text.text)
            {
                if (int.TryParse(letter.ToString(), out newScoreInt))
                {
                    currentvalue = currentvalue + letter;
                }
            }
            newScoreInt = int.Parse(currentvalue);
            newScoreInt++;
            text.text = "Score: " + newScoreInt.ToString();
            Destroy(enemy);
        }
    }
}
