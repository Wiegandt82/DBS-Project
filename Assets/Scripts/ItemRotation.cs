using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    [SerializeField] Vector3 rotationDirection; 
    Transform itemTransform;

    // Start is called before the first frame update
    void Start()
    {
        itemTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        itemTransform.Rotate(rotationDirection * Time.deltaTime);
    }
}
