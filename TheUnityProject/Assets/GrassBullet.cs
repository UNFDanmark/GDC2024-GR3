using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassBullet : MonoBehaviour
{
    public float GrassBulletDestroyCD = 2f;

    private float remainingBulletCD; 
    // Start is called before the first frame update
    void Start()
    {
        remainingBulletCD = GrassBulletDestroyCD;
    }

    // Update is called once per frame
    void Update()
    {
        remainingBulletCD = remainingBulletCD - Time.deltaTime;
        if (remainingBulletCD <= 0)
        {
            Destroy(gameObject);
            remainingBulletCD = GrassBulletDestroyCD;
        }
    }
}
