using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;

public static class SaveProgress
{

    public static void SaveData(lvlSelect lvlSelect)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameSaveData.frun";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData gameData = new GameData(lvlSelect);
        formatter.Serialize(stream, gameData);
        stream.Close();
    }

    public static GameData LoadData()
    {
        string path = Application.persistentDataPath + "/GameSaveData.frun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            EditorUtility.DisplayDialog("LoadSaveError", "We could not find your save file either redownload application or be ok with a reset every startup", "okay");
            return null;
        }
    }
}
