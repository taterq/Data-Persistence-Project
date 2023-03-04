using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;



public class ScoreRank : MonoBehaviour
{
    [SerializeField]public ScoreData data=new ScoreData();
    
    public ScoreRank instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadData();
        }
        else
            Destroy(gameObject);
    }
    [System.Serializable]
    public class ScoreData
    {
        [SerializeField] public string currentPlayer = "Player";
        [SerializeField] public string[] names = new string[10];
        [SerializeField] public int[] scores = new int[10];
    }

    public void SaveData()
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "\\savedata.json", json);
    }

    public void LoadData()
    {
        string file = Application.persistentDataPath + "\\savedata.json";
        if (File.Exists(file))
        {
            string json = File.ReadAllText(file);
            data = JsonUtility.FromJson<ScoreData>(json);
        }
    }

    public void NewScore(string name, int score)
    {
        int i = 10;
        for (; i >0; --i)
        {
            if (data.scores[i-1] > score) break;
        }
        if (i < 10)
        {
            for (int j = 8; j >= i; --j)
            {
                data.names[j + 1] = data.names[j];
                data.scores[j + 1] = data.scores[j];
            }
            data.names[i] = name;
            data.scores[i] = score;
        }
        SaveData();
    }


}
