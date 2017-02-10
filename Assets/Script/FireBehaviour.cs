using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour {

    public Light FireLight;
    private AudioSource audio;

	void Start ()
    {
        audio = GetComponent<AudioSource>();
    }

	void Update ()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<BulletBeh>() != null)
        {

            if (!audio.isPlaying)
            {
                audio.Play();
            }
            other.gameObject.GetComponent<BulletBeh>().Fire = false;
            Destroy(other.gameObject);
            FireLight.GetComponent<Light>().intensity -= 0.2f;
        }

        if (other.gameObject.GetComponent<ItemBeh>() != null)
        {
            if(!audio.isPlaying)
            {
                audio.Play();
            }
            Destroy(other.gameObject);
            FireLight.GetComponent<Light>().intensity += other.gameObject.GetComponent<ItemBeh>().Value;
        }

    }
}
