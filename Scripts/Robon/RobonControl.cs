using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class RobonControl : Movement
    {
        [SerializeField] protected Rigidbody2D rb;
        [SerializeField] float moveSpeed = 3f;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadRigidbody();
        }
        
        protected virtual void LoadRigidbody()
        {
            if (this.rb != null) return;
            this.rb = transform.parent.GetComponent<Rigidbody2D>();
            Debug.Log(transform.name + ": LoadRigidbody", gameObject);
        }

        protected override void Update()
        {
            this.Move();
        }

        protected void FixedUpdate()
        {
            this.RobonMoving();
            this.RotateToDirection();
        }

        protected virtual void RobonMoving()
        {
            rb.velocity = new Vector2(InputManager.Instance.MoveButtonVector3.x * moveSpeed,
                InputManager.Instance.MoveButtonVector3.y * moveSpeed);
        }

        protected virtual void RotateToDirection()
        {
            Vector3 directionMove = InputManager.Instance.MoveButtonVector3;
            if (directionMove == Vector3.zero) return;
            float rotationZ = Mathf.Atan2(directionMove.y, directionMove.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotationZ + 90);
        }

        

    }
}