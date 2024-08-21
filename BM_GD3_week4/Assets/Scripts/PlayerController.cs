using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    public int shotSpeed;
    private Animator playerAnim;
    public GameObject Dodgeball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        isGameOver = false;
        doubleJump = false; 
        glide = false;
        shotSpeed = 8;
        
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && isGameOver == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doubleJump = true;
            playerAnim.SetTrigger("Jump_trig");
        }

        //glide
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && doubleJump == true)
        {
            rb.AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
        //    transform.Rotate(90, 0, 0);
           doubleJump = false;
        //    glide = true;
        }

        //right yourself
        //else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && doubleJump == false && glide == true)
        //{
        //    transform.Rotate(-90, 0, 0);
        //   glide = false;
        //
        //    }

    }

    //auto right yourself when grounded
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
 //           if(glide == true)
            {
 //               transform.Rotate(-90, 0, 0);
 //               glide = false;
            }
            Debug.Log("Life on the Ground");
        }
     // game over
        else if (collision.gameObject.CompareTag("Obstacle"))
        {  
            isGameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            GameObject.FindObjectOfType<ScoreManager>().GameOver();

        }

        //shoot

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(Dodgeball, transform.position, transform.rotation);
            Debug.Log("Dodge This");
        }


    }

    public void Restart()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity /= gravityModifier;
        isGameOver = false;
        doubleJump = false;
        shotSpeed = 8;
     //   glide = false;
        Debug.Log("Lets go again!");
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        Debug.Log("Lift Off!");
    }
}
