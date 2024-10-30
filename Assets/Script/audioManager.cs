using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip background; // Assign this in the Inspector

    private void Start()
    {
        Debug.Log("BG music will playing");
        musicSource.clip = background;
        musicSource.Play();
    }

    /*public void ButtonClick()
    {
        Debug.Log("Button clicked, attempting to play sound.");
        musicSource.clip = background;
        musicSource.Play();
    }*/
}
