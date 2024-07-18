using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public AudioSource PickupSound;

    public float PickupDespawnTime = 10;
    private float RemainingDespawnTime;
    public soundController SoundController;

    public bool IsWinItem;
    

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        PickupSound = GetComponent<AudioSource>();
        
        RemainingDespawnTime = PickupDespawnTime;
        player = GameObject.Find("player");
        
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
           AudioSource.PlayClipAtPoint(PickupSound.clip, transform.position);
           if (IsWinItem)
           {
               Win();
           }
        }
    }

    public void Win()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
