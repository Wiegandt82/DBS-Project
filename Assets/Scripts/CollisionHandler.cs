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
                //create login for lives collection + sound etc
                Debug.Log("Life collected");
                break;

            default:
                CrashSeequence();
                break;
        }
    }

    void SuccessSeequence()
    {
        GetComponent<Player_Movement>().enabled = false;
        audioSource.PlayOneShot(successSound);
        //add particle effect
        Invoke("LoadNextLevel", delayLoadScene);
    }

    void CrashSeequence()
    {
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
