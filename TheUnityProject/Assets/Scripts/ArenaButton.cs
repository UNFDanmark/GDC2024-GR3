using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArenaButton : MonoBehaviour
{
    public void StartArena()
    {
        SceneManager.LoadScene("Arena");
    }
    
}
