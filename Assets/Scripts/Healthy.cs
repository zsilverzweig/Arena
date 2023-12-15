using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore.Text;

public class Healthy : MonoBehaviour
{
    [FormerlySerializedAs("_health")] [SerializeField]
    private int health = 3;
    [SerializeField] 
    private int maxHealth = 3;
    
    SpriteRenderer _spriteRenderer;
    ICharacter _character;
    
    public void Start()
    {
        _character = transform.GetComponent<ICharacter>();
    }
    
    public void Init(int health, int maxHealth)
    {
        this.health = health;
        this.maxHealth = maxHealth;
    }
    
    public void AddHealth(int health)
    {
        if (health + this.health < maxHealth)
        {
            this.health += health;
        }
        else
        {
            this.health = maxHealth;
        }
        _character.AddHealthEffects(health);
    }
    
    public void DoDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            _character.Die();
        }
        else
        {
            _character.TakeDamageEffects(damage);
        }
    }
}
