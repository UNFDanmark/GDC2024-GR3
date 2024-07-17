using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


public class Playermovement : MonoBehaviour
{
    public float speed = 10f;
    public float JumpHeight = 10f;
    public int PlayerHealth = 10;
    private int CurrentHealth;
    public GameObject GameOverScreen;
    public TextMeshProUGUI LivTekst;
    //public int Healing = 1;
    AudioSource audioSource;
    public bool HasJumped;
    public AudioClip Landing;
    public AudioClip Jump;
    
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        CurrentHealth = PlayerHealth;
        audioSource = GetComponent<AudioSource>();
        //Landing = GetComponent<AudioSource>();
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
        

        
        
        if (Input.GetKeyDown(KeyCode.Space) && HasJumped == false)
        {
            movement.y = JumpHeight;
            HasJumped = true;
            audioSource.PlayOneShot(Jump);
        }
            
        GetComponent<AudioSource>().Play();
        
        

        rb.velocity = movement;
        
        //LivTekst.text = "Liv: " + CurrentHealth.ToString() + "/" + PlayerHealth.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
            Time.timeScale = 1;
        }
        
        if (CurrentHealth <= 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
     

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            HasJumped = false;
            //audioSource.PlayOneShot(Landing);
        }
    }   

    private void OnCollisionEnter(Collision other)
    {
        
    }

    public void HealthPickedUp(int Healing)
    {
        CurrentHealth += Healing;
    }

    public void BulletDamage()
    {
        CurrentHealth -= 1;
    }


}
