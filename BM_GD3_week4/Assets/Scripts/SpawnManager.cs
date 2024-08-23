using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public GameObject enemy;

    public Vector3 enemySpawnPosition = new Vector3(50, 7, -1);
    public Vector3 spawnPosition = new Vector3(50,0,-1);
    private PlayerController playerController;
    private int randomNumber;
 //   private float spawnTime;
   
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObstacleSpawn", 1, 3);
 //       InvokeRepeating("EnemySpawn", 5, Random.Range(1,5));
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0, 1000);
        if (randomNumber <3)
        {
            EnemySpawn();
                }
    }

    void ObstacleSpawn()
    {
        if (playerController.isGameOver == false)
        {
            int index = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[index], spawnPosition, obstaclePrefab[index].transform.rotation);
            Debug.Log("spawned" + obstaclePrefab[index]);
        }
        else
        {
            CancelInvoke("ObstacleSpawn");
        }
    }

    void EnemySpawn()
    {
        if (playerController.isGameOver == false)
        {
            //        int index = Random.Range(0, enemies.Length);
            //        Instantiate(enemies[index], spawnPosition, enemies[index].transform.rotation);
            Instantiate(enemy, enemySpawnPosition, enemy.transform.rotation);  
            Debug.Log("bug incoming");
        }
    }
}

