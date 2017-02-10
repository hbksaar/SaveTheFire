using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBeh : MonoBehaviour {

    private GameObject bullet;
    public int Life;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnTriggerEnter(Collider other)
    {
        if (Life > 1)
        {
            Life--;
            other.gameObject.GetComponent<BulletBeh>().Fire = false;
            Destroy(other.gameObject);
        }
        else
        {
            other.gameObject.GetComponent<BulletBeh>().Fire = false;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }


    void ThrowSnowball()
    {
        bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
        bullet.transform.position = transform.position;
         
        bullet.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);

        bullet.GetComponent<BulletBeh>().direction = new Vector3(0.107f, 1.066f, -1.114f); //location of the fire
        bullet.GetComponent<BulletBeh>().Fire = true;

    }
}
