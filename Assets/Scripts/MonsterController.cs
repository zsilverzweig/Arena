using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MonsterController : MonoBehaviour
{
    private Mover _monsterMover;
    private Attacker _monsterAttacker;
    public GameObject player;
    
    [SerializeField] private float distanceToTarget;
    
    private float _nextActionTime = 0f;
    public float attackDistance = 1f;
    public float timeBetweenMovement = 1f;
    
    private double Tolerance { get; } = .3f;

    void Start()
    {
        _monsterMover = GetComponent<Mover>();
        _monsterAttacker = GetComponent<Attacker>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    void Update()
    {
        if (Time.time >= _nextActionTime)
        {
            
            distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
            _nextActionTime = Time.time + timeBetweenMovement + Random.Range(0f, .2f);
            
            if (_monsterAttacker == null)
            {
                _monsterMover.Wander();
            }
            else
            {
                AttackOrMove();
            }
        }
    }

    private void AttackOrMove()
    {
        if (_monsterAttacker.status != "attacking"
            && _monsterMover.IsFacing(player)
            && Math.Abs(distanceToTarget - attackDistance) < Tolerance)
        {
            _monsterAttacker.Attack();
        }
        else if (_monsterAttacker.status != "attacking")
        {
            _monsterMover.MoveTowards(player);
        }
    }

    public void Init(float distance, float time)
    {
        attackDistance = distance;
        timeBetweenMovement = time;
    }
}

