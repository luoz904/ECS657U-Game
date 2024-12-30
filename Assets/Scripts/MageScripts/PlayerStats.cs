using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;

    public int startMoney = 400;
    public int startLives = 20;

    public static int SurvivedRounds;


    // Start is called before the first frame update
    void Start()
    {
        Money = startMoney;
        Lives = startLives;
        SurvivedRounds = 0;
    }

    public static void DecrementLives() {
        Lives--;
    }
}
