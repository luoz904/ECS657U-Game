using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Transform target;
    private int wavePointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = waypoints.points[wavePointIndex];
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
            Destroy(gameObject);
        }
        else
            target = waypoints.points[wavePointIndex];
    }
}

