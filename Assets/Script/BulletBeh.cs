using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeh : MonoBehaviour {

    public bool Fire;
    public Vector3 direction;
    public float speed = 0.00001f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Fire)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, direction, step);
        }
	}



}
