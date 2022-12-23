using DefaultNamespace;
using UnityEngine;

public class SpikePartThreeCollider : ReceiverBoxCollider
{
    public override void Received()
    {
        GameManager.Instance.robonRespawn.RobonDie();
    }
}
