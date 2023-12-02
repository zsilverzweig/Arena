using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;

    public void AddHealth(int health)
    {
        for (int i = 0; i < health; i++)
        {
            Instantiate(heartPrefab, transform);
        }
    }
    
    public void TakeDamage(int damage)
    {
        var hearts = GetComponentsInChildren<Heart>();
        for (int i = 0; i < damage; i++)
        {
            Destroy(hearts[i].gameObject);
        }
    }
}
