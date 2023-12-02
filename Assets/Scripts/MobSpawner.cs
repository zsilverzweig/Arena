using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject mobPrefab;
    [SerializeField]
    int mobSpawnInterval = 500;
    
    void Update()
    {
        if (Time.frameCount % mobSpawnInterval == 0)
        {
            GameObject newMob = Instantiate(mobPrefab, Vector3.zero, Quaternion.identity);
            
            var xModifier = Random.Range(0, 2) * 2 - 1;
            var yModifier = Random.Range(0, 2) * 2 - 1;
            
            var xDistance = Mathf.Round(Random.Range(0f, 7f));
            var yDistance = Mathf.Round(Random.Range(0f, 7f));
            
            //Debug.Log("xModifier: " + xModifier + " yModifier: " + yModifier + " xDistance: " + xDistance + " yDistance: " + yDistance);
            
            newMob.transform.position += new Vector3(xModifier * xDistance, yModifier * yDistance, 0f);
            
        }
    }
}
