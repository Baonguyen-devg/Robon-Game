using DefaultNamespace;
using UnityEngine;

namespace Bin
{
    public class BinCollect : ReceiverBoxCollider
    {
        public bool isColleted = false;
        [SerializeField] protected RobonCollect robonCollect;
        [SerializeField] protected BinController binController;
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadRobonCollect();
            this.LoadBinController();
        }
        protected virtual void LoadRobonCollect()
        {
            if (this.robonCollect != null) return;
            this.robonCollect = GameObject.Find("RobonCollect").GetComponent<RobonCollect>();
        }
        protected virtual void LoadBinController()
        {
            if (this.binController != null) return;
            this.binController = transform.parent.GetComponent<BinController>();
        }
        protected override void LoadBoxCollider()
        {
            base.LoadBoxCollider();
            this.boxCollider2D.isTrigger = false;
        }

        public override void Received()
        {
            if (robonCollect.isCollected == false)
            {
                robonCollect.isCollected = true;
                gameObject.SetActive(false);
                //DoAnimation
                this.isColleted = true;
                SetIsCollectedBinController();
            }
        }
        
        protected virtual void SetIsCollectedBinController()
        {
            if (this.isColleted == true && gameObject.name == "F") binController.isFbinCollected = true;
            if (this.isColleted == true && gameObject.name == "P") binController.isPbinCollected = true;
            if (this.isColleted == true && gameObject.name == "T") binController.isTbinCollected = true;
        }
    }
}