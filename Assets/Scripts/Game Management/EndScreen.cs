using TMPro;
using UnityEngine;

namespace Game_Management
{
    public class EndScreen : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI finalScore;
        
        public void SetScore(int experience)
        {
            finalScore.text = experience.ToString("D6");
        }
    }
}
