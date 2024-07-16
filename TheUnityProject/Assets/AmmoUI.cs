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

    public Color FireColor;

    public Color WaterColor;

    public Color FloralColor;

    public int CurrentElement;

    public Sprite FireSprite;
    public Sprite WaterSprite;
    public Sprite FloralSprite;
    
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
            
            if (NameNumber > Ammo)
            {
                RemoveSegment(g);
            }
            else
            {
                DisplaySegment(g);
            }
        }

        CurrentElement = Camera.GetComponent<BulletSpawner>().Element;
        
        if (CurrentElement == 0)
        {
            print("you are boring");
            foreach (GameObject g in EnergySegments)
            {
                g.GetComponent<Image>().color = new Color(255, 255, 255, 0);
                
            }
        }
        if (CurrentElement == 1)
        {
            print("you are blue");
            foreach (GameObject g in EnergySegments)
            {
                g.GetComponent<Image>().color = WaterColor;
                GameObject.Find("Icon").GetComponent<Image>().sprite = WaterSprite;
            }
        }
        if (CurrentElement == 2)
        {
            print("you are red");
            
            foreach (GameObject g in EnergySegments)
            {
                g.GetComponent<Image>().color = FireColor;
                GameObject.Find("Icon").GetComponent<Image>().sprite = FireSprite;
            }
        }
        if (CurrentElement == 3)
        {
            print("you are green");
            foreach (GameObject g in EnergySegments)
            {
                g.GetComponent<Image>().color = FloralColor;
                GameObject.Find("Icon").GetComponent<Image>().sprite = FloralSprite;
            }
        }
    }

    private void RemoveSegment(GameObject Segment)
    {
        //Segment.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        Segment.SetActive(false);
    }
    
    private void DisplaySegment(GameObject Segment)
    {
        //Segment.GetComponent<Image>().color = new Color(255, 255, 255, 255);
        Segment.SetActive(true);
    }
}
