using System;
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
    public int Element;
    public int MaxAmmo = 10;
    public int CurrentAmmo;
    public float MeleeUptime = 1;
    private float RemainingMeleeCooldown;
    public float CooldownTime = 0.3f;
    public GameObject MeleeHitbox;
    private float remainingCooldown;
    public float WaterBulletSpeed = 20f;
    public float FireBulletSpeed = 20f;
    public float GrassBulletSpeed = 20f;
    public AudioSource CastingSounds;
    public bool AutoPickup;
    public Animator animatorLeft;
    public Animator animatorRight;

    public TextMeshProUGUI AmmoTekst;
    public soundController SoundController;

    public GameObject ParticleSpawner;

    // Start is called before the first frame update
    void Start()
    {
        remainingCooldown = CooldownTime;
        RemainingMeleeCooldown = MeleeUptime;
        ParticleSpawner = GameObject.Find("ParticleSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        //AmmoTekst.text = "Ammo: " + CurrentAmmo.ToString() + "/" + MaxAmmo.ToString();
        remainingCooldown = remainingCooldown - Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && remainingCooldown <= 0 && CurrentAmmo > 0)
        {
            animatorRight.SetTrigger("Cast");
            animatorLeft.SetTrigger("Cast");
            if (Element == 1)
            {
                GameObject bullet = Instantiate(WaterBulletPrefab, transform.position, Quaternion.identity);
                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.velocity = transform.forward * WaterBulletSpeed;
                remainingCooldown = CooldownTime;
                CurrentAmmo -= 1;
                SoundController.playaudio(1);
                ParticleSpawner.GetComponent<ParticlePlayer>().ShootParticle(1);
            }

            if (Element == 2)
            {
                GameObject bullet = Instantiate(FireBulletPrefab, transform.position, Quaternion.identity);
                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.velocity = transform.forward * FireBulletSpeed;
                remainingCooldown = CooldownTime;
                CurrentAmmo -= 1;

                ParticleSpawner.GetComponent<ParticlePlayer>().ShootParticle(2);
               // CastingSounds.Play();
               SoundController.playaudio(1);
            }

            if (Element == 3)
            {
                GameObject bullet = Instantiate(GrassBulletPrefab, transform.position, Quaternion.identity);
                Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                bulletRB.velocity = transform.forward * GrassBulletSpeed;
                remainingCooldown = CooldownTime;
                CurrentAmmo -= 1;
                ParticleSpawner.GetComponent<ParticlePlayer>().ShootParticle(3);
                SoundController.playaudio(1);
            }
            


        }
        animatorLeft.SetTrigger("Exit");
        animatorRight.SetTrigger("Exit");

        if (RemainingMeleeCooldown >= 0)
        {
            RemainingMeleeCooldown = RemainingMeleeCooldown - Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (RemainingMeleeCooldown > 0)
            {
                animatorLeft.SetTrigger("Punch");
                animatorRight.SetTrigger("Punch");
                MeleeHitbox.SetActive(true);
                

            }
        }

        if (RemainingMeleeCooldown <= 0)
        {
            MeleeHitbox.SetActive(false);
            RemainingMeleeCooldown = MeleeUptime;
            animatorLeft.SetTrigger("Exit");
            animatorRight.SetTrigger("Exit");
        }


        if (Input.GetKeyDown(KeyCode.E) && AutoPickup == false)
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

    private void OnTriggerEnter(Collider other)
    {
        if (AutoPickup == true)
        {
            if (other.gameObject.CompareTag("WaterPickup"))// && CurrentAmmo == 0)
            {
                Element = 1;
                Destroy(other.gameObject);
                CurrentAmmo = MaxAmmo;
            }

            if (other.gameObject.CompareTag("FirePickup"))// && CurrentAmmo == 0)
            {
                Element = 2;
                Destroy(other.gameObject);
                CurrentAmmo = MaxAmmo;
            }

            if (other.gameObject.CompareTag("GrassPickup")) //&& CurrentAmmo == 0)
            {
                Element = 3;
                Destroy(other.gameObject);
                CurrentAmmo = MaxAmmo;
            }
        }
    }
}
