using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float delayLoadScene = 1f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip successSound;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem successParticle;
    

    AudioSource audioSource;

    bool isTransitioning = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
    }
    void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) { return; }    //if isTransitioning is true return

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Friendly no action");
                break;

            case "Fuel":
                //create mechanic for fuel, sound etc
                Debug.Log("Fuel Collected");
                break;

            case "Finish":
                SuccessSeequence();
                break;

            case "Point":
                Debug.Log("Point collected");
                break;

            case "Life":
                //create mechanic for lives collection + sound etc
                Debug.Log("Life collected");
                break;

            default:
                CrashSeequence();
                break;
        }
    }

    void SuccessSeequence()
    {
        isTransitioning = true;
        GetComponent<Player_Movement>().enabled = false;
        audioSource.Stop();                                 //will stop all sounds prior of playing success sound next
        audioSource.PlayOneShot(successSound);
        successParticle.Play();
        Invoke("LoadNextLevel", delayLoadScene);
    }

    void CrashSeequence()
    {
        isTransitioning = true;
        GetComponent<Player_Movement>().enabled = false;
        audioSource.Stop();                                 //will stop all sounds prior of playing success sound next
        audioSource.PlayOneShot(crashSound);
        crashParticle.Play();
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
