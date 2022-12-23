using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : DelayTrap
{
    protected void Start()
    {
        this.ChangeDelay(2, 0.9f);
    }
}
