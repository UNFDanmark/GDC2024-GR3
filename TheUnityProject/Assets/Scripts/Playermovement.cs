using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class Playermovement : MonoBehaviour
{
    public float speed = 10f;
    public float JumpHeight = 10f;
    public int PlayerHealth = 10;
    private int CurrentHealth;
    public GameObject GameOverScreen;
    public TextMeshProUGUI LivTekst;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        CurrentHealth = PlayerHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3();
        
        
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
        
        
            


    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullets"))
        {
            if (CurrentHealth <= 0)
            {
                Time.timeScale = 0;
                GameOverScreen.SetActive(true);
            }
            Destroy(other.gameObject);
            CurrentHealth -= 1;
            LivTekst.text = "Liv: " + CurrentHealth.ToString() + "/" + PlayerHealth.ToString();
            
        }
        
    }
}
