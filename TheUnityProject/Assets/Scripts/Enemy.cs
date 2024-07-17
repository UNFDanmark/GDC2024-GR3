using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject Bulletprefab;

    public GameObject WeedPickup;

    public GameObject WaterPickup;

    public GameObject FirePickup;
    public GameObject HealthPickup;
    public int MinHealthRandom;
    public int MaxHealthRandom;
    public float EnemyCooldownTime = 0.3f;
    public int EnemyElement;
    private float remainingCooldown;
    public float EnemyBulletSpeed = 20f;
    public int EnemyHealth = 3;
    public int SuperEffective = 3;
    public int Normal = 1;
    public bool HealthPickupGuarentuee = false;
    public AudioSource EnemyHitSound;
    public Animator animator;
    private Rigidbody EnemyRB;
    
    

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent.SetDestination(player.transform.position);
        remainingCooldown = EnemyCooldownTime;
        EnemyHitSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        remainingCooldown = remainingCooldown - Time.deltaTime;
        agent.SetDestination(player.transform.position);

        if (Vector3.Distance(transform.position, player.transform.position) <= 10 && remainingCooldown <= 0)
        {
            Vector3 directiontoplayer = player.transform.position - transform.position;
            directiontoplayer = directiontoplayer.normalized;
            GameObject bullet = Instantiate(Bulletprefab, transform.position, Quaternion.identity);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = directiontoplayer * EnemyBulletSpeed;
            remainingCooldown = EnemyCooldownTime;
            animator.SetTrigger("EnemyShoot");
        }
        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
            int HealthRandom = Random.Range(MinHealthRandom, MaxHealthRandom);
            if (EnemyElement==1)
            {
                Instantiate(WaterPickup, transform.position, Quaternion.identity);
            }
            if (EnemyElement==2)
            {
                Instantiate(FirePickup, transform.position, Quaternion.identity);
            }
            if (EnemyElement==3)
            {
                Instantiate(WeedPickup, transform.position, Quaternion.identity);
            }
            if (HealthPickupGuarentuee == true)
            {
                Instantiate(HealthPickup,transform.position, Quaternion.identity);
            }

            if (HealthRandom == 1)
            {
                Instantiate(HealthPickup,transform.position,Quaternion.identity);
            }
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (EnemyElement == 1)
        {
            if (other.gameObject.CompareTag("WaterBullet"))
            {
                EnemyHealth -= Normal;
                EnemyHitSound.Play();

                Destroy(other.gameObject);

            }

            if (other.gameObject.CompareTag("FireBullet"))
            {
                EnemyHealth -= Normal;
                EnemyHitSound.Play();

                Destroy(other.gameObject);

            }

            if (other.gameObject.CompareTag("GrassBullet"))
            {

                EnemyHealth -= SuperEffective;
                EnemyHitSound.Play();


                Destroy(other.gameObject);

            }
        }

        if (EnemyElement == 2)
        {
            if (other.gameObject.CompareTag("WaterBullet"))
            {
                EnemyHealth -= SuperEffective;
                EnemyHitSound.Play();


                Destroy(other.gameObject);

            }

            if (other.gameObject.CompareTag("FireBullet"))
            {
                EnemyHealth -= Normal;
                EnemyHitSound.Play();
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("GrassBullet"))
            {
                EnemyHealth -= Normal;
                EnemyHitSound.Play();
                Destroy(other.gameObject);
            }
        }

        if (EnemyElement == 3)
        {
            if (other.gameObject.CompareTag("WaterBullet"))
            {
                EnemyHealth -= Normal;
                EnemyHitSound.Play();
                Destroy(other.gameObject);

            }

            if (other.gameObject.CompareTag("FireBullet"))
            {
                EnemyHealth -= SuperEffective;
                EnemyHitSound.Play();
                Destroy(other.gameObject);

            }

            if (other.gameObject.CompareTag("GrassBullet"))
            {
                EnemyHealth -= Normal;
                EnemyHitSound.Play();
                Destroy(other.gameObject);
            }

        }
    }
    
    

    public void TakeDamage(int damage)
    {
        print("melee hit");
        EnemyHealth -= damage;
        EnemyHitSound.Play();
        
    }

    public void AddScore()
    {
        
    }
}
