using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public AudioSource HealthPickUpSounds;

    public int Healing = 1;
    public float PickupDespawnTime = 10;
    private float RemainingDespawnTime;
    // Start is called before the first frame update
    public soundController SoundController;
    void Start()
    {
        HealthPickUpSounds = GetComponent<AudioSource>();
        
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
            other.gameObject.GetComponent<Playermovement>().HealthPickedUp(Healing);
           // HealthPickUpSounds.Play();
           AudioSource.PlayClipAtPoint(HealthPickUpSounds.clip, transform.position);
            Destroy(gameObject);
        }
    }
}
