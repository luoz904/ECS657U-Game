using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class EnemyPathSeeker : MonoBehaviour
{
    public Transform route;

    private Transform target;
    private EnemyController controller;

    private Transform[] points;

    private int wavePointIndex = 0;

    public void SetRoute(Transform _route)
    {
        
        points = new Transform[_route.childCount];
        for (int i = 0; i < points.Length; ++i)
        {
            points[i] = _route.GetChild(i);
        }
        wavePointIndex = 0;
        
    }

    public Transform GetCurrentWaypoint() {
        target = points[wavePointIndex];
        return target;
    }

    public Transform GetNextWaypoint()
    {
        wavePointIndex++;
        if (wavePointIndex >= points.Length)
        {
            EndPath();
        }
        else
            target = points[wavePointIndex];
        return target;
    }

    void Start()
    {
        controller = GetComponent<EnemyController>();
    }

    void EndPath()
    {
        controller.OnPathEnd();
    }
}