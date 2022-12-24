using DefaultNamespace;
using UnityEngine;

public class WinZoneCollider : ReceiverBoxCollider
{
    public override void Received()
    {
        GameManager.Instance.WinLevel();
    }
}
