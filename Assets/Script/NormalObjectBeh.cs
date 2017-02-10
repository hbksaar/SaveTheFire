using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalObjectBeh : MonoBehaviour {

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletBeh>() != null)
        {
            other.gameObject.GetComponent<BulletBeh>().Fire = false;
            Destroy(other.gameObject);
        }
    }


}
