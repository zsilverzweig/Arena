using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour, ICharacter
{
    [SerializeField]
    public int experience = 1;
    public int health = 1;
    public int maxHealth = 3;
    
    [SerializeField]
    public Loot loot;
    public float lootDropRate = 0.5f;
    
    public float damageInterval = 0.3f;
    
    private SpriteRenderer _spriteRenderer;
    private Healthy _healthy;
    private MonsterController _monsterController;

    public delegate void MobDeath(Vector3 position, int experience);
    public static event MobDeath OnMobDeath;

    public void Start()
    {
        _healthy = transform.GetComponent<Healthy>();
        _healthy.Init(health, maxHealth);
        _monsterController = transform.GetComponent<MonsterController>();
        _spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
    }

    public void TakeDamageEffects(int damage)
    {
        _spriteRenderer.color = Color.red;
        StartCoroutine(ResetColor());
    }
    
    public void AddHealthEffects(int amount)
    {
        // Only used for players... for now...
    }

    public void Die()
    {
        Debug.Log("You have defeated the monster!");
        if (loot != null)
        {
            if (Random.Range(0f, 1f) < lootDropRate) Instantiate(loot, transform.position, Quaternion.identity);
        }
        OnMobDeath?.Invoke(transform.position, experience);
        Destroy(gameObject);
    }

    private IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(damageInterval);
        _spriteRenderer.color = Color.white;
    }
}
