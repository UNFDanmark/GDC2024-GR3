using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public AudioSource Bonk;
    public int Damage = 1;
    public soundController SoundController;
    // Start is called before the first frame update
    void Start()
    {
       // Bonk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           
            print("hit enemy");
            Enemy e = other.gameObject.GetComponent<Enemy>();
            e.TakeDamage(Damage);
          //  Bonk.Play();
            SoundController.playaudio(0);
        }
            
    }
}
