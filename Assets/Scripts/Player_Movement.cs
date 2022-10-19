using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;

    [SerializeField] float upThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] AudioClip engineSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        ApplyThrust();
        ProcessThrust();
    }

    void ApplyThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Adding relative force to bottom of rocket regardless how rocket is positioned within game
            rb.AddRelativeForce(Vector3.forward * Time.deltaTime * upThrust);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(engineSound);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(-rotateThrust);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(rotateThrust);
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;                                               //freeze rotation so we can manually apply rotation
        transform.Rotate(Vector3.up * Time.deltaTime * rotationThisFrame); //applying rotatotion manually
        rb.freezeRotation = false;                                              //unfreezing rotation so physics system can take over
    }
}
