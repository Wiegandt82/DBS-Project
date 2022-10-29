using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] AudioClip pointCollected;
    [SerializeField] AudioClip fuelCollected;
    [SerializeField] AudioClip lifeCollected;

    public GameBehaviour gameManager;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>();
        audioSource = GetComponent<AudioSource>();
       
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Point":
                CollectPoints();
                break;

            case "Fuel":
                CollectFuel();
                break;

            case "Life":
                CollectLives();
                break;

            default:
                break;
        }

        void CollectPoints()
        {
            gameManager.Points += 1;
            audioSource.PlayOneShot(pointCollected);
            Debug.Log("Point collected");
            Destroy(other.gameObject);
        }

        void CollectFuel()
        {
            gameManager.Fuel += 1;
            audioSource.PlayOneShot(fuelCollected);
            Debug.Log("Fuel Collected");
            Destroy(other.gameObject);
        }

        void CollectLives()
        {
            gameManager.Lives += 1;
            audioSource.PlayOneShot(lifeCollected);
            Debug.Log("Life collected");
            Destroy(other.gameObject);
        }

    }
}
