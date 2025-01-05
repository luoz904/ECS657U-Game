using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int SkillPoints;

    public int startSkillPoints = 100;

    public static int SurvivedRounds;


    // Start is called before the first frame update
    void Start()
    {
        SkillPoints = startSkillPoints;
        SurvivedRounds = 0;
    }

    public static void DecrementLives() {
        SkillPoints--;
    }
}
