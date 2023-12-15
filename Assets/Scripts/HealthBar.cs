using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject heartPrefab;

    private int _maxHealth;
    private int _currentHealth;
    private List<Image> hearts = new List<Image>(); 
    
    void Start()
    {
        ResetHealthbar();
    }

    public void ResetHealthbar()
    {
        var existingHearts = GetComponentsInChildren<Heart>();
        foreach (var heart in existingHearts)
        {
            Destroy(heart.gameObject);
        }
        hearts.Clear();
    }

    public void SetMaxHealth(int health)
    {
        ResetHealthbar();
        _maxHealth = health;
        _currentHealth = health;

        // Instantiate heart prefabs and add them to the hearts list
        for (int i = 0; i < health; i++)
        {
            var heart = Instantiate(heartPrefab, transform).GetComponent<Image>();
            hearts.Add(heart);
        }
    }
    
    public void Heal(int health)
    {
        _currentHealth = Mathf.Min(_currentHealth + health, _maxHealth); // Ensure current health does not exceed max health
        UpdateHeartDisplay();
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth = Mathf.Max(_currentHealth - damage, 0); // Ensure current health does not go below 0
        UpdateHeartDisplay();
    }

    private void UpdateHeartDisplay()
    {
        for (int i = 0; i < _maxHealth; i++)
        {
            if (i < _currentHealth)
                hearts[i].color = Color.white; // Heart is active
            else
                hearts[i].color = Color.black; // Heart is inactive
        }
    }
}