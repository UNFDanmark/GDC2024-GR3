using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyRotation : MonoBehaviour
{
    public float rotation = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseHorizontal = Input.GetAxis("Mouse X");
        transform.Rotate(0, MouseHorizontal * rotation, 0);
    }
}