using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    Vector3 startingPosition;                               //starting position of object
    [SerializeField] Vector3 movementVector;                //distance the object will be moved
    [SerializeField][Range(0, 1)] float movementFactor;     //set range between 0 and 1 for moving factor
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycle = Time.time / period;

        const float tau = Mathf.PI * 2;                         //full c
        float sinWaveBasic = Mathf.Sin(cycle * tau);

        /*sin wave is from -1to1, by adding 1 we change it
        to 0to2, by dividing by 2 we change it to 0to1*/
        movementFactor = (sinWaveBasic + 1f) / 2f;              
                                                                
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

    }
}
