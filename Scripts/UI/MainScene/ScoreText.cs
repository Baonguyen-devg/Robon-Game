using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class ScoreText : RepeatMonobehaviour
    {
        [SerializeField] protected TMP_Text scoreText;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTMPText();
        }

        protected void LoadTMPText()
        {
            if (this.scoreText != null) return;
            this.scoreText = GetComponent<TMP_Text>();
        }

        private void FixedUpdate()
        {
            UpdateScore();
        }

        private void UpdateScore()
        {
            //scoreText.text = "Score: " + GameManager.Instance.robonScore.coinHave;
        }
    }
}