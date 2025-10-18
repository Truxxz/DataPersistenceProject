using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public int m_bestScore;
    public string playerBestName;
    public string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [Serializable]
    class SaveData
    {
        public int m_bestScore;
        public string playerBestName;
        public string playerName;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.m_bestScore = m_bestScore;
        data.playerBestName = playerBestName;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            m_bestScore = data.m_bestScore;
            playerBestName = data.playerBestName;
            playerName = data.playerName;
        }
    }
}
