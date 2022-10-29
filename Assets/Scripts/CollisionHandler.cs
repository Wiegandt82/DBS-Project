using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLoadScene = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly no action");
                break;

           case "Finish":
                SuccessSeequence();
                break;

<<<<<<< Updated upstream
            case "Point":
                Debug.Log("Point collected");
                break;

            case "Life":
                //create login for lives collection + sound etc
                Debug.Log("Life collected");
                break;

=======
>>>>>>> Stashed changes
            default:
                CrashSeequence();
                break;
        }
    }

    void SuccessSeequence()
    {
<<<<<<< Updated upstream
        GetComponent<Player_Movement>().enabled = false;
=======
        isTransitioning = true;
        GetComponent<PlayerMovement>().enabled = false;
        audioSource.Stop();                                 //will stop all sounds prior of playing success sound next
>>>>>>> Stashed changes
        audioSource.PlayOneShot(successSound);
        //add particle effect
        Invoke("LoadNextLevel", delayLoadScene);
    }

    void CrashSeequence()
    {
<<<<<<< Updated upstream
=======
        isTransitioning = true;
        GetComponent<PlayerMovement>().enabled = false;
        audioSource.Stop();                                 //will stop all sounds prior of playing success sound next
>>>>>>> Stashed changes
        audioSource.PlayOneShot(crashSound);
        //add particle effect on crash
        GetComponent<Player_Movement>().enabled = false;
        Invoke("ReloadLevel", delayLoadScene);
        
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
}
