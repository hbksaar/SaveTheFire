using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipOfGun : MonoBehaviour
{
    private SteamVR_TrackedController controller;

    //GameObject currentlyDragged;
    private bool triggersBeenPressed;

    private float speed = 50f;


    private GameObject bullet;
    public bool bulletInstateated;
    private bool drop;


    void Start()
    {
        controller = GetComponentInParent<SteamVR_TrackedController>();
        controller.TriggerClicked += ViveTriggerClicked;
        controller.TriggerUnclicked += ViveTriggerUnClicked;

        controller.PadClicked += VivePadClicked;
        controller.PadUnclicked += VivePadUnClicked;

    }

    private void VivePadUnClicked(object sender, ClickedEventArgs e)
    {
        drop = true;
    }


    private void VivePadClicked(object sender, ClickedEventArgs e)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.gameObject.transform.parent != this.transform.parent && !drop)
            {
                hit.collider.gameObject.transform.parent = this.transform.parent;
                hit.collider.gameObject.transform.position = transform.position + transform.forward;
                hit.rigidbody.useGravity = false;
            }
            else
            {
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.useGravity = true;
                    hit.collider.gameObject.transform.parent = null;
                    drop = false;
                }
            }

        }

    }

    private void ViveTriggerUnClicked(object sender, ClickedEventArgs e)
    {

    }

    private void ViveTriggerClicked(object sender, ClickedEventArgs obj)
    {
        Debug.Log("Raycasting");

        // Declare a raycast hit to store information about what our raycast has hit
        RaycastHit hit;

        // Set the start position for our visual effect for our laser to the position of gunEnd
        //laserLine.SetPosition(0, transform.position);

        Ray ray = new Ray(transform.position, transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10.0f);

        // Check if our raycast has hit anything
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            // Set the end position for our laser line 
            //laserLine.SetPosition(1, hit.point);

            //int fireValue;
            //try
            //{
            //    fireValue = Convert.ToInt32(hit.collider.gameObject.tag.ToString());
            //}
            //catch (Exception e)
            //{
            //    fireValue = 10;
            //}

            //if (fireValue > -5 && fireValue < 5)
            //{
            //    Debug.Log("Other objects tag: " + hit.collider.gameObject.tag.ToString());

            //    if (hit.collider.gameObject.transform.parent != this.transform.parent)
            //    {
            //        hit.collider.gameObject.transform.parent = this.transform.parent;
            //        hit.rigidbody.useGravity = false;
            //    }
            //}

            //if (hit.collider.gameObject.tag.Equals("Enemy"))
           // {
                if (bullet == null)
                {
                    bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
                    bullet.transform.position = transform.position;
                    bullet.transform.LookAt(hit.transform.position);
                    bullet.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
                    
                    bullet.GetComponent<BulletBeh>().direction = hit.collider.gameObject.transform.position;
                    bullet.GetComponent<BulletBeh>().Fire = true;
                }

           // }


            //else
            //{
            //    if (hit.rigidbody != null)
            //    {
            //        hit.rigidbody.useGravity = true;
            //        hit.collider.gameObject.transform.parent = null;
            //    }
            //}
        }




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ViveTriggerClicked(null, new ClickedEventArgs());
        }


        /*  // Declare a raycast hit to store information about what our raycast has hit
          RaycastHit hit;
          // Set the start position for our visual effect for our laser to the position of gunEnd
          laserLine.SetPosition(0, transform.position);
          // Check if our raycast has hit anything
          if (Physics.Raycast(transform.position, transform.forward, out hit))
          {
              // Set the end position for our laser line 
              laserLine.SetPosition(1, hit.point);
              int fireValue;
              try
              {
                  fireValue = Convert.ToInt32(hit.collider.gameObject.tag.ToString());
              }
              catch (Exception e)
              {
                  fireValue = 10;
              }
              if (triggersBeenPressed)
              {
              }
              else
              {
              }
          }*/
    }


    public IEnumerator FireTowards(GameObject bullet, Vector3 direction)
    {
        while (bullet.transform.position != direction)
        {
            float step = speed * Time.deltaTime;
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, direction, step);
            yield return null;
        }
    }
}