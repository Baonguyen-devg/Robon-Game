using DefaultNamespace;
using DefaultNamespace.Traps;
using UnityEngine;

public class CoinCollider : ReceiverCircleCollider
{
    public override void Received()
    {
        //GameManager.Instance.robonScore.Collect(GameManager.Instance.CoinScore);
        Debug.Log("coin");
        Destroy(gameObject);
    }
}
