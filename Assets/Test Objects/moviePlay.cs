using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moviePlay : MonoBehaviour {

    public MovieTexture Movie;

	void Start ()
    {
        Movie.loop = true;
        Movie.Play();
    }

    void Update ()
    {

	}
}
