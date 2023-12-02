using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [Header("Player Attributes")]
    public int health = 1;
    public int experience = 0;
    
    // [Header("Manually Linked Objects")]
    [Header("Animation Variables")] 
    public Sprite deadSprite;
    public float damageInterval = 0.3f;
    
    [Header("Experience Variables")]
    public float experienceRange = 10.0f;

    private SpriteRenderer _spriteRenderer;
    private Healthy _healthy;
    private HealthBar _healthBar;
    private ExperienceBar _experienceBar;
    
    public delegate void PlayerDeath(int experience);
    public static event PlayerDeath OnPlayerDeath;

    public void Start()
    {
        _spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        
        _healthy = transform.GetComponentInChildren<Healthy>();
        _healthy.Init(health);
        
        _healthBar = FindObjectOfType<HealthBar>();
        _healthBar.AddHealth(_healthy.health);
        
        _experienceBar = FindObjectOfType<ExperienceBar>();
        _experienceBar.UpdateExperience(experience);
    }

    private void OnEnable()
    {
        Monster.OnMobDeath += GainExperience;
    }

    private void OnDisable()
    {
        Monster.OnMobDeath -= GainExperience;
    }

    private void GainExperience(Vector3 mobPosition, int mobExperience)
    {
        float distance = Vector3.Distance(transform.position, mobPosition);
        if (distance <= experienceRange)
        {
            experience += mobExperience;
            _experienceBar.UpdateExperience(experience);
        }
    }
    
    public void Die()
    {
        Debug.Log("You have been defeated! Game over.");

        OnPlayerDeath?.Invoke(experience);
        _spriteRenderer.sprite = deadSprite;
    }
    
    public void TakeDamageEffects(int damage)
    {
        _healthBar.TakeDamage(damage);
        _spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
    }
    
    private IEnumerator ResetColor()
    {
        
        yield return new WaitForSeconds(damageInterval);
        _spriteRenderer.color = Color.white;
    }
}
