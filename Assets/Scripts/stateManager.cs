using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverUI;

    void Start() {
        GameIsOver = false;
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;
        
        if (PlayerStats.SkillPoints <= 0)
        {
            EndGame();
        }
    }

    void EndGame() {
        GameIsOver = true;
        Debug.Log("Is Game Over active "); 
        gameOverUI.SetActive(true);
    }
}
