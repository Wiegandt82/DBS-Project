using UnityEngine;
using UnityEngine.UI;

public class SliderValueText : MonoBehaviour
{
    [SerializeField] private Slider slider;

    GameBehaviour gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = gameManager.Fuel;
    }
}
