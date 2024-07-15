using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrassEnemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject Bulletprefab;
    
    public float EnemyCooldownTime = 0.3f;

    private float remainingCooldown;
    public float EnemyBulletSpeed = 20f;
    public int EnemyHealth = 3;
    public int SuperEffective = 3;
    public int Normal = 1;
        
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        agent.SetDestination(player.transform.position);
        remainingCooldown = EnemyCooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainingCooldown = remainingCooldown - Time.deltaTime;
        agent.SetDestination(player.transform.position);
        
        if (Vector3.Distance(transform.position,player.transform.position) <= 10 && remainingCooldown<=0)
        {
            Vector3 directiontoplayer = player.transform.position - transform.position;
            directiontoplayer = directiontoplayer.normalized;
            GameObject bullet = Instantiate(Bulletprefab, transform.position, Quaternion.identity);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = directiontoplayer * EnemyBulletSpeed;
            remainingCooldown = EnemyCooldownTime;
        }
    }

    private void OnCollisionEnter(Collision  other)
    {
        if (other.gameObject.CompareTag("WaterBullet"))
        {
            EnemyHealth -= Normal;
            if (EnemyHealth <= 0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
            
        }

        if (other.gameObject.CompareTag("FireBullet"))
        {
            EnemyHealth -= SuperEffective;
            if (EnemyHealth <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(other.gameObject);
            
        }

        if (other.gameObject.CompareTag("GrassBullet"))
        {
            
            EnemyHealth -= Normal;
            if (EnemyHealth <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(other.gameObject);
        }
    }
}
