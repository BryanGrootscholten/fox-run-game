using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvlSelect : MonoBehaviour
{
    public int totalLevel = 0;
    public int unlockedLevel = 1;
    public lvlButton[] levelButtons;

    private int totalPage = 0;
    private int page = 0;
    private int pageItem = 9;

    public GameObject nextButton;
    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
        CheckButton();
    }

    public void StartLevel(int level)
    {
        // show lvl info or start lvl
        //unlock for demo purposes
        if (level == unlockedLevel)
        {
            unlockedLevel += 1;
            Refresh();
        }
    }

    public void ClickNext()
    {
        page += 1;
        Refresh();
    }

    public void ClickBack()
    {
        page -= 1;
        Refresh();
    }

    public void Refresh()
    {
        totalPage = totalLevel / pageItem;
        int index = page * pageItem;
        int i = 0;
        foreach (var lvlbutton in levelButtons)
        {
            int level = index + i +1;
            if (level <= totalLevel)
            {
                lvlbutton.gameObject.SetActive(true);
                lvlbutton.Setup(level, level <= unlockedLevel);
            }
            else
            {
                lvlbutton.gameObject.SetActive(false);
            }
            i++;
        }
        //for (int i = 0; i < levelButtons.Length; i++)
        //{

        //    int level = index + i +1;
        //    Debug.Log(i.ToString() + " en " + level.ToString());
        //    if (level <= totalLevel)
        //    {
        //        levelButtons[i].gameObject.SetActive(true);
        //        levelButtons[i].Setup(level, level<=unlockedLevel);
        //    }
        //    else
        //    {
        //        levelButtons[i].gameObject.SetActive(false);
        //    }
        //}
        CheckButton();
    }

    private void CheckButton()
    {
        if (page <= 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }
        if (page >= totalPage)
        {
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(true);
        }
    }
}
