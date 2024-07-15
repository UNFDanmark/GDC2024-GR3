using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject WaterBulletPrefab;
    public GameObject FireBulletPrefab;
    public GameObject GrassBulletPrefab;
    private int Element = 0;
    
    public float CooldownTime = 0.3f;

    private float remainingCooldown;
    public float WaterBulletSpeed = 20f;
    public float FireBulletSpeed = 20f;
    public float GrassBulletSpeed = 20f;
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
            GameObject bullet = Instantiate(WaterBulletPrefab, transform.position, Quaternion.identity);
            Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
            bulletRB.velocity = transform.forward * WaterBulletSpeed;
            remainingCooldown = CooldownTime;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit Pickup, 5))
            {
                if (Pickup.transform.CompareTag("WaterPickup"))
                {
                    Destroy(Pickup.transform.gameObject);
                }

                if (Pickup.transform.CompareTag("FirePickup"))
                {
                    Destroy(Pickup.transform.gameObject);
                }

                if (Pickup.transform.CompareTag("GrassPickup"))
                {
                    Destroy(Pickup.transform.gameObject);
                }
            }
        }
    }
}
