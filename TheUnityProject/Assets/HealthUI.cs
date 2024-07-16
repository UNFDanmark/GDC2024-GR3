using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject[] HHearts;

    public GameObject Player;

    public int Health;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Health = Player.GetComponent<Playermovement>().PlayerHealth;

        foreach (GameObject g in HHearts)
        {
            string Name = g.name;

            int NameNumber = Int32.Parse(Name);
            
            if (NameNumber > Health)
            {
                MakeHHeartBlack(g);
            }
            else
            {
                MakeHHeartColor(g);
            }
        }
    }

    private void MakeHHeartBlack(GameObject Heart)
    {
        Heart.GetComponent<Image>().color = new Color(0, 0, 0);
    }
    
    private void MakeHHeartColor(GameObject Heart)
    {
        Heart.GetComponent<Image>().color = new Color(255, 255, 255);
    }
}