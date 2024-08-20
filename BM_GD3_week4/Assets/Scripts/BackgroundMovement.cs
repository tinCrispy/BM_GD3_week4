using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private PlayerController playerController;
    private Vector3 startPosition;
    public float moveSpeed;
    private float bgWidth;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        bgWidth = GetComponent<BoxCollider>().size.x;
        playerController = GameObject.FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.isGameOver == false)
        {

            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

            if (transform.position.x < startPosition.x - bgWidth / 2)
            {
                transform.position = startPosition;
            }

        }
    }
}
