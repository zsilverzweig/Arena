using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Player player;

    private Mover _playerMover;
    private Attacker _playerAttacker;
    
    void Start()
    {
        _playerMover = player.GetComponent<Mover>();
        _playerAttacker = player.GetComponent<Attacker>();
    }

    void Update()
    {
        if (_playerAttacker.status == "attacking")
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _playerMover.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _playerMover.MoveRight();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _playerMover.MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _playerMover.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerAttacker.Attack();
        }
    }
}
