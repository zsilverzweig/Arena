using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Healthy : MonoBehaviour
{
    [SerializeField]
    int health = 3;
    
    SpriteRenderer _spriteRenderer;
    ICharacter _character;
    
    public void Start()
    {
        _character = transform.GetComponent<ICharacter>();
    }
    
    public void DoDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            _character.Die();
        }
        else
        {
            _character.TakeDamageEffects(damage);
        }
    }
}
