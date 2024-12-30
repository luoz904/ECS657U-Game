using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    private Transform target;
    public float startMoveSpeed = 10f;
    private float currentMoveSpeed;

    private int wavePointIndex = 0;
    void Start()
    {
        target = waypoints.points[wavePointIndex];
        currentMoveSpeed = startMoveSpeed;
    }

    void Update()
    {
        UnityEngine.Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * currentMoveSpeed * Time.deltaTime, Space.World);

        if (UnityEngine.Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        currentMoveSpeed = startMoveSpeed;
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

    public void Slow(float percentage)
    {
        currentMoveSpeed = startMoveSpeed * (1f - percentage);
    }
}
