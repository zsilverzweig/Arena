using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (playerController == null)
        {
            playerController = FindAnyObjectByType<PlayerController>();
        }
    }

    public void MoveLeft()
    {
        playerController.MoveLeft();
    }
    
    public void MoveRight()
    {
        playerController.MoveRight();
    }
    
    public void MoveUp()
    {
        playerController.MoveUp();
    }
    
    public void MoveDown()
    {
        playerController.MoveDown();
    }
    
    public void Attack()
    {
        playerController.Attack();
    }
    
}
