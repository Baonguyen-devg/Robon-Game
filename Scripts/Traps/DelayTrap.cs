using System.Collections;
using UnityEngine;

public class DelayTrap : RepeatMonobehaviour
{
    [Header("DelayInformation")]
    [SerializeField] protected float time = 0;
    [SerializeField] protected float timeStart;
    [SerializeField] protected float timeOff;
    [SerializeField] protected float timeOn;
    [SerializeField] protected bool isStart = false;

    [Header("LoadComponents")]
    [SerializeField] protected Transform onTransform;
    [SerializeField] protected Transform offTransform;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadOnTransform();
        this.LoadOffTransform();
    }

    protected virtual void ChangeDelay(float start, float on)
    {
        this.timeStart = start; this.timeOn = on;
    }

    protected virtual void LoadOnTransform()
    {
        if (this.onTransform != null) return;
        this.onTransform = transform.Find("On");
        this.onTransform.gameObject.SetActive(false);
    }
    
    protected virtual void LoadOffTransform()
    {
        if (this.offTransform != null) return;
        this.offTransform = transform.Find("Off");
        this.offTransform.gameObject.SetActive(true);
    }

    protected virtual void Update()
    {
        time += Time.deltaTime;
        ObjectOn();
    }

    protected virtual void ObjectOn()
    {
        if ((time >= timeStart) && isStart == false)
        {
            StartCoroutine(ObjectDelay());
            isStart = true;
        }

        if ((time >= timeOff) && isStart == true)
        {
            StartCoroutine(ObjectDelay());
        }
    }

    private IEnumerator ObjectDelay()
    {
        this.onTransform.gameObject.SetActive(true);
        this.offTransform.gameObject.SetActive(false);
        
        yield return new WaitForSeconds(timeOn);
        
        this.onTransform.gameObject.SetActive(false);
        this.offTransform.gameObject.SetActive(true);
        time = 0;
        
    }
   
}
