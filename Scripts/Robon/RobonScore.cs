using UnityEngine;

namespace DefaultNamespace
{
    public class RobonScore : MonoBehaviour
    {
        public int coinHave = 0;

        public void Collect(int scoreAdd)
        {
            coinHave += scoreAdd;
        }
    }
}