using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float moveSpeed;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (playerController.isGameOver == false)
        { 

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);

        if (transform.position.x < -5)
            Destroy(gameObject);
        }
    }
}
    