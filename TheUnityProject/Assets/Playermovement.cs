using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Playermovement : MonoBehaviour
{
    public float speed = 10f;
    public float JumpHeight = 10f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = rb.velocity;
            movement.x = Input.GetAxisRaw("Horizontal") * speed;
            movement.z = Input.GetAxisRaw("Vertical") * speed;
                rb.velocity = movement;
        
        if(Input.GetButtonDown("Jump"));
            movement.y = JumpHeight;
            //rb.velocity = movement;


    }
}
