using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Playermovement : MonoBehaviour
{
    public float speed = 10f;
    public float JumpHeight = 10f;
    public int PlayerHealth = 10;
    private int CurrentHealth;
    public GameObject GameOverScreen;
    public TextMeshProUGUI LivTekst;
    public int Healing = 1;

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
        
        //LivTekst.text = "Liv: " + CurrentHealth.ToString() + "/" + PlayerHealth.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
            Time.timeScale = 1;
        }
            
     

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthPickup"))
        {
            Destroy(other.gameObject);
            if (CurrentHealth < PlayerHealth)
            {
                CurrentHealth += Healing ;
            }
        }
    }   

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("EnemyBullets"))
        {
            CurrentHealth -= 1;
            if (CurrentHealth <= 0)
            {
                Time.timeScale = 0;
                GameOverScreen.SetActive(true);
            }
            Destroy(other.gameObject);
            
            
            
        }
        
    }

    
}
