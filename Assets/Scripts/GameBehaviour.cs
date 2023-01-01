using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private static int _pointsCollected = 0;
    private float _fuel = 200f;
    private static int _lives = 3;

    public TextMeshProUGUI poitnsUI;
    public TextMeshProUGUI fuelUI;
    public TextMeshProUGUI livesUI;

    public CollisionHandler CollisionHandler;

    public Button GameOverButton;

    void Start()
    {
        poitnsUI.text += " " + _pointsCollected;
        livesUI.text += " " + _lives;
        CollisionHandler = GameObject.Find("Player").GetComponent<CollisionHandler>();
    }



    public int Points
    {
        get { return _pointsCollected; }
        set 
        { 
            _pointsCollected = value; 
            poitnsUI.text = "Points: " + Points.ToString();
        }
    }

    public float Fuel 
    { 
        get { return _fuel; } 
        set 
        { 
            _fuel = value; 
            fuelUI.text = "Fuel";

            if (_fuel <= 0)
            {
                CollisionHandler.CrashSeequence();
            }
        } 
    }

    public int Lives
    {
        get { return _lives; }
        set 
        { 
            _lives = value; 
            livesUI.text = "Lives:   " + Lives.ToString();

            if (_lives == 0)
            {
                GameOverSeequence();
            }
        }
    }

    public void GameOverSeequence()
    {
        GameOverButton.gameObject.SetActive(true);
    }

    public void GameOverButtonClick()
    {
        _pointsCollected = 0;
        _fuel = 200f;
        _lives = 3;
        SceneManager.LoadScene(0);
    }
}
