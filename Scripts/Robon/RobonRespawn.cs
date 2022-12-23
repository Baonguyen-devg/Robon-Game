using UnityEngine;

namespace DefaultNamespace
{
    public class RobonRespawn : RepeatMonobehaviour
    {
        [SerializeField] protected Transform robonTransform;
        [SerializeField] protected GameObject robonRespawnPoint;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadRobon();
            this.LoadRobonRespawnPoint();
        }
        
        protected virtual void LoadRobonRespawnPoint()
        {
            if (this.robonRespawnPoint != null) return;
            this.robonRespawnPoint = GameObject.Find("RobonRespawnPoint");
        }
        protected virtual void LoadRobon()
        {
            if (this.robonTransform != null) return;
            this.robonTransform = transform.parent;
        }
        
        public virtual void RobonDie()
        {
            if (GameManager.Instance.IsLose()) return;
            this.robonTransform.position = robonRespawnPoint.transform.position;
            GameManager.Instance.robonHealth.Deduct(1);
            GameManager.Instance.timeBar.SetMaxTime(GameManager.Instance.TimeMax);
            this.RespawnBin();
        }
        
        
        public virtual void RobonCompleteBox()
        {
            if (GameManager.Instance.IsLose()) return;
            this.robonTransform.position = robonRespawnPoint.transform.position;
            GameManager.Instance.timeBar.SetMaxTime(GameManager.Instance.TimeMax);
        }

        protected virtual void RespawnBin()
        {
            GameManager.Instance.robonCollect.isCollected = false;
            
            if (GameManager.Instance.binController.isFbinCollected == true)
            {
                GameManager.Instance.binController.fBin.gameObject.SetActive(true);
                GameManager.Instance.binController.isFbinCollected = false;
            }

            if (GameManager.Instance.binController.isPbinCollected == true)
            {
                GameManager.Instance.binController.pBin.gameObject.SetActive(true);
                GameManager.Instance.binController.isPbinCollected = false;
            }

            if (GameManager.Instance.binController.isTbinCollected == true)
            {
                GameManager.Instance.binController.tBin.gameObject.SetActive(true);
                GameManager.Instance.binController.isTbinCollected = false;
            }
        }
        
        
    }
}