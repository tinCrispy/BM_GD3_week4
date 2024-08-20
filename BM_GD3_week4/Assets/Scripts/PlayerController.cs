using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGameOver;
    public float jumpForce;
    private Rigidbody rb;
    public bool isGrounded;
    public float gravityModifier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Life on the Ground");
        }

        else if (collision.gameObject.CompareTag("Obstacle"))
        {  
            isGameOver = true;
            Debug.Log("Game Over");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        Debug.Log("Lift Off!");
    }
}
