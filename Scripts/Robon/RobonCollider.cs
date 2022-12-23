using System;
using DefaultNamespace;
using DefaultNamespace.Traps;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class RobonCollider : RepeatMonobehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected BoxCollider2D boxCollider;
    [SerializeField] protected RobonControl robonControl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
        this.LoadCollider();
        this.LoadRobonControl();
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody2D>();
        this.rb.gravityScale = 0;
        this.rb.freezeRotation = true;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }
    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.boxCollider.size = new Vector3(0.4f, 0.4f, 1);
        Debug.Log(transform.name + ": LoadBoxCollider", gameObject);
    }
    
    protected virtual void LoadRobonControl()
    {
        if (this.robonControl != null) return;
        this.robonControl = GetComponentInChildren<RobonControl>();
    }

    protected void OnTriggerEnter2D(Collider2D col)
    {
        Send(col.transform);
    }

    protected void OnCollisionEnter2D(Collision2D col)
    {
        Send(col.transform);
    }

    public virtual void Send(Transform obj)
    {
        Receiver receiver = obj.GetComponent<Receiver>();
        if (receiver == null) return;
        this.Send(receiver);
    }
    
    public virtual void Send(Receiver receiver)
    {
        receiver.Received();
    }
}
