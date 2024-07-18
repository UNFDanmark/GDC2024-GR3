using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasWonCondition : MonoBehaviour
{
    public static int HasWon;
    public GameObject Star;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("q") && Input.GetKey("p"))
        {
            HasWon = 0;
            print("Reset");
        }

        if (HasWon == 0)
        {
            Star.SetActive(false);
        }
        if (HasWon == 1)
        {
            Star.SetActive(true);
        }
    }

    public void ChangedWinState()
    {
        HasWon = 1;
    }
}
