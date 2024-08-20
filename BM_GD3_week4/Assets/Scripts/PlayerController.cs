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
    public bool doubleJump;
    public bool glide;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        isGameOver = false;
        doubleJump = false; 
        glide = false;
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doubleJump = true;
        }

        //glide
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && doubleJump == true)
        {
            rb.AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
            transform.Rotate(90, 0, 0);
            doubleJump = false;
            glide = true;
        }

        //right yourself
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && doubleJump == false && glide == true)
        {
            transform.Rotate(-90, 0, 0);
            glide = false;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            if(glide == true)
            {
                transform.Rotate(-90, 0, 0);
                glide = false;
            }
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
