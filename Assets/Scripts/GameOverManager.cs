using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text roundsText;

    // Update is called once per frame
    void OnEnable () {
        roundsText.text = PlayerStats.SurvivedRounds.ToString();
    }

    public void Retry () {
        enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu () {
        Debug.Log("Go to Menu!");
    }
}
