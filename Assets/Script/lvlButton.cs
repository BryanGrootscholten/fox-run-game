using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lvlButton : MonoBehaviour
{
    public lvlSelect menu;

    public Sprite lockSprite;

    public Text levelText;

    private int level = 0;

    public Button button;

    public Image image;

    public void Setup(int level, bool isUnlocked)
    {
        this.level = level;
        levelText.text = level.ToString();

        if (isUnlocked)
        {
            image.sprite = null;
            button.enabled = true;
            levelText.gameObject.SetActive(true);
        }
        else
        {
            image.sprite = lockSprite;
            button.enabled = false;
            levelText.gameObject.SetActive(false);
        }
    }

    public void OnClick()
    {
        SceneManager.LoadScene(level);
    }
}
