using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemyMovement : MonoBehaviour
{
    public float startMoveSpeed = 10f;
    public float turnSpeed = 10.0f;

    public float gravity = 5.0f;

    /* private fields */
    private EnemyController controller;
    private Transform target;
    private float currentMoveSpeed;
    private CharacterController moveController;
    private Vector3 moveDirection = Vector3.zero;

    public void SetTarget(Transform _target)
    {
        Debug.Log("Target changed!");
        target = _target;
    }

    public void Slow(float percentage)
    {
        currentMoveSpeed = startMoveSpeed * (1f - percentage);
    }


    void Start()
    {
        controller = GetComponent<EnemyController>();
        moveController = GetComponent<CharacterController>();
        currentMoveSpeed = startMoveSpeed;
    }

    void Update()
    {
        if (target == null)
            return;
        UnityEngine.Vector3 dir = target.position - transform.position;
        Vector3 horizontalDirection = new Vector3(dir.x, 0f, dir.z);

        MoveToTarget(horizontalDirection);

        if (horizontalDirection.magnitude <= 0.05f)
        {
            controller.OnCloseToTarget();
        }
        currentMoveSpeed = startMoveSpeed;
    }

    void MoveToTarget(Vector3 horizontalDirection)
    {
        LockOnTarget();

        if (moveController.isGrounded)
        {
            moveDirection = horizontalDirection.normalized * currentMoveSpeed;
        }
        moveController.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

        if (horizontalDirection.magnitude >= 0f)
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

}
