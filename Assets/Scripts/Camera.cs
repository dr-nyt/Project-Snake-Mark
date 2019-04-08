using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject target;
    private Vector3 offSet;
    private Vector3 lookVector;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        offSet = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offSet;

        lookVector.x = Input.GetAxisRaw("Horizontal");
        lookVector.y = 0;
        lookVector.z = Input.GetAxisRaw("Vertical");
        transform.LookAt(transform.position + new Vector3(lookVector.x, 0, lookVector.z));
    }
}
