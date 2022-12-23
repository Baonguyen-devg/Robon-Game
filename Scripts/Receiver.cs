using UnityEngine;

namespace DefaultNamespace.Traps
{
    public abstract class Receiver : RepeatMonobehaviour
    {
        public virtual void Received()
        {
            //For override
        }
    }
}