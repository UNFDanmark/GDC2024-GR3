using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioSource PickupSound;

    public float PickupDespawnTime = 10;
    private float RemainingDespawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        PickupSound = GetComponent<AudioSource>();
        RemainingDespawnTime = PickupDespawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (RemainingDespawnTime >= 0)
        {
            RemainingDespawnTime = RemainingDespawnTime - Time.deltaTime;
        }

        if (RemainingDespawnTime <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickupSound.Play();
        }
    }
}
