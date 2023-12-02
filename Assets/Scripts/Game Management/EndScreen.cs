using TMPro;
using UnityEngine;

namespace Game_Management
{
    public class EndScreen : MonoBehaviour
    {
        private FinalScore _finalScore;
    
        // Start is called before the first frame update
        void Start()
        {
            _finalScore = GetComponentInChildren<FinalScore>();
        }

        public void SetScore(int experience)
        {
            _finalScore.GetComponentInChildren<TextMeshProUGUI>().text = experience.ToString("D6");
        }
    }
}
