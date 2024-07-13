using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCam : MonoBehaviour
{
    public float VerticalRotation = 200000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MouseVertical = Input.GetAxisRaw("Mouse Y");
        transform.Rotate(MouseVertical*VerticalRotation* -1 * Time.deltaTime,0, 0);
    }
}
