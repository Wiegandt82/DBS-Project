using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;
    public GameObject PauseMenuCanvas;

    public GameBehaviour gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Play();
            }
            else
            {
                Stop();
            }
        }
    }

    public void Stop()
    {
        PauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Play()
    {
        PauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void MainMenuButton()
    {
        gameManager.Fuel = 200f;
        gameManager.Lives = 3;
        gameManager.Points = 0;
        SceneManager.LoadScene(0);
        
    }
}
