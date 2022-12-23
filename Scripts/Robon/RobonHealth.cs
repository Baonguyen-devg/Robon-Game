using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class RobonHealth : RepeatMonobehaviour
    {
        [SerializeField] protected int hpMax = 3;
        public int hp;

        private void Start()
        {
            this.hp = hpMax;
        }

        public void Deduct(int hpDeduct)
        {
            this.hp -= hpDeduct;
        }
    }
}