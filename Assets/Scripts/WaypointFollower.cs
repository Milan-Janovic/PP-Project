using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] GameObject[] wayPoints;
    int currentWayPointIndex = 0;

    [SerializeField] float speed = 3f;

    void Update()
    {
        if(Vector3.Distance(transform.position, wayPoints[currentWayPointIndex].transform.position) < .1f)
        {
            currentWayPointIndex++;

            Debug.Log(currentWayPointIndex);

            if(currentWayPointIndex >= wayPoints.Length)
            {
                currentWayPointIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWayPointIndex].transform.position, 
                                                    speed * Time.deltaTime);
    }
}
