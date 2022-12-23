using DefaultNamespace;
using DefaultNamespace.Traps;
using UnityEngine;

public class HacksawCollider : ReceiverCircleCollider
{
    public override void Received()
    {
        GameManager.Instance.robonRespawn.RobonDie();
    }
}
