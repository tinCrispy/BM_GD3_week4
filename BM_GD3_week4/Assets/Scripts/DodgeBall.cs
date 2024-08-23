using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeBall : MonoBehaviour
{

    public int shotSpeed;
    private int xRange = 25;

    public AudioSource dodgeBallAudio;
    public AudioClip bugKill;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        dodgeBallAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * shotSpeed * Time.deltaTime);

        if (transform.position.x > xRange)
        {
            Destroy(gameObject);
        }

       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject, 0.3f);
            rb.isKinematic = false;
            Destroy(collision.gameObject);
            dodgeBallAudio.PlayOneShot(bugKill, 1.0f);
        }
    }
}
