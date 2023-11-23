using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float closeDistance;
    public Transform enemyHead;

    private GameObject player;
    private NavMeshAgent navigation;
    private Rigidbody rb;

    private bool followPlayer;
    private float distance;

    void Start()
    {
        followPlayer = false;
    }

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        navigation = GetComponent<NavMeshAgent>();
        rb = GetComponentInChildren<Rigidbody>();
        followPlayer = false;
    }

    void Update()
    {
        if (followPlayer)
        {
            distance = (player.transform.position - transform.position).magnitude;

            if (distance > closeDistance) 
            {
                navigation.SetDestination(player.transform.position);
                navigation.isStopped = false;
            }
            else
            {
                navigation.isStopped = true;
            }

            if (enemyHead != null)
            {
                enemyHead.LookAt(player.transform);
            }
        }
    }

    void OnEnable()
    {
        rb.isKinematic = false;
    }

    void OnDisable()
    {
        rb.isKinematic = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            followPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            followPlayer = false;
        }
    }
}