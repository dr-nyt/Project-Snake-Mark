using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private float attackTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        attackTime -= Time.deltaTime;
        if(attackTime <= 0)
        {
            gameObject.SetActive(false);
            attackTime = 0.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
