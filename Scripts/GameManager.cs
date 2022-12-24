using Bin;
using Box;
using DefaultNamespace.UI;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameManager : RepeatMonobehaviour
    {
        private static GameManager instance;
        public static GameManager Instance { get => instance; }
        [Header("SettingData")]
        [SerializeField] protected float timeMax = 30f;
        public float TimeMax { get => timeMax; }
        //[SerializeField] protected int coinScore = 10;
        //public int CoinScore { get => coinScore; }
        //[SerializeField] protected int boxScore = 50;
        //public int BoxScore { get => boxScore; }
        [Header("LoadComponents")]
        //public RobonCollect robonCollect;
        //public BinController binController;
        //[SerializeField] protected BoxController boxController;
        public TimeBar timeBar;
        //public RobonScore robonScore;
        public RobonRespawn robonRespawn;
        public RobonHealth robonHealth;
        public Transform loseGameUI;
        public Transform winLevelUI;
        private bool isWin = false;
        
        protected override void Awake()
        {
            Application.targetFrameRate = 60;
            if (GameManager.instance != null) Debug.LogError("Only 1 GameManager can exist!");
            GameManager.instance = this;    
        }
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTimeBar();
            // this.LoadRobonCollet();
            // this.LoadBinController();
            // this.LoadBoxCompleted();
            // this.LoadRobonScore();
            this.LoadRobonRespawn();
            this.LoadRobonHeath();
        }

        protected virtual void LoadTimeBar()
        {
            if (this.timeBar != null) return;
            this.timeBar = GameObject.Find("TimeBar").GetComponent<TimeBar>();
        }
        
        protected virtual void LoadRobonHeath()
        {
            if (this.robonHealth != null) return;
            this.robonHealth = GameObject.Find("RobonHealth").GetComponent<RobonHealth>();
        }
        // protected virtual void LoadRobonCollet()
        // {
        //     if (this.robonCollect != null) return;
        //     this.robonCollect = GameObject.Find("RobonCollect").GetComponent<RobonCollect>();
        // }
        
        // protected virtual void LoadBoxCompleted()
        // {
        //     if (this.boxController != null) return;
        //     this.boxController = GameObject.Find("BoxManager").GetComponent<BoxController>();
        // }
        
        // protected virtual void LoadBinController()
        // {
        //     if (this.binController != null) return;
        //     this.binController = GameObject.Find("BinManager").GetComponent<BinController>();
        // }
        
        // protected virtual void LoadRobonScore()
        // {
        //     if (this.robonScore != null) return;
        //     this.robonScore = GameObject.Find("RobonScore").GetComponent<RobonScore>();
        // }
        
        protected virtual void LoadRobonRespawn()
        {
            if (this.robonRespawn != null) return;
            this.robonRespawn = GameObject.Find("RobonRespawn").GetComponent<RobonRespawn>();
        }

        private void FixedUpdate()
        {
            this.isWinLevel();
            this.LoseGame();
        }
        
        
        protected virtual void isWinLevel()
        {
            if (isWin == true)
            {
                winLevelUI.gameObject.SetActive(true);                
                //DoAnimationWinGame
            }
        }

        public void WinLevel()
        {
            this.isWin = true;
        }

        protected virtual void LoseGame()
        {
            if (IsLose() && this.loseGameUI != null)
            {
                loseGameUI.gameObject.SetActive(true);
                // Do animation
                this.robonRespawn.RobonMoveToDeathZone();
            }
        }
        
        public virtual bool IsLose()
        {
            return robonHealth.hp <= 0;
        }
    }
}