using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public GameObject[] EnergySegments;

    public GameObject Camera;

    public int Ammo;
    
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Ammo = Camera.GetComponent<BulletSpawner>().CurrentAmmo;

        foreach (GameObject g in EnergySegments)
        {
            string Name = g.name;

            int NameNumber = Int32.Parse(Name);
            
            Debug.Log(NameNumber);
            
            if (NameNumber > Ammo)
            {
                RemoveSegment(g);
            }
            else
            {
                DisplaySegment(g);
            }
        }
    }

    private void RemoveSegment(GameObject Segment)
    {
        Segment.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
    
    private void DisplaySegment(GameObject Segment)
    {
        Segment.GetComponent<Image>().color = new Color(255, 255, 255, 255);
    }
}
