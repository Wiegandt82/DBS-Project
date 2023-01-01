using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float upThrust = 1000f;
    [SerializeField] float rotateThrust = 100f;
    [SerializeField] float fuelUsage = 10f;
    [SerializeField] AudioClip engineSound;
    [SerializeField] ParticleSystem mainBoosterParticle;
    [SerializeField] ParticleSystem leftBoosterParticle;
    [SerializeField] ParticleSystem rightBoosterParticle;
    

    Rigidbody rb;
    AudioSource audioEngine;
    GameBehaviour gameManager;
    public float baseInterval = 1f;
    float countDown;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioEngine = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>();
        countDown = baseInterval;
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
            {
                audioEngine.PlayOneShot(engineSound);
            }

            if (!mainBoosterParticle.isPlaying)
            {
                mainBoosterParticle.Play();
            }
        }
        else
        {
            audioEngine.Stop();
    
            mainBoosterParticle.Stop() ;
        }
        
    }
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(-rotateThrust);

            if (!rightBoosterParticle.isPlaying)
            {
                rightBoosterParticle.Play();
            }
            else
            {
                rightBoosterParticle.Stop();
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            ApplyRotation(rotateThrust);

            if (!leftBoosterParticle.isPlaying)
            {
                leftBoosterParticle.Play();
            }
            else
            {
                leftBoosterParticle.Stop();
            }
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;                                               //freeze rotation so we can manually apply rotation
        transform.Rotate(Vector3.up * Time.deltaTime * rotationThisFrame);      //applying rotatotion manually
        rb.freezeRotation = false;                                              //unfreezing rotation so physics system can take over
    }
}
