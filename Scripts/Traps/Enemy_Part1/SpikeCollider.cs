using DefaultNamespace;
using UnityEngine;

public class SpikeCollider : ReceiverBoxCollider
{
    public override void Received()
    {
        GameManager.Instance.robonRespawn.RobonDie();
    }
}
