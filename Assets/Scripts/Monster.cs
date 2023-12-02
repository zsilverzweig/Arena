using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, ICharacter
{
    [SerializeField]
    public int experience = 1;
    
    public float damageInterval = 0.3f;
    
    private SpriteRenderer _spriteRenderer;
    private MonsterController _monsterController;

    public delegate void MobDeath(Vector3 position, int experience);
    public static event MobDeath OnMobDeath;

    public void Start()
    {
        _monsterController = transform.GetComponent<MonsterController>();
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
        OnMobDeath?.Invoke(transform.position, experience);
        Destroy(gameObject);
        
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(damageInterval);
        _spriteRenderer.color = Color.white;
    }
}
