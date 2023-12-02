using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class MonsterController : MonoBehaviour
{
    private Mover _monsterMover;
    private Attacker _monsterAttacker;
    public GameObject player;
    
    [SerializeField] private float distanceToTarget;
    
    private float _nextActionTime = 0f;
    public float attackDistance = 1f;
    public float speed = 1f;
    double TOLERANCE = .3f;

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
            _nextActionTime = Time.time + speed * Time.deltaTime;
            
            if (_monsterAttacker.status != "attacking" 
                && _monsterMover.IsFacing(player) 
                && Math.Abs(distanceToTarget - attackDistance) < TOLERANCE)
            {
                _monsterAttacker.Attack();
            }
            else if (_monsterAttacker.status != "attacking")
            {
                _monsterMover.MoveTowards(player);    
            }
            
        }
    }
}

