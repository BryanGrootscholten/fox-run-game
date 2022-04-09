using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int lvlsUnlocked;

    public GameData(lvlSelect lvlSelect)
    {
        lvlsUnlocked = 1;//lvlSelect.unlockedLevel;
    }
}
