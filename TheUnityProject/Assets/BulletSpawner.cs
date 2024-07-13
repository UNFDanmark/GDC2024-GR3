using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bulletprefab;
    
    public float CooldownTime = 0.3f;

    private float remainingCooldown;
    public float BulletSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        remainingCooldown = CooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        remainingCooldown = remainingCooldown - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && remainingCooldown <= 0)
        {
            GameObject bullet = Instantiate(Bulletprefab, transform.position, Quaternion.identity);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = transform.forward * BulletSpeed;
            remainingCooldown = CooldownTime;
        } 
    }
}
