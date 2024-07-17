using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    
    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;
    private float leftovercooldown;
    public float EnemyCooldown = 10f;
    // Start is called before the first frame update
    void Start()
    {
        leftovercooldown = EnemyCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        leftovercooldown = leftovercooldown - Time.deltaTime;
        if (leftovercooldown <= 0)
        {
            
            float xSpawn = Random.Range(xMin, xMax);
            float zSpawn = Random.Range(zMin, zMax);
            Vector3 SpawnPoint = new Vector3(xSpawn, 0, zSpawn) + transform.position;
            Instantiate(EnemyPrefabs[Random.Range(0,EnemyPrefabs.Length)], SpawnPoint, Quaternion.identity);
            leftovercooldown = EnemyCooldown;
        }
    }
}
