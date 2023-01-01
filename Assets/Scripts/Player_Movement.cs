using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    Rigidbody rb;
<<<<<<< Updated upstream:Assets/Scripts/Player_Movement.cs
    AudioSource audioSource;
=======
    AudioSource audioEngine;
    GameBehaviour gameManager;
    public float baseInterval = 1f;
    float countDown;
>>>>>>> Stashed changes:Assets/Scripts/PlayerMovement.cs

    [SerializeField] float upThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] AudioClip engineSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
<<<<<<< Updated upstream:Assets/Scripts/Player_Movement.cs
        audioSource = GetComponent<AudioSource>();  
=======
        audioEngine = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>();
        countDown = baseInterval;
>>>>>>> Stashed changes:Assets/Scripts/PlayerMovement.cs
    }

    // Update is called once per frame
    void Update()
    {
        ApplyThrust();
        ProcessThrust();
    }

    void ApplyThrust()
    {
        audioEngine.clip = engineSound;
        if (Input.GetKey(KeyCode.Space))
        {
            //Adding relative force to bottom of rocket regardless how rocket is positioned within game
            rb.AddRelativeForce(Vector3.forward * Time.deltaTime * upThrust);

<<<<<<< Updated upstream:Assets/Scripts/Player_Movement.cs
            if (!audioSource.isPlaying)
=======
            //Using down fuel per every second
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                countDown = baseInterval;
                gameManager.Fuel -= fuelUsage;
            }

            if (!audioEngine.isPlaying)
>>>>>>> Stashed changes:Assets/Scripts/PlayerMovement.cs
            {
                audioEngine.PlayOneShot(engineSound);
            }
<<<<<<< Updated upstream:Assets/Scripts/Player_Movement.cs
        }
        else
        {
            audioSource.Stop();
=======

            if (!mainBoosterParticle.isPlaying)
            {
                mainBoosterParticle.Play();
            }
        }
        else
        {
            audioEngine.Stop();
    
            mainBoosterParticle.Stop() ;
>>>>>>> Stashed changes:Assets/Scripts/PlayerMovement.cs
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
