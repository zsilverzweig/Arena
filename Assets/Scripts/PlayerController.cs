using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover _playerMover;
    private Attacker _playerAttacker;
    
    void Start()
    {
        _playerMover = transform.GetComponent<Mover>();
        _playerAttacker = transform.GetComponent<Attacker>();
    }

    public void MoveLeft()
    {
        if (_playerAttacker.status == "attacking")
        {
            return;
        }
        _playerMover.Move(Vector3.left);
    }
    
    public void MoveRight()
    {
        if (_playerAttacker.status == "attacking")
        {
            return;
        }
        _playerMover.Move(Vector3.right);
    }
    
    public void MoveUp()
    {
        if (_playerAttacker.status == "attacking")
        {
            return;
        }
        _playerMover.Move(Vector3.up);
    }
    
    public void MoveDown()
    {
        if (_playerAttacker.status == "attacking")
        {
            return;
        }
        _playerMover.Move(Vector3.down);
    }
    
    public void Attack()
    {
        if (_playerAttacker.status == "attacking")
        {
            return;
        }
        _playerAttacker.Attack();
    }
    
    // TODO Move this to Input Manager, these are not controls of the player, but of the controller itself.
    void Update()
    {
        if (_playerAttacker.status == "attacking")
        {
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _playerMover.Move(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _playerMover.Move(Vector3.right);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _playerMover.Move(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _playerMover.Move(Vector3.up);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _playerAttacker.Attack();
        }
    }
}
