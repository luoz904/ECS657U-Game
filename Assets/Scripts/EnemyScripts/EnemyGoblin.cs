using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemyGoblin : MonoBehaviour
{
  
    public int id;
    public int waveNumber;
    public float health = 100;

    public int goldAward = 50;

    public GameObject deathEffect;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += goldAward;
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}

