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
            _camera = FindAnyObjectByType<Cinemachine.CinemachineVirtualCamera>();
            _mobSpawner = FindAnyObjectByType<MobSpawner>();
            NewGame();
        }

        public void NewGame()
        {
            Debug.Log("A new journey begins...");

            Destroy(GameObject.FindGameObjectWithTag("Player"));
            var mobs = FindObjectsByType<Monster>(FindObjectsSortMode.None);
            foreach (var mob in mobs)
            {
                Destroy(mob.gameObject);
            }
            var player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            _camera.Follow = player.transform;
            
            FindAnyObjectByType<HealthBar>().ResetHealthbar();
            endScreen.gameObject.SetActive(false);
        }
        
        private void EndGame(int experience)
        {
            endScreen.gameObject.SetActive(true);
            endScreen.SetScore(experience);
        }
    }
}
