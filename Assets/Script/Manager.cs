using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public AudioSource audio;
    public AudioClip[] clips;


    void Start()
    {

        audio = GetComponent<AudioSource>();
    }


    void Update ()
    {
        //if (!audio.isPlaying)
        //{
        //    audio.Play();
        //}
    }
}
