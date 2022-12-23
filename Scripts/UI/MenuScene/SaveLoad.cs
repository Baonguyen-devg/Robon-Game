using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Player
{
    public string Name;
    public double Score, Time;
}

public class ListPlayer
{
    public List<Player> listPlayer;
}

public class SaveLoad : MonoBehaviour
{
    protected string fileName = "SavingData.json";
    protected string directionName = "/SaveData/";
    static public SaveLoad instance;

    public ListPlayer playerNow;

    private void Awake()
    {
        instance = this;
        this.SaveAndLoad();
    }

    protected virtual void SaveAndLoad() { this.LoadData(); this.SaveData(); }

    public virtual void RequestAddPalyer(string Name, double Score, double Time)
    {
        Player NewPlayer = new Player();
        NewPlayer.Name = Name; 
        NewPlayer.Score = Score; 
        NewPlayer.Time = Time;

        foreach (var player in this.playerNow.listPlayer)
        {
            if (player.Name != Name) continue;
            if (player.Score < Score || player.Score == Score && player.Time > Time)
            {
                player.Score = Score;
                player.Time = Time;
                this.SaveData();
            }
            return;
        }

        this.playerNow.listPlayer.Add(NewPlayer);
        this.SaveData();
    }

    public virtual void SaveData()
    {
        string directionPath = Application.persistentDataPath + this.directionName;

        if (!Directory.Exists(directionPath)) Directory.CreateDirectory(directionPath);

        string json = JsonUtility.ToJson(this.playerNow, true);
        File.WriteAllText(directionPath + this.fileName, json);
    }

    public virtual void LoadData()
    {
        string directionPath = Application.persistentDataPath + this.directionName;

        string filePath = directionPath + this.fileName;

        if (File.Exists(filePath)) this.playerNow = JsonUtility.FromJson<ListPlayer>(File.ReadAllText(filePath));
        else this.playerNow = new ListPlayer();
    }
}