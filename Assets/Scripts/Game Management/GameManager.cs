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
        private Cinemachine.CinemachineVirtualCamera _camera;
        
    
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
            _camera = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
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
            var player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            _camera.Follow = player.transform;
            
            endScreen.gameObject.SetActive(false);
        }
        
        private void EndGame(int experience)
        {
            endScreen.gameObject.SetActive(true);
            endScreen.SetScore(experience);
        }
    }
}
