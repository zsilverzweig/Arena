using System.Collections;
using UnityEngine;

namespace Game_Management
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Player playerPrefab;
        [SerializeField]
        private EndScreen endScreen;
    
        private MobSpawner _mobSpawner;
        
    
        private void OnEnable()
        {
            Player.OnPlayerDeath += EndGame;
        }

        private void OnDisable()
        {
            Player.OnPlayerDeath -= EndGame;
        }

        public void Start()
        {
            _mobSpawner = FindObjectOfType<MobSpawner>();
            NewGame();
        }

        public void NewGame()
        {
            Debug.Log("A new journey begins...");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
            var mobs = GameObject.FindObjectsOfType<Attacker>();
            foreach (var mob in mobs)
            {
                Destroy(mob.gameObject);
            }
            Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

            endScreen.gameObject.SetActive(false);
        }
        
        private void EndGame(int experience)
        {
            endScreen.gameObject.SetActive(true);
            endScreen.SetScore(experience);
        }
    }
}
