using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private Collider2D _collider2D;
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        Debug.Log("HealthPotion dropped!");
    }

    // When the player collides with the potion, destroy the potion and add health to the player
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<Healthy>().AddHealth(1);
            Destroy(gameObject);
        }
    }
}
