using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroyer : MonoBehaviour
{
    public float BulletDestroyCD = 2f;

    private float remainingBulletCD;
    // Start is called before the first frame update
    void Start()
    {
        remainingBulletCD = BulletDestroyCD;
    }

    // Update is called once per frame
    void Update()
    {
        remainingBulletCD = remainingBulletCD - Time.deltaTime;
        if (remainingBulletCD <= 0)
        {
            Destroy(gameObject);
            remainingBulletCD = BulletDestroyCD;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

        
    }
}
