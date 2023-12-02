using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    [Header("Player Attributes")]
    public int health = 3;
    public int experience = 0;
    
    [Header("Manually Linked Objects")]
    public HealthBar healthBar;
    public ExperienceBar experienceBar;
    public TMP_Text finalScore;
    public GameObject endScreen;

    [Header("Animation Variables")] 
    public Sprite deadSprite;
    public float damageInterval = 0.3f;
    
    [Header("Experience Variables")]
    public float experienceRange = 10.0f;

    private SpriteRenderer _spriteRenderer;
    private Healthy _healthy;

    public void Start()
    {
        _spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        
        _healthy = transform.GetComponentInChildren<Healthy>();
        _healthy.Init(health);
        healthBar.AddHealth(_healthy.health);
        
        experienceBar.UpdateExperience(experience);
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
            experienceBar.UpdateExperience(experience);
        }
    }
    
    public void Die()
    {
        Debug.Log("You have been defeated! Game over.");
        _spriteRenderer.sprite = deadSprite;
        finalScore.text = experience.ToString("D6");
        endScreen.SetActive(true);
        //TODO Game Controller Needs to be able to pause the game.
    }
    
    public void TakeDamageEffects(int damage)
    {
        healthBar.TakeDamage(damage);
        _spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
    }
    
    private IEnumerator ResetColor()
    {
        
        yield return new WaitForSeconds(damageInterval);
        _spriteRenderer.color = Color.white;
    }
}
