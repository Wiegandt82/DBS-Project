using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLoadScene = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;

    GameBehaviour gameManager;

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }    //if isTransitioning is true return

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly no action");
                break;

           case "Finish":
                SuccessSeequence();
                break;

            case "GameOver":
                EndGameSeequence();
                break;

            default:
                CrashSeequence();
                break;
        }
    }

    void SuccessSeequence()
    {
        isTransitioning = true;
        GetComponent<PlayerMovement>().enabled = false;
        audioSource.Stop();                                 //will stop all sounds prior of playing success sound next
        audioSource.PlayOneShot(successSound);
        successParticle.Play();
        Invoke("LoadNextLevel", delayLoadScene);
    }

    public void CrashSeequence()
    {
        isTransitioning = true;
        GetComponent<PlayerMovement>().enabled = false;
        audioSource.Stop();                                 //will stop all sounds prior of playing success sound next
        audioSource.PlayOneShot(crashSound);
        crashParticle.Play();
        gameManager.Lives--;

        if (gameManager.Lives > 0)
        {
            Invoke("ReloadLevel", delayLoadScene);
        }
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    void EndGameSeequence()
    {
        GetComponent<PlayerMovement>().enabled = false;
        gameManager.GameOverButton.gameObject.SetActive(true);
        audioSource.Stop();                                 //will stop all sounds prior of playing success sound next
        audioSource.PlayOneShot(successSound);
    }
}
