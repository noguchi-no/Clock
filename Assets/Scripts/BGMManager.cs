using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BGMManager : MonoBehaviour
{
    public AudioSource audioSource;
    public void ClockSound()
    {
        audioSource.Play();
    }
    public void ClockStop()
    {
        audioSource.mute = !audioSource.mute;
    }
}
