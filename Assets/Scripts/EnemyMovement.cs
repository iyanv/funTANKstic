using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    private UnityEngine.AI.NavMeshAgent agent;

    [Header("Bullet Prefab, position and cadence")]
    public GameObject enemyBullet;
    public Transform[] bulletSpot;
    public int timeBetweenBullets;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        InvokeRepeating("Attack", 1, timeBetweenBullets);
    }

    void Update()
    {
        if (player == null) return; // If there's no player, enemy can't move

        agent.SetDestination(player.transform.position);
    }

    void Attack()
    {
        for (int i = 0; i < bulletSpot.Length; i++)
        {
            Instantiate(enemyBullet, bulletSpot[i].position, bulletSpot[i].rotation);
        }
    }
    void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("ownBullet"))
            {
                Destroy(this.gameObject);
            }
        }
}
