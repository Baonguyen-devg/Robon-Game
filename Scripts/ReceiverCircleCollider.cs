using UnityEngine;

namespace DefaultNamespace.Traps
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class ReceiverCircleCollider : Receiver
    {
        [Header("Receiver")] 
        [SerializeField] protected CircleCollider2D circleCollider2D;
    
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCircleCollider();
        }

        protected virtual void LoadCircleCollider()
        {
            if (this.circleCollider2D != null) return;
            this.circleCollider2D = GetComponent<CircleCollider2D>();
            this.circleCollider2D.isTrigger = true;
        }
    }
}