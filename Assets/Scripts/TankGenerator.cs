using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankGenerator : MonoBehaviour
{
    public GameObject enemyTankPrefab; // Here goes enemy tank prefab
    public Transform[] positions; // Position Array

    public float spawnTime;
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(enemyTankPrefab, positions[i].position, positions[i].rotation);
        }
    }
}
