using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour {

    public Light FireLight;

	void Start ()
    {

    }

	void Update ()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<BulletBeh>() != null)
        {
            other.gameObject.GetComponent<BulletBeh>().Fire = false;
            Destroy(other.gameObject);
            FireLight.GetComponent<Light>().intensity -= 0.005f;
        }

        if (other.gameObject.GetComponent<ItemBeh>() != null)
        {
            Destroy(other.gameObject);
            FireLight.GetComponent<Light>().intensity -= 0.005f;
        }

    }
}
