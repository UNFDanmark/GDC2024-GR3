using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioSource PickUpSounds;
    // Start is called before the first frame update
    void Start()
    {
        PickUpSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            PickUpSounds.Play();
        }
    }
}
