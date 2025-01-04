using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    private Transform target;
    public float startMoveSpeed = 10f;
    public float turnSpeed = 60.0f;
    private float currentMoveSpeed;

    private int wavePointIndex = 0;

    private EnemyController controller;

    void Start()
    {
        controller = GetComponent<EnemyController>();
        target = waypoints.points[wavePointIndex];
        currentMoveSpeed = startMoveSpeed;
    }

    void Update()
    {
        MoveToTarget();
        LockOnTarget();
        if (UnityEngine.Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        currentMoveSpeed = startMoveSpeed;
    }

    void MoveToTarget()
    {
        UnityEngine.Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * currentMoveSpeed * Time.deltaTime, Space.World);
        if (dir.magnitude >= 0)
        {
            controller.OnMoveForward();
        }
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
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
        Enemy e = GetComponent<Enemy>();
        if (e != null)
            PlayerStats.SurvivedRounds = e.waveNumber;

        Destroy(gameObject);
    }

    public void Slow(float percentage)
    {
        currentMoveSpeed = startMoveSpeed * (1f - percentage);
    }
}
