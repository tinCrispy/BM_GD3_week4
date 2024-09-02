using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public float verticalSpeed;
    public float yTopBound;
    public float yBottomBound;
    private bool isMovingUp;
    // Start is called before the first frame update
    void Start()
    {
        isMovingUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingUp == true && transform.position.y < yTopBound)
        {
            transform.Translate(0, verticalSpeed * Time.deltaTime, 0, Space.World );
        }

        else if (transform.position.y > yBottomBound)
        {
            transform.Translate(0, -verticalSpeed * Time.deltaTime, 0, Space.World);
            isMovingUp = false;
        }

        else
        {
            isMovingUp = true;
        }

        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime, Space.World);

        if (transform.position.x < -5)
            Destroy(gameObject);
    }

        
}
