using DefaultNamespace.Traps;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ReceiverBoxCollider : Receiver
{
    [Header("Receiver")] 
    [SerializeField] protected BoxCollider2D boxCollider2D;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.boxCollider2D != null) return;
        this.boxCollider2D = GetComponent<BoxCollider2D>();
        this.boxCollider2D.isTrigger = true;
    }
}
