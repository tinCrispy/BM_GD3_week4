using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    public Vector3 spawnPosition = new Vector3(20,0,-1);
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ObstacleSpawn", 1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ObstacleSpawn()
    { 
        int index = Random.Range(0,obstaclePrefab.Length);
        Instantiate(obstaclePrefab[index], spawnPosition, obstaclePrefab[index].transform.rotation);     
    }
}

