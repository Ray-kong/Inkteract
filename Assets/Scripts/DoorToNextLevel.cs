using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToNextLevel : MonoBehaviour
{
    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();  
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!LevelManager.isGameOver && collision.CompareTag("Player") && Input.GetKey(KeyCode.W))
        {
            levelManager.LevelWon();
        }
    }
}
