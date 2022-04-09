using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class hat_sound_script : MonoBehaviour
{

    public AudioSource walk;
    public AudioSource eat;
    public AudioSource key;
    public AudioSource killed;
    public AudioSource door;
    public AudioSource trap;
    public bool play;

    // Start is called before the first frame update
    void Start()
    {
        play=false;
        trap.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(play){
            if(!walk.isPlaying){
                walk.Play();
            }
        }
        
        else{
            walk.Stop();
        }

    }

    public void eat_sound(){
        eat.Play();
    }

    public void keys_sound(){
        key.Play();
    }

    public void killed_sound(){
        killed.Play();
    }

    public void stop_walking(){
        walk.Stop();
    }

    public void door_opened(){
        door.Play();
    }

    public void trap_laid(){
        trap.Play();
    }

}
