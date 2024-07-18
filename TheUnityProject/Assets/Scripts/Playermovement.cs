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
    public int CurrentHealth;
    public int PlayerLowHealth = 10;
    public GameObject GameOverScreen;
    public TextMeshProUGUI LivTekst;
    //public int Healing = 1;
    
    public bool HasJumped;
    
    public soundController SoundController;
    public int CurrentScore;
    public int EnemyScore = 100;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI FinalScore;
    public GameObject AmmoBar;
    public GameObject ScoreTextObject;
    
    
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        CurrentHealth = PlayerHealth;
        
        SoundController.playmusic(1);
        Time.timeScale = 1;
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

        ScoreText.text = "Score:" + CurrentScore.ToString();

        if (CurrentHealth <= 0)
        {
            FinalScore.text = "Score:" + CurrentScore.ToString();
            AmmoBar.SetActive(false);
            ScoreTextObject.SetActive(false);
            GameOverScreen.SetActive(true);
            SoundController.playmusic(0);
            Time.timeScale = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && HasJumped == false)
        {
            movement.y = JumpHeight;
            HasJumped = true;
            SoundController.playaudio(2);
        }
            
      
        
        

        rb.velocity = movement;
        
        //LivTekst.text = "Liv: " + CurrentHealth.ToString() + "/" + PlayerHealth.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene("TitleScreen");
        }
        
        if(CurrentHealth<PlayerLowHealth && CurrentHealth > 0)
        {
            SoundController.playheartbeat();
        }

        
        if (( rb.velocity.x >0 || rb.velocity.z >0) &&  !HasJumped )
        {
            SoundController.playFootsteps();
        }
        
        
        // if (CurrentHealth <= 0)
        // {
        //     SceneManager.LoadScene("TitleScreen");
        //     Time.timeScale = 0;
        //     GameOverScreen.SetActive(true);
        //     SoundController.playmusic(0);
        // }
        
        
        
       
     

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            HasJumped = false;
            //audioSource.PlayOneShot(Landing);
        }
    }   
    

    public void HealthPickedUp(int Healing)
    {
        CurrentHealth += Healing;
    }

    public void BulletDamage()
    {
        CurrentHealth -= 1;
        SoundController.playaudio(4);
    }

    public void ScoreAdded()
    {
        CurrentScore += EnemyScore;
    }

    
    

}
