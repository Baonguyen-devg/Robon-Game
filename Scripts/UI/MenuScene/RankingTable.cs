using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingTable : MonoBehaviour
{
    [Header("BoxInformation")]
    public int numberBox;
    public float distance;
    public Transform entryDetailPlayer;

    [Header("ListManager")]
    protected List<Player> entryPlayerList;
    protected List<Transform> transList;
    [SerializeField] protected List<Player> ListPl;

    private void Start()
    {
        this.entryPlayerList = new List<Player>();
        this.transList = new List<Transform>();
        this.UpdateDataBox();
    }

    public void UpdateDataBox()
    {
        SaveLoad.instance.LoadData();
        if (this.transList.Count != 0) this.transList.Clear(); 
        if (this.entryPlayerList.Count != 0) this.entryPlayerList.Clear();

        this.ListPl = new List<Player>();
        this.ListPl = SaveLoad.instance.playerNow.listPlayer;

        foreach (var Element in ListPl) this.entryPlayerList.Add(Element);

        for (int i = 0; i < this.entryPlayerList.Count; i++)
        for (int j = i + 1; j < this.entryPlayerList.Count; j++)
        {
            double x = this.entryPlayerList[i].Score;
            double y = this.entryPlayerList[j].Score;

            if (x > y || x == y && this.entryPlayerList[i].Time < this.entryPlayerList[j].Time) continue;
            this.Swap(i, j);
        }

        for (int i = 0; i < Mathf.Min(this.entryPlayerList.Count, this.numberBox); i++)
            this.CreateBoxForPlayer(this.entryPlayerList[i], this.transList);
    }

    protected void Swap(int i, int j)
    {
        Player Between = this.entryPlayerList[i];
        this.entryPlayerList[i] = this.entryPlayerList[j];
        this.entryPlayerList[j] = Between;
    }

    protected void CreateBoxForPlayer(Player Player, List<Transform> transformList)
    {
        Transform entryTransform = Instantiate(this.entryDetailPlayer, transform);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -this.distance * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        string NamePlayer = Player.Name;
        entryTransform.Find("NamePlayer").GetComponent<Text>().text = NamePlayer;

        string ScorePlayer = Player.Score.ToString();
        entryTransform.Find("ScorePlayer").GetComponent<Text>().text = ScorePlayer;

        string RankPlayer = (transformList.Count + 1).ToString();
        entryTransform.Find("RankPlayer").GetComponent<Text>().text = RankPlayer;

        string TimePlayer = Player.Time.ToString("F");
        entryTransform.Find("TimePlayer").GetComponent<Text>().text = TimePlayer;

        this.transList.Add(entryTransform);
    }
}
