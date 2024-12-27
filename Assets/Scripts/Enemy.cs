using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    public int health = 100;

    public int goldAward = 50;

    public GameObject deathEffect;

    private Transform target;
    private int wavePointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints.points[wavePointIndex];
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health <= 0) {
            Die();
        }
    }

    private void Die() {
        PlayerStats.Money += goldAward;
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (UnityEngine.Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        wavePointIndex++;
        if (wavePointIndex >= waypoints.points.Length)
        {
            EndPath();
        }
        else
            target = waypoints.points[wavePointIndex];
    }

    void EndPath()
    {
        PlayerStats.DecrementLives();
        Destroy(gameObject);
    }
}

