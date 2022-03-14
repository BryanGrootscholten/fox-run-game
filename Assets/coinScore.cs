using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinScore : MonoBehaviour
{
    public Text text;
    public GameObject thisObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
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
            Destroy(thisObject);
        }
    }
}
