using UnityEngine;

public class SpawnPoint : RepeatMonobehaviour
{
    [SerializeField] protected GameObject enemySpawn;
    [SerializeField] protected int width;

    [Header("Conveyer Setting")]

    [SerializeField] protected bool isConveyer;
    public bool conveyerDirection;  //true: up   false: down
    public float speedConveyer;

    [Header("Spawn Information")]

    [SerializeField] protected int numberEnemy;
    public float speed;
    public bool directionUp;

    [SerializeField] float rateCountSub;
    [SerializeField] float rateCount;

    protected int count;
    protected float nextSpawn;
    protected int countSpawn;

    // [Header("Coin")]
    //
    // [SerializeField] protected GameObject coinPrefab;
    // [SerializeField] protected bool haveCoin;
    // [SerializeField] protected float rateHaveCoin;

    protected float timeSpawnCoin;

    [Header("Spike")]

    [SerializeField] protected bool haveSpike;

    protected Vector3 pos1, pos2, target;

    private void Start()
    {
        this.pos1 = this.FindRoot().localPosition;
        this.pos2 = this.pos1 - new Vector3(0, 0.5f, 0);
        this.target = this.pos2;
    }

    private void Update()
    {
        GameObject key = this.FindRoot().gameObject;
        this.PointMove(key);
    }

    protected virtual void SpawnEnemy()
    {
        if (this.countSpawn < this.nextSpawn) return;

        this.count = this.count + 1;
        if (this.count == this.numberEnemy) this.count = 0;

        float key = (this.count == 0) ? this.rateCount : this.rateCountSub;
        this.nextSpawn = this.countSpawn + this.width + key;
        
        this.Spawn();
    }

    protected virtual void PointMove(GameObject point)
    {
        Vector3 key = point.transform.position;

        if (point.transform.localPosition.y >= this.pos1.y) { 
            this.target = this.pos2;
            this.countSpawn = this.countSpawn + 1;

            if (this.haveSpike) this.SpawnSpike();
            this.SpawnEnemy();
        }
        if (point.transform.localPosition.y <= this.pos2.y) this.target = this.pos1;

        float dir = (this.target == this.pos1) ? 0.5f : -0.5f;
        point.transform.position = Vector3.MoveTowards(key, key + new Vector3(0, dir, 0), this.speed * 0.01f);
    }

    protected virtual void Spawn()
    {
        GameObject key = Instantiate(this.enemySpawn, transform);

        this.Move(key);
        this.CheckConveyer(key);

        //if (this.haveCoin) this.SpawnCoin(key);
    }

    protected virtual void Move(GameObject key)
    {
        key.SetActive(true);
        key.transform.position = this.FindRoot().position;

        Movement move = key.GetComponentInChildren<Movement>();
        if (move == null) return;

        move.spawnPoint = gameObject;
        move.posTarget = this.FindTarget();
    }

    // protected virtual void SpawnCoin(GameObject key)
    // {
    //     if (Time.time < this.timeSpawnCoin) return;
    //     this.timeSpawnCoin = Time.time + this.rateHaveCoin;
    //
    //     GameObject coin = Instantiate(this.coinPrefab, key.transform);
    //     coin.SetActive(true);
    // }

    protected virtual void SpawnSpike()
    {
        if (this.nextSpawn - this.countSpawn < this.width) return;

        GameObject spikePrefabs = GameObject.Find("SpikePrefab");
        GameObject key = Instantiate(spikePrefabs, transform);

        this.Move(key);
    }

    protected virtual void CheckConveyer(GameObject key)
    {
        if (this.isConveyer == false) return;
        if (this.conveyerDirection == true)
        {
            key.transform.eulerAngles = new Vector3(0, 0, 180);
            return;
        }

        int res = (this.directionUp == false) ? -1 : 1;
        Vector3 pos = key.transform.localPosition;
        pos.y = pos.y + res * (this.width - 1);

        key.transform.localPosition = pos;
    }

    protected virtual Transform FindRoot()
    {
        if (this.directionUp) return transform.GetChild(1);
        return transform.GetChild(0);
    }

    protected virtual Transform FindTarget()
    {
        if (this.directionUp) return transform.GetChild(0);
        return transform.GetChild(1);
    } 
}
