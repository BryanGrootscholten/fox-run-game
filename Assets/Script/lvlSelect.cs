using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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



    [RuntimeInitializeOnLoadMethod]
    static void OnApplicationStart()
    {
        //https://answers.unity.com/questions/213317/how-to-make-a-messagebox-in-unity.html it was said this message might not work in that case also redo in saveprogress
        //EditorUtility.DisplayDialog("test", "this is for testing delete this from lvlselect 23", "okay");
        // get progress from saveprogress.cs and or gamedata.cs
        
        
    }

    private void OnApplicationQuit()
    {
        SaveProgress.SaveData(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        Refresh();
        CheckButton();
    }

    void LoadData()
    {
        GameData gameData = SaveProgress.LoadData();
        if (gameData == null)
        {
            unlockedLevel = 1;
        }
        else
        {
            if (gameData.lvlsUnlocked > LvlController.currentUnlockedLvl)
            {
                LvlController.currentUnlockedLvl = gameData.lvlsUnlocked;
            }
            unlockedLevel = LvlController.currentUnlockedLvl;
        }
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
