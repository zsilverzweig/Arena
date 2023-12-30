using System.Collections;
using System.Collections.Generic;
using Scriptable_Objects;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour, ICharacter
{
    public MonsterDataSO monster;
    
    private Healthy _healthy;
    private MonsterController _monsterController;
    private Weapon _weapon;
    private Body _body;
    private Attacker _attacker;

    public delegate void MobDeath(Vector3 position, int experience);
    public static event MobDeath OnMobDeath;

    public void Start()
    {
        _monsterController = transform.GetComponent<MonsterController>();
        _monsterController.Init(monster.attackDistance, monster.timeBetweenMovement);
        _body = transform.GetComponentInChildren<Body>();
        _body.Init(monster.sprite);
        _weapon = transform.GetComponentInChildren<Weapon>();
        if (_weapon != null) _weapon.Init(monster.damage, monster.weaponSprite, monster.rotation, monster.extension, monster.attackDuration);         
        _attacker = transform.GetComponent<Attacker>();
        if (_attacker != null) _attacker.Init(monster.sprite, monster.attackingSprite, _weapon, _body, monster.attackDuration);
        _healthy = transform.GetComponent<Healthy>();
        _healthy.Init(monster.health, monster.maxHealth);
    }

    public void TakeDamageEffects(int damage)
    {
        _body.TakeDamageEffects();
    }
    
    public void AddHealthEffects(int amount)
    {
        // Only used for players... for now...
    }

    public void Die()
    {
        Debug.Log("You have defeated the monster!");
        if (monster.loot != null)
        {
            if (Random.Range(0f, 1f) < monster.lootDropRate) Instantiate(monster.loot, transform.position, Quaternion.identity);
        }
        OnMobDeath?.Invoke(transform.position, monster.experience);
        Destroy(gameObject);
    }
}
