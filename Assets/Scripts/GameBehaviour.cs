using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameBehaviour : MonoBehaviour
{
    private int _pointsCollected = 0;
    private int _fuel = 1000;
    private int _lives = 3;

    public TextMeshProUGUI poitnsUI;
    public TextMeshProUGUI fuelUI;
    public TextMeshProUGUI livesUI;

    void Start()
    {
        poitnsUI.text += " " + _pointsCollected;
        fuelUI.text += " " + _fuel;
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

    public int Fuel 
    { 
        get { return _fuel; } 
        set 
        { 
            _fuel = value; 
            fuelUI.text = "Fuel: " + Fuel.ToString();
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
