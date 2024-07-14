using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScripts : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject Bulletprefab;
    
    public float EnemyCooldownTime = 0.3f;

    private float remainingCooldown;
    public float EnemyBulletSpeed = 20f;
        
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
        if (other.gameObject.CompareTag("Bullets"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
