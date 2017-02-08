using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    public LayerMask mask;
    public LayerMask dragged;

    public SteamVR_TrackedController controller;

    GameObject currentlyDragged;
	
	// Update is called once per frame
	void Update () {
        if (controller.triggerPressed)
        {
            RaycastHit hit;
            var raymask = currentlyDragged == null ? mask : dragged;
            //var raymask = mask;
            if (Physics.Raycast(transform.position, transform.forward, out hit, float.MaxValue, raymask))
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                if (currentlyDragged == null)
                {
                    if (hit.collider.tag == "Draggable")
                    {
                        currentlyDragged = hit.collider.gameObject;
                    }
                }
                else
                {
                    currentlyDragged.transform.position = hit.point;
                }
                //var draggable = hit.collider.gameObject.GetComponent<Draggable>();
                //if (draggable != null)
                //{
                //    draggable.Getdra
                //}
            }
        } else
        {
            currentlyDragged = null;
        }
    }
}
