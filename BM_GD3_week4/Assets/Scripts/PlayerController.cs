using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
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
    public ParticleSystem dirtSplatter;
    public ParticleSystem explosion;
    private AudioSource playerAudio;
    public AudioClip playerDeathSFX;
    public AudioClip dodgeThis;
    public AudioClip playerJumpSFX;
    public AudioClip playerOofSFX;
    public AudioClip playerStartSFX;
    public AudioClip doubleJumpSFX;

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
        playerAudio = GetComponent<AudioSource>();
        playerAudio.PlayOneShot(playerStartSFX, 1.0f);

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
            dirtSplatter.Stop();
            playerAudio.PlayOneShot(playerJumpSFX, 1.0f);
        }

        //glide
        else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && doubleJump == true)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * jumpForce / 2, ForceMode.Impulse);
            //    transform.Rotate(90, 0, 0);
            doubleJump = false;
            playerAudio.PlayOneShot(doubleJumpSFX, 0.5f);
            //    glide = true;
        }

        //right yourself
        //else if (Input.GetKeyDown(KeyCode.Space) && isGrounded == false && doubleJump == false && glide == true)
        //{
        //    transform.Rotate(-90, 0, 0);
        //   glide = false;
        //
        //    }


        //shoot
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Instantiate(Dodgeball, new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z), transform.rotation);
            Debug.Log("Dodge This");
            playerAudio.PlayOneShot(dodgeThis, 1.0f);
        }

    }

    //auto right yourself when grounded
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && isGameOver == false && Time.time > 0)
        {
            isGrounded = true;
            dirtSplatter.Play();


            Debug.Log("Life on the Ground");
            playerAudio.PlayOneShot(playerOofSFX, 1.0f);
        }

           else if (collision.gameObject.CompareTag("Ground") && isGameOver == false)
            {
                isGrounded = true;
                //           if(glide == true)
                dirtSplatter.Play();
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
                dirtSplatter.Stop();
                explosion.Play();
                playerAudio.PlayOneShot(playerDeathSFX, 1.0f);


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

