using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamStretch : MonoBehaviour {

    public Vector2 scaleFactors = new Vector2(1, 1);
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

	// Update is called once per frame
	void Update () {

        cam.ResetProjectionMatrix();
        Matrix4x4 pm = cam.projectionMatrix;
        pm.m00 *= scaleFactors.x;
        pm.m11 *= scaleFactors.y;
        cam.projectionMatrix = pm;
    }
}
