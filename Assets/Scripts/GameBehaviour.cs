using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameBehaviour : MonoBehaviour
{
    private int _pointsCollected = 0;
    private float _fuel = 200f;
    private int _lives = 3;

    public TextMeshProUGUI poitnsUI;
    public TextMeshProUGUI fuelUI;
    public TextMeshProUGUI livesUI;
    

    void Start()
    {
        poitnsUI.text += " " + _pointsCollected;
        livesUI.text += " " + _lives;
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
        } 
    }

    public int Lives
    {
        get { return _lives; }
        set 
        { 
            _lives = value; 
            livesUI.text = "Lives: " + Lives.ToString();
        }
    }
}
