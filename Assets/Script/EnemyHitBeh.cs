using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBeh : MonoBehaviour {

    public int Life;
    public AudioSource audio;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
            if (Life > 1)
            {
                Life--;
                if(other.gameObject.GetComponent<BulletBeh>() != null)
                {
                    other.gameObject.GetComponent<BulletBeh>().Fire = false;
                }
                if (!audio.isPlaying)
                {
                    audio.volume = 0.1f;
                    audio.Play();
                }
                Destroy(other.gameObject);
            }
            else
            {
                other.gameObject.GetComponent<BulletBeh>().Fire = false;
                Destroy(other.gameObject);
                Destroy(this.gameObject.GetComponentInParent<EnemyBoneParent>().GetComponentInParent<EnemyBeh>().gameObject);
            }
        
    }

}
