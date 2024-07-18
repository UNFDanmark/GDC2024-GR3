using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class HasWonCondition : MonoBehaviour
{
    public static int HasWon;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q") && Input.GetKey("å"))
        {
            HasWon = 0;
            print("Reset");
        }

        if (HasWon == 0)
        {
            GameObject.Find("star").SetActive(false);
        }
        if (HasWon == 1)
        {
            GameObject.Find("star").SetActive(true);
        }
    }
}
