using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreDataManager : MonoBehaviour
{
    public static ScoreDataManager Instance;

    public string playerName = "Player1";
    public string highscoreName = "";
    public int highscore = 0;

    [System.Serializable]
    class SaveData
    {
        public string highscoreName;
        public int highscore;
    }

    private void Awake()
    {
        //prolly won't implement switching back to menu
        //but just in case
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);

        LoadHighScore();
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highscoreName = highscoreName;
        data.highscore = highscore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscoreName = data.highscoreName;
            highscore = data.highscore;
        }
    }
}
