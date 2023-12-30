using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New MobSpawnerData", menuName = "Mob Spawner Data")]
    
    public class MobSpawnerDataSO : ScriptableObject
    {
        [Header("Basic Info")]
        [SerializeField] public string mobSpawnerName = "Mob Spawner";
            
        [Header("Proximity Data")]
        [SerializeField] public float mobSpawnInterval = 5;
        [SerializeField] public float playerProximityRadius = 30f;
        [SerializeField] public float evilProbability = 0.8f;
        
        [Header("Enemy Data")]
        [SerializeField] public GameObject evilMob1;
        [SerializeField] public GameObject evilMob2;
        [SerializeField] public GameObject evilMob3;
        [SerializeField] public int evilMob1Weight = 70;
        [SerializeField] public int evilMob2Weight = 25;
        [SerializeField] public int evilMob3Weight = 5;
        
        [Header("Friendly Data")]
        [SerializeField] public GameObject friendlyMob1;
    }
}