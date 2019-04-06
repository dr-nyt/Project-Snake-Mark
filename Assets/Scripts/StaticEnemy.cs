using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    private Vector3 targetPosition;

    [SerializeField]
    [Range(0, 1f)]
    private float moveSpeed = 0.2f;

    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {

        waypointIndex = 0;
        targetPosition = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, .5f * moveSpeed);
        if (Vector3.Distance(transform.position, targetPosition) < .25f)
        {
            if (waypointIndex + 1 >= waypoints.Length)
            {
                waypointIndex = 0;
            }
            else
            {
                waypointIndex++;
            }
            targetPosition = waypoints[waypointIndex].position;
        }
    }
}
