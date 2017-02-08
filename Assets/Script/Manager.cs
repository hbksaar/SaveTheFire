using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public Transform brick;
    AudioSource audio;

    void Start()
    {

        audio = GetComponent<AudioSource>();
    }


    void Update ()
    {
        if (!audio.isPlaying)
        {
            audio.Play();
        }
    }

    public void OnMouseDown()
    {
        Instantiate(brick, new Vector3(3.73f, 3.32f, 2.55f), Quaternion.identity);
    }
}
