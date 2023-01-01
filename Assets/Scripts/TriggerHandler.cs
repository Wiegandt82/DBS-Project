using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    [SerializeField] AudioClip pointCollected;
    [SerializeField] AudioClip fuelCollected;
    [SerializeField] AudioClip lifeCollected;

    GameBehaviour gameManager;

    AudioSource audioCollectables;

    // Start is called before the first frame update
    void Start()
    {
        audioCollectables = gameObject.AddComponent<AudioSource>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>();
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
            gameManager.Points += 10;

            audioCollectables.Stop();
            audioCollectables.clip = pointCollected;
            audioCollectables.PlayOneShot(pointCollected);
            Debug.Log("Point collected");
            Destroy(other.gameObject);
        }

        void CollectFuel()
        {
            float maxFuel = 200f;
            gameManager.Fuel += 40;
            if (gameManager.Fuel > maxFuel)
            {
                gameManager.Fuel = maxFuel;
            }

            audioCollectables.Stop();
            audioCollectables.clip = fuelCollected;
            audioCollectables.PlayOneShot(fuelCollected);
            Debug.Log(gameManager.Fuel);
            Destroy(other.gameObject);
        }

        void CollectLives()
        {
            gameManager.Lives += 1;
            audioCollectables.Stop();
            audioCollectables.clip = lifeCollected;
            audioCollectables.PlayOneShot(lifeCollected);
            
            Debug.Log("Life collected");
            Destroy(other.gameObject);
        }

    }
}
