using System.Collections;
using Scriptable_Objects;
using Unity.VisualScripting;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField] private MobSpawnerDataSO spawnerData;
    [SerializeField] private GameObject mobBase;
    [SerializeField] public bool active = true;
    private float _lastSpawn;
    
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; // Set the color of the Gizmo
        Gizmos.DrawWireSphere(transform.position, spawnerData.playerProximityRadius); // Draw a wireframe sphere
    }

    void Start()
    {
        if (active)
        {
            StartCoroutine(SpawnMobs());
        }
    }
    
    IEnumerator SpawnMobs()
    {
        while (active)
        {
            yield return new WaitForSeconds(spawnerData.mobSpawnInterval);
            
            GameObject newMob = Instantiate(GetMob(), Vector3.zero, Quaternion.identity);
        
            var xModifier = Random.Range(0, 2) * 2 - 1;
            var yModifier = Random.Range(0, 2) * 2 - 1;
        
            var xDistance = Mathf.Round(Random.Range(5f, 12f));
            var yDistance = Mathf.Round(Random.Range(5f, 12f));
        
            newMob.transform.position += new Vector3(xModifier * xDistance, yModifier * yDistance, 0f);
        }
    }
    
    private void OnDisable()
    {
        StopCoroutine(SpawnMobs());
    }

    private GameObject GetMob()
    {
        if (Random.Range(0f, 1f) < spawnerData.evilProbability)
        {
            return GetWeightedRandomEvilMob();
        }
        else
        {
            return spawnerData.friendlyMob1;
        }
    }
    

    private GameObject GetWeightedRandomEvilMob()
    {
        int totalWeight = spawnerData.evilMob1Weight + spawnerData.evilMob2Weight + spawnerData.evilMob3Weight;
        int randomNumber = Random.Range(0, totalWeight);
        int cumulativeWeight = spawnerData.evilMob1Weight;

        
        if (randomNumber < cumulativeWeight)
        {
            return spawnerData.evilMob1;
        }

        cumulativeWeight += spawnerData.evilMob2Weight;
        if (randomNumber < cumulativeWeight)
        {
            return spawnerData.evilMob2;
        }

        return spawnerData.evilMob3; 
    }

}


//  This won't work anymore since there are lots of spawners, every mobdeath would increase every spawner.

// private void OnEnable()
// {
//     // if (arenaMode) Monster.OnMobDeath += QuickenSpawner;
// }
//
// private void OnDisable()
// {
//     // if (arenaMode) Monster.OnMobDeath -= QuickenSpawner;
// }

// private void QuickenSpawner(Vector3 position, int experience)
// {
//     if (mobSpawnInterval > 1.0)
//     {
//         mobSpawnInterval -= 0.5f;
//     }
// }
