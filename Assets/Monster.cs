using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, ICharacter
{
    public float damageInterval = 0.3f;
    
    private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        _spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamageEffects(int damage)
    {
        _spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
    }

    public void Die()
    {
        Debug.Log("You have defeated the monster!");
        Destroy(gameObject);
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(damageInterval);
        _spriteRenderer.color = Color.white;
    }
}
