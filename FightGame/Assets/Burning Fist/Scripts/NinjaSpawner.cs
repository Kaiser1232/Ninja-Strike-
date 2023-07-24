using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSpawner : MonoBehaviour
{
    public GameObject[] ninjaArray;
    public float xMaxSpawnDistance;
    public float zMaxSpawnDistance;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNinjaRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator SpawnNinjaRoutine()
    {
        while (true)
        {
            SpawnNinja();
            yield return new WaitForSeconds(spawnRate);
        }

    }
    private Vector3 ChooseSpawnLocation()
    {
        float xPos = UnityEngine.Random.Range(-xMaxSpawnDistance, xMaxSpawnDistance);
        float zPos = UnityEngine.Random.Range(-zMaxSpawnDistance, zMaxSpawnDistance);

        return new Vector3(xPos, 0, zPos);
    }

    private GameObject ChooseNinja()
    {
        int index = UnityEngine.Random.Range(0, ninjaArray.Length);
        return ninjaArray[index];

    }

    private void SpawnNinja()
    {
        Instantiate(ChooseNinja(), ChooseSpawnLocation(), Quaternion.identity);
    }
     
}

   
