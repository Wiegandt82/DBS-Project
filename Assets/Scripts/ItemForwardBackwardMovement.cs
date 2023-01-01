using UnityEngine;

public class ItemForwardBackwardMovement : MonoBehaviour
{
    Vector3 startingPosition;                               //starting position of object
    [SerializeField] Vector3 movementVector;                //axis on which movement will happen
    [SerializeField][Range(0, 1)] float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*if statement to avoid NAN error when setting period to 0, 
         Mathf.Epsioln used as we should not compare floats to 0*/
        if (period == Mathf.Epsilon) { return; }         

        float cycle = Time.time / period;                       
        
        const float tau = Mathf.PI * 2;                         //value of 6.28 
        float sinWaveBasic = Mathf.Sin(cycle * tau);            //value from -1 to 1

        /*sin wave is from -1to1, by adding 1 we change it
        to 0to2, by dividing by 2 we change it to 0to1*/
        movementFactor = (sinWaveBasic + 1f) / 2f;              
                                                                
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

    }
}
