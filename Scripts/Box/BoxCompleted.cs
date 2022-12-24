using Bin;
using DefaultNamespace;
using UnityEngine;

namespace Box
{
    public class BoxCompleted : ReceiverBoxCollider
    {
        public bool isCompleted = false;
        [SerializeField] protected BinController binController;
        [SerializeField] protected RobonCollect robonCollect;
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadBinController();
            this.LoadRobonCollect();
        }

        protected virtual void LoadBinController()
        {
            if (this.binController != null) return;
            this.binController = GameObject.Find("BinManager").GetComponent<BinController>();
        }
        protected virtual void LoadRobonCollect()
        {
            if (this.robonCollect != null) return;
            this.robonCollect = GameObject.Find("RobonCollect").GetComponent<RobonCollect>();
        }
        public override void Received()
        {
            if(this.binController.isFbinCollected && gameObject.name == "F" || this.binController.isPbinCollected && gameObject.name == "P" || this.binController.isTbinCollected && gameObject.name == "T")
            {
                isCompleted = true;
                Debug.Log(transform.name + "BoxComplted",gameObject.transform);
                this.robonCollect.isCollected = false;
                this.RestoreCollected();
                GameManager.Instance.robonRespawn.RobonCompleteBox();
                //GameManager.Instance.robonScore.Collect(GameManager.Instance.BoxScore);

                //Do animaiton
                this.gameObject.SetActive(false);
            }
        }

        protected virtual void RestoreCollected()
        {
            if (binController.isFbinCollected) binController.isFbinCollected = false;
            if (binController.isPbinCollected) binController.isPbinCollected = false;
            if (binController.isTbinCollected) binController.isTbinCollected = false;
        }
    }
}