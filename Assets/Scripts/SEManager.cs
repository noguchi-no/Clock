using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SEManager : MonoBehaviour {

    public AudioClip run;
    public AudioClip walk;
    public AudioClip heart;
    public AudioClip clock;
    public AudioClip clockStop;
    AudioSource audioSource;
    void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void RunSE()
    {
        audioSource.PlayOneShot(run, 1.0f);
    }
    public void HeartSE()
    {
        audioSource.PlayOneShot(heart, 1.0f);
    }
    public void WalkSE()
    {
        audioSource.PlayOneShot(walk, 1.0f);
    }

}
