using UnityEngine;
using System.IO;

public class ScoreLevel
{
    public float number;
}

public class SaveScore : MonoBehaviour
{
    [SerializeField] protected string fileName = "SavingScore.json";
    [SerializeField] protected string directionFile = "/SaveData/";
    public ScoreLevel score;
    static public SaveScore instance;

    private void Awake()
    {
        instance = this;
        this.LoadData();
        this.SaveData();
    }

    public virtual void ChangeValueScore(float Score)
    {
        this.score.number = Score;
        this.SaveData();
    }

    public virtual void SaveData()
    {
        string directionPath = Application.persistentDataPath + this.directionFile;

        if (Directory.Exists(directionPath) == false) Directory.CreateDirectory(directionPath);

        string json = JsonUtility.ToJson(this.score, true);
        File.WriteAllText(directionPath + this.fileName, json);
    }

    public virtual void LoadData()
    {
        string directionPath = Application.persistentDataPath + this.directionFile;

        string filePath = directionPath + this.fileName;

        if (File.Exists(filePath)) this.score = JsonUtility.FromJson<ScoreLevel>(File.ReadAllText(filePath));
        else this.score.number = 0;
    }
}
