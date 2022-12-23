using DefaultNamespace;
using DefaultNamespace.Traps;
using UnityEngine;

public class Conveyer : MonoBehaviour
{
    [SerializeField] protected bool havePlayer;
    [SerializeField] protected GameObject player;
    [SerializeField] protected RobonControl robonControl;
    private void Awake()
    {
        this.player = GameObject.Find("Robon");
        if (this.CheckNull()) return;
        this.robonControl = this.player.GetComponentInChildren<RobonControl>();
    }

    private void Update()
    {
        if (this.CheckNull()) return;
        if (this.havePlayer)
        {
            SpawnPoint key = GetComponentInParent<SpawnPoint>();
            this.player.transform.SetParent(this.transform);

            this.robonControl.posTarget = GetComponentInChildren<Movement>().posTarget;
            this.robonControl.ChangeSvD(key.conveyerDirection, key.speedConveyer);

        }
        else
        {
            this.player.transform.SetParent(null);
            this.robonControl.posTarget = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            this.havePlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            this.havePlayer = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            this.havePlayer = true;
    }

    protected bool CheckNull()
    {
        if (this.player == null) return true;
        return false;
    }
}
