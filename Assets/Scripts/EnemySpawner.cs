using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] Enemies;

    private Vector3 minSpawnAxis;
    private Vector3 maxSpawnAxis;
    private Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (AbleToSpawn())
        {
            SpawnEnemy(Enemies[Random.Range(0,Enemies.Length)]);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        minSpawnAxis = cam.ViewportToWorldPoint(Vector3.zero);
        maxSpawnAxis = cam.ViewportToWorldPoint(Vector3.one);
        switch (Random.Range(0, 4))
        {
            case 0: //spawn on top of screen
                transform.position = new Vector3(Random.Range(0f, maxSpawnAxis.x - minSpawnAxis.x), maxSpawnAxis.y, 0f);
                break;
            case 1: //spawn on bottom of screen
                transform.position = new Vector3(Random.Range(0f, maxSpawnAxis.x - minSpawnAxis.x), minSpawnAxis.y, 0f);
                break;
            case 2: //spawn on right of screen 
                transform.position = new Vector3(maxSpawnAxis.x, Random.Range(0f, maxSpawnAxis.y - minSpawnAxis.y), 0f);
                break;
            case 3:
                transform.position = new Vector3(minSpawnAxis.x, Random.Range(0f, maxSpawnAxis.y - minSpawnAxis.y), 0f);
                break;
        }       

        Instantiate(enemy, transform.position, transform.rotation);
    }

    [SerializeField] private float cooldown;
    private float cooldownTimestamp;
    bool AbleToSpawn()
    {
        if (Time.time < cooldownTimestamp) return false;
        cooldownTimestamp = Time.time + cooldown;
        return true;
    }
}
