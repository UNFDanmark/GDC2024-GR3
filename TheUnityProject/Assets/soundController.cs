using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundController : MonoBehaviour
{
    public List<AudioSource> AudioSources;
    public List<AudioClip> AudioClips;
    public AudioSource AudioSourcesMusic;
    public List<AudioClip> musicClips;
    
    public AudioClip heartbeat;
    public AudioSource AudioSourcesHeartBeat;


    public List<AudioClip> footsteps;
    public AudioSource footplayer;
    
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
    public void playmusic(int i)
    {
        
            if (AudioSourcesMusic.clip != musicClips[i] && AudioSourcesMusic.isPlaying )
            {
                AudioSourcesMusic.clip = musicClips[i];  
                AudioSourcesMusic.Play();
            }
    }
   
    public void playheartbeat()
    {
        
        if (!AudioSourcesHeartBeat.isPlaying)
        {
            AudioSourcesHeartBeat.Play();
        }
        
    }

    public void playFootsteps()
    {
        if (!footplayer.isPlaying)
        {
            footplayer.clip = footsteps[Random.Range(0,5)];
            footplayer.pitch = Random.Range(0.8f, 1.4f);
            footplayer.Play(); 
            
        } 
        
    }
    
    
    
   
   
}
