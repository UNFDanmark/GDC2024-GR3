using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject WaterBulletPrefab;
    public GameObject FireBulletPrefab;
    public GameObject GrassBulletPrefab;
    private int Element = 0;
    public int MaxAmmo = 10;
    private int CurrentAmmo;
    
    public float CooldownTime = 0.3f;

    private float remainingCooldown;
    public float WaterBulletSpeed = 20f;
    public float FireBulletSpeed = 20f;
    public float GrassBulletSpeed = 20f;

    public TextMeshProUGUI AmmoTekst;
    // Start is called before the first frame update
    void Start()
    {
        remainingCooldown = CooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        AmmoTekst.text = "Ammo: " + CurrentAmmo.ToString() + "/" + MaxAmmo.ToString();
        remainingCooldown = remainingCooldown - Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && remainingCooldown <= 0 && CurrentAmmo > 0)
        {
            if (Element == 1)
            {
                GameObject bullet = Instantiate(WaterBulletPrefab, transform.position, Quaternion.identity);
                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.velocity = transform.forward * WaterBulletSpeed;
                remainingCooldown = CooldownTime;
                CurrentAmmo -= 1;
            }

            if (Element == 2)
            {
                GameObject bullet = Instantiate(FireBulletPrefab, transform.position, Quaternion.identity);
                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.velocity = transform.forward * FireBulletSpeed;
                remainingCooldown = CooldownTime;
                CurrentAmmo -= 1;
            }

            if (Element == 3)
            {
                GameObject bullet = Instantiate(GrassBulletPrefab, transform.position, Quaternion.identity);
                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.velocity = transform.forward * GrassBulletSpeed;
                remainingCooldown = CooldownTime;
                CurrentAmmo -= 1;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit Pickup, 5))
            {
                if (Pickup.transform.CompareTag("WaterPickup") && CurrentAmmo == 0)
                {
                    Element = 1;
                    Destroy(Pickup.transform.gameObject);
                    CurrentAmmo = MaxAmmo;
                }

                if (Pickup.transform.CompareTag("FirePickup") && CurrentAmmo == 0)
                {
                    Element = 2;
                    Destroy(Pickup.transform.gameObject);
                    CurrentAmmo = MaxAmmo;
                }

                if (Pickup.transform.CompareTag("GrassPickup") && CurrentAmmo == 0)
                {
                    Element = 3;
                    Destroy(Pickup.transform.gameObject);
                    CurrentAmmo = MaxAmmo;
                }
            }
        }
    }
}
