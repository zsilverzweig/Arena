using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class MobSpawner : MonoBehaviour
{
    [FormerlySerializedAs("mobPrefab")] [SerializeField] GameObject evilMobPrefab;
    [SerializeField] GameObject friendlyMobPrefab;
    [SerializeField] float evilProbability = 0.8f;
    [SerializeField] int mobSpawnInterval = 10;
    [SerializeField] private bool arenaMode = true;
    
    [SerializeField] private bool active = true;
    private float _lastSpawn;
    
    private void OnEnable()
    {
        Monster.OnMobDeath += QuickenSpawner;
    }

    private void OnDisable()
    {
        Monster.OnMobDeath -= QuickenSpawner;
    }

    void Start()
    {
        _lastSpawn = Time.realtimeSinceStartup;
    }
    
    void Update()
    {
        if (!active) { return; }
        
        if (Time.realtimeSinceStartup - _lastSpawn > mobSpawnInterval)
        {
            _lastSpawn = Time.realtimeSinceStartup;
            GameObject newMob = Instantiate(GetMob(), Vector3.zero, Quaternion.identity);
            
            var xModifier = Random.Range(0, 2) * 2 - 1;
            var yModifier = Random.Range(0, 2) * 2 - 1;
            
            var xDistance = Mathf.Round(Random.Range(5f, 12f));
            var yDistance = Mathf.Round(Random.Range(5f, 12f));
            
            newMob.transform.position += new Vector3(xModifier * xDistance, yModifier * yDistance, 0f);
            
        }
    }
    
    private GameObject GetMob()
    {
        if (Random.Range(0f, 1f) < evilProbability)
        {
            return evilMobPrefab;
        }
        else
        {
            return friendlyMobPrefab;
        }
    }
    
    private void QuickenSpawner(Vector3 position, int experience)
    {
        if (arenaMode && mobSpawnInterval > 25)
        {
            mobSpawnInterval -= 5;
        }
    }
    
}
