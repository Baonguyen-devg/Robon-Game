using UnityEngine;

namespace DefaultNamespace.Traps.Enemy_Part3
{
    public class FireCollider : ReceiverBoxCollider
    {
        public override void Received()
        {
            GameManager.Instance.robonRespawn.RobonDie();
            Debug.Log("dIE");
        }
    }
}