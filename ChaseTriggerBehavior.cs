using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTriggerBehavior : MonoBehaviour
{
    public float chaseDelay = 1f;
    public EnemyPatrollingBehavior enemy;

    private float chaseTimer = 0f;
    private bool isChasing = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {
            chaseTimer = Time.time;
            Debug.Log("trigger player");
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time - chaseTimer > chaseDelay)
        {
            isChasing = true;
            enemy.IsChasing = true;
            chaseTimer = 0f;
            Debug.Log("trigger stay");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;
        }
    }

}