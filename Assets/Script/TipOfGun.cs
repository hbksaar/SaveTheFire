using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipOfGun : MonoBehaviour
{
    private SteamVR_TrackedController controller;
    private GameObject bullet;
    private bool drop;

    void Start()
    {
        controller = GetComponentInParent<SteamVR_TrackedController>();
        controller.TriggerClicked += ViveTriggerClicked;
        controller.TriggerUnclicked += ViveTriggerUnClicked;
        controller.PadClicked += VivePadClicked;
        controller.PadUnclicked += VivePadUnClicked;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ViveTriggerClicked(null, new ClickedEventArgs());
        }
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
            if(hit.collider.gameObject.GetComponent<ItemBeh>() != null)
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

    }

    private void ViveTriggerUnClicked(object sender, ClickedEventArgs e)
    {

    }

    private void ViveTriggerClicked(object sender, ClickedEventArgs obj)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.red, 10.0f);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (bullet == null)
            {
                bullet = Instantiate(Resources.Load("Bullet", typeof(GameObject))) as GameObject;
                bullet.transform.position = transform.position;
                bullet.transform.LookAt(hit.transform.position);
                bullet.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);

                bullet.GetComponent<BulletBeh>().direction = hit.collider.gameObject.transform.position;
                bullet.GetComponent<BulletBeh>().Fire = true;
            }

        }
    }



}