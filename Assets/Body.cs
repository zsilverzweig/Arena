using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _damageInterval = .3f;
    public void Init(Sprite monsterSprite)
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = monsterSprite;
    }

    public void TakeDamageEffects()
    {
        _spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
    }
    
    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(_damageInterval);
        _spriteRenderer.color = Color.white;
    }

    public void SetSprite(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
    }
}
