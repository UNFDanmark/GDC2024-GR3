using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    public GameObject FireParticle;
    public GameObject WaterParticle;
    public GameObject LeafParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootParticle(int Element)
    {
        if (Element == 1)
        {
            WaterParticle.GetComponent<ParticleSystem>().Play();
            print("water");
        }
        if (Element == 2)
        {
            WaterParticle.GetComponent<ParticleSystem>().Play();
        }
        if (Element == 3)
        {
            WaterParticle.GetComponent<ParticleSystem>().Play();
        }
    }
}
