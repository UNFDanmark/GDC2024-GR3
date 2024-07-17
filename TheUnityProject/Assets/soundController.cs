using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public List<AudioSource> AudioSources;
    public List<AudioClip> AudioClips;
    
    // Start is called before the first frame update
    void Start()
    {
      
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

   public void playaudio(int i)
    {
        foreach (var AudioSource in AudioSources)
        {
            if (AudioSource.isPlaying)
            {
               continue; 
            }

            AudioSource.clip = AudioClips[i];
            AudioSource.Play();
            break;
        }

    }

}
