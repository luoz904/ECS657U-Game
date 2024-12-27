using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateManager : MonoBehaviour
{
    private bool isGameEnded = false;

    // Update is called once per frame
    void Update()
    {
        if (isGameEnded)
            return;
            
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame() {
        isGameEnded = true;
        Debug.Log("Game Over!");
    }
}
