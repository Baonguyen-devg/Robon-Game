using UnityEngine;

namespace DefaultNamespace
{
    public class RobonScore : MonoBehaviour
    {
        public float coinHave = 0;

        private void Start()
        {
            this.coinHave = SaveScore.instance.score.number;
        }

        public void Collect(int scoreAdd)
        {
            this.coinHave += scoreAdd;
        }
    }
}