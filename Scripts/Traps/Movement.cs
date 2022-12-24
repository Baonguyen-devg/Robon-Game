using UnityEngine;

public class Movement : RepeatMonobehaviour
{
    public Transform posTarget;
    public GameObject spawnPoint;

    // true: up  false: down
    public bool direction;
    public float speed;

    protected float spaceMove = 0.5f;

    protected virtual void Update()
    {
        this.ChangeStatus();
        this.Move();
    }

    public virtual void ChangeStatus()
    {
        if (this.spawnPoint == null) return;
        SpawnPoint key = this.spawnPoint.GetComponent<SpawnPoint>();
        this.ChangeSvD(key.directionUp, key.speed);
    }

    public virtual void ChangeSvD(bool direct, float speedValue)
    {
        this.direction = direct;
        this.speed = speedValue;
    }

    protected virtual void Move()
    {
        if (this.posTarget == null || this.spawnPoint == null) return;
        float distance = Vector3.Distance(transform.position, this.posTarget.position);

        if (distance > 0.01f) this.MoveToTarget();
        else Destroy(transform.parent.gameObject);
    }

    protected virtual void MoveToTarget()
    {
        int dir = (this.direction == true) ? 1 : -1;

        if (gameObject.name == "RobonMovement") this.MoveForRobon(dir);

        Vector3 posPresent = transform.parent.position;
        Vector3 posNext = transform.parent.position + this.spaceMove * Vector3.up * dir;

        transform.parent.position = Vector3.MoveTowards(posPresent, posNext, this.speed * 0.01f);
    }

    protected virtual void  MoveForRobon(int dir)
    {
        Vector3 posPresent = transform.position;
        Vector3 posNext = transform.position + this.spaceMove * Vector3.up * dir;

        transform.position = Vector3.MoveTowards(posPresent, posNext, this.speed * 0.01f);
    }
}
