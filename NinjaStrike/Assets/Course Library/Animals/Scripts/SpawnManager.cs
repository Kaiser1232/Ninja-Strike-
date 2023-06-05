using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int xSpawnRange = 5;
    public float startDelay = 2;
    public float timeInterval = 10.0f;
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, timeInterval);
    }
    void Update()
    {
    }
    void SpawnRandomAnimal()
    {
        int animalIndex = UnityEngine.Random.Range(0, animalPrefabs.Length);
        int xSpawnOffset = UnityEngine.Random.Range(-xSpawnRange, xSpawnRange);
        Instantiate(animalPrefabs[animalIndex], new UnityEngine.Vector3(xSpawnOffset, 0, 20),
        animalPrefabs[animalIndex].transform.rotation);
    }
}
