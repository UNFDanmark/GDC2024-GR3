using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl1Button : MonoBehaviour
{
    public void StartLvl1()
    {
        SceneManager.LoadScene("GameLevel");
    }
    
}
