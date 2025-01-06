using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateManager : MonoBehaviour
{
    public static bool GameIsOver = false;

    public static bool GameIsWon = false;
    public GameObject gameOverUI;
    public GameObject gameWinUI;

    void Start()
    {
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

        if (PlayerStats.hasUltimateSkill)
        {
            WinGame();
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        Debug.Log("Is Game Over active ");
        gameOverUI.SetActive(true);
    }

    void WinGame()
    {
        GameIsWon = true;
        Debug.Log("Is Game Over active ");
        gameWinUI.SetActive(true);
    }
}
