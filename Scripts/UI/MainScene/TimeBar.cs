using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class TimeBar : RepeatMonobehaviour
    {
        [SerializeField] protected Slider slider;
        [SerializeField] protected Gradient gradient;
        [SerializeField] protected Image fill;
        public float currentTime;
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSlider();
            this.LoadFill();
        }

        protected virtual void LoadSlider()
        {
            if (this.slider != null) return;
            this.slider = GetComponent<Slider>();
        }
        
        protected virtual void LoadFill()
        {
            if (this.fill != null) return;
            this.fill = transform.Find("Fill").GetComponent<Image>();
        }
        protected void Start()
        {
            SetMaxTime(GameManager.Instance.TimeMax);
        }

        protected void Update()
        {
            OverTime();
        }

        protected virtual void OverTime()
        {
            if (GameManager.Instance.IsLose()) return;
            currentTime -= Time.deltaTime;
            SetTime();
            if (currentTime <= 0) GameManager.Instance.robonRespawn.RobonDie();
        }

        public virtual void SetTime()
        {
            this.slider.value = currentTime;
            fill.color = gradient.Evaluate(this.slider.normalizedValue);
        }

        public virtual void SetMaxTime(float timeMax)
        {
            this.slider.maxValue = timeMax;
            this.slider.value = timeMax;
            this.currentTime = timeMax;
            fill.color = gradient.Evaluate(1f);
        }
    }
}