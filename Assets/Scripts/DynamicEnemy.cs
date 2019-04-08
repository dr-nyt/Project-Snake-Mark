using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEnemy : MonoBehaviour
{
    private Rigidbody enemyBody;
    private GameObject target;
    private Vector3 targetPosition;
    private bool targetInSight;
    public float fieldOfViewAngle;
    public float range;

    private RaycastHit hit;
    private Vector3 rayDirection;

    [SerializeField]
    [Range(0, 1f)]
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
        targetPosition = target.transform.position;
        targetInSight = false;
        fieldOfViewAngle = 90f;
        range = 10f;
}

    // Update is called once per frame
    void FixedUpdate()
    {
        rayDirection = target.transform.position - transform.position;
        print(rayDirection.magnitude);
        if (Physics.Raycast(transform.position, rayDirection, out hit) && Vector3.Angle(rayDirection, transform.forward) <= fieldOfViewAngle * 0.5)
        {
            if (hit.transform == target.transform && rayDirection.magnitude <= range)
            {
                transform.LookAt(target.transform.position);
                enemyBody.MovePosition(Vector3.MoveTowards(transform.position, target.transform.position, .5f * moveSpeed));
            }
        }
    }
}
