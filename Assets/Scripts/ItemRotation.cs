using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    [SerializeField] int rotationSpeed = 100;

    Transform itemTransform;
    // Start is called before the first frame update
    void Start()
    {
        itemTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        itemTransform.Rotate(0, rotationSpeed * Time.deltaTime, 0 );
    }
}
