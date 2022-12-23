using DefaultNamespace;
using UnityEngine;

public class LaserCollider : ReceiverBoxCollider
{
    public override void Received()
    {
        GameManager.Instance.robonRespawn.RobonDie();
    }
}
