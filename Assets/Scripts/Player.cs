using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    public string status = "ready";
    public float damageInterval = 0.3f;
    
    private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        _spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
    }
    
    public void Die()
    {
        Debug.Log("You have been defeated! Game over.");
    }
    
    public void TakeDamageEffects(int damage)
    {
        _spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
    }
    
    private IEnumerator ResetColor()
    {
        
        yield return new WaitForSeconds(damageInterval);
        _spriteRenderer.color = Color.white;
    }
}
