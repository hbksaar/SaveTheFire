using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour {

    public float SizeOfFire;
    public Light FireLight;

	// Use this for initialization
	void Start () {
        SizeOfFire = 1f;

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 scale = gameObject.transform.localScale;
        scale.y = SizeOfFire;
        gameObject.transform.localScale = scale;


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<BulletBeh>() != null)
        {
            other.gameObject.GetComponent<BulletBeh>().Fire = false;
            Destroy(other.gameObject);
            FireLight.intensity -= 0.01f;
        }


        Debug.Log("Other tag = " + other.gameObject.tag);
        other.gameObject.SetActive(false);
        //SizeOfFire += (float) Convert.ToInt32(other.gameObject.tag);


        //0.5 is minimum range
        //2.0 is maximum range




        //FireLight.intensity += (float)(Convert.ToInt32(other.gameObject.tag.ToString()) * 0.5);
        FireLight.intensity -= 1.5f;

    }
}
