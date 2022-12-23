using System;
using UnityEngine;

namespace Box
{
    public class BoxController : RepeatMonobehaviour
    {
        [Header("LoadComponent")]
        [SerializeField] protected BoxCompleted fBox;
        [SerializeField] protected  BoxCompleted pBox;
        [SerializeField] protected  BoxCompleted tBox;
        [Header("CheckBoxCompleted")] 
        public bool isFcompleted;
        public bool isPcompleted;
        public bool isTcompleted;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadFBoxCollider();
            this.LoadPBoxCollider();
            this.LoadTBoxCollider();
        }

        protected virtual void LoadFBoxCollider()
        {
            if (this.fBox != null) return;
            this.fBox = transform.Find("F").GetComponent<BoxCompleted>();
        }
        
        protected virtual void LoadPBoxCollider()
        {
            if (this.pBox != null) return;
            this.pBox = transform.Find("P").GetComponent<BoxCompleted>();
        }
        
        protected virtual void LoadTBoxCollider()
        {
            if (this.tBox != null) return;
            this.tBox = transform.Find("T").GetComponent<BoxCompleted>();
        }

        protected void Update()
        {
            CheckFPTBoxCompleted();
        }

        protected virtual void CheckFPTBoxCompleted()
        {
            if (this.fBox.isCompleted == true) this.isFcompleted = true;
            else this.isFcompleted = false;
            if (this.pBox.isCompleted == true) this.isPcompleted = true;
            else this.isPcompleted = false;
            if (this.tBox.isCompleted == true) this.isTcompleted = true;
            else this.isTcompleted = false;
        }
    }
}