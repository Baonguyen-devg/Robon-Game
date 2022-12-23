using DefaultNamespace;
using UnityEngine;

namespace Bin
{
    public class BinController : RepeatMonobehaviour
    {
        [Header("LoadComponent")]
        [SerializeField] protected BinCollect fBinCollect;
        [SerializeField] protected BinCollect pBinCollect;
        [SerializeField] protected BinCollect tBinCollect;
        
        [Header("CheckBinCollected")]
        public bool isFbinCollected = false;
        public bool isPbinCollected = false;
        public bool isTbinCollected = false;

        [Header("Bin")] 
        public Transform fBin;
        public Transform pBin;
        public Transform tBin;
        

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadFBin();
            this.LoadPBin();
            this.LoadTBin();
        }

        protected virtual void LoadFBin()
        {
            if (this.fBinCollect != null && this.fBin) return;
            this.fBinCollect = transform.Find("F").GetComponent<BinCollect>();
            this.fBin = transform.Find("F");
        }
        
        protected virtual void LoadPBin()
        {
            if (this.pBinCollect != null) return;
            this.pBinCollect = transform.Find("P").GetComponent<BinCollect>();
            this.pBin = transform.Find("P");
        }
        
        protected virtual void LoadTBin()
        {
            if (this.tBinCollect != null) return;
            this.tBinCollect = transform.Find("T").GetComponent<BinCollect>();
            this.tBin = transform.Find("T");
        }
    }
}