using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Playermovement : MonoBehaviour
{
    public float speed = 10f;
    public float JumpHeight = 10f;
    public float HorizontalRotation = 2f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        /*= rb.velocity;
        movement.x = transform.forward.x * Input.GetAxisRaw("Horizontal") * speed;
        movement.z = transform.forward.z * Input.GetAxisRaw("Vertical") * speed;
        */
        
        // direction
        movement += transform.forward * Input.GetAxisRaw("Vertical");
        movement += transform.right * Input.GetAxisRaw("Horizontal");

        
        //velocity
        movement = movement.normalized * speed;
        movement.y = rb.velocity.y;
        

        if (transform.position.y <= 1)
        {
            if(Input.GetKeyDown(KeyCode.Space))
                movement.y = JumpHeight;
        }
        

        rb.velocity = movement;
        
        float MouseHorizontal = Input.GetAxisRaw("Mouse X");
        transform.Rotate(0, MouseHorizontal * HorizontalRotation, 0);
            


    }
}
