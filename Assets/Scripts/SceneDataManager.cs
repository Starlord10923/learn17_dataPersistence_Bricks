using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneDataManager : MonoBehaviour
{
    public static SceneDataManager Instance;
    public string playerName;
    public int bestScore=0;
    public int currentScore=0;
    void Awake()
    {
        if(Instance!=null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData{
        public string playerName;
        public int score;
    }
    public void SavePlayerData(){
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile.json",json);
    }
    public void LoadPlayerData(){
        string path = Application.persistentDataPath + "/saveFile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            bestScore = data.score;
        }
    }
}
