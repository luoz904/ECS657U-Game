using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyMovement : MonoBehaviour
{

    private Transform target;
    public float startMoveSpeed = 10f;
    public float turnSpeed = 10.0f;
    private float currentMoveSpeed;

    public float gravity = 5.0f;

    private CharacterController moveController;

    private Vector3 moveDirection = Vector3.zero;

    private int wavePointIndex = 0;

    private EnemyController controller;

    void Start()
    {
        moveController = GetComponent<CharacterController>();
        controller = GetComponent<EnemyController>();
        target = waypoints.points[wavePointIndex];
        currentMoveSpeed = startMoveSpeed;
    }

    void Update()
    {
        UnityEngine.Vector3 dir = target.position - transform.position;
        MoveToTarget(dir);

        if (dir.magnitude <= 2f)
        {
            Debug.Log("Get Next waypoint!");
            GetNextWaypoint();
        }
        currentMoveSpeed = startMoveSpeed;
    }

    void MoveToTarget(Vector3 dir)
    {
        LockOnTarget();

        if (moveController.isGrounded)
        {
            moveDirection = dir.normalized * currentMoveSpeed;
        }
        moveController.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

        if (dir.magnitude >= 0f)
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
