using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float camSpeed;
    public float minZoom;
    public float maxZoom;

    Vector3 horzPanVector;
    Vector3 vertPanVector;
    float currZoom;

    private void Start()
    {
        horzPanVector = transform.right;
        vertPanVector = transform.up;

        currZoom = 40f;
        //minZoom = 10f;
        //maxZoom = 25f;

        camSpeed = 20f;
    }

    private void Update()
    {

        if (Input.GetMouseButton(1))
        {
            horzPanVector += transform.right * Input.GetAxisRaw("Mouse X") * Time.deltaTime * camSpeed;
            horzPanVector.y = 0;

            vertPanVector += transform.up * Input.GetAxisRaw("Mouse Y") * Time.deltaTime * camSpeed;
            vertPanVector.y = 0;
        }

        currZoom += -Input.GetAxisRaw("Mouse ScrollWheel") * camSpeed * Time.deltaTime * 100f;

        if (currZoom < minZoom) currZoom = minZoom;
        else if (currZoom > maxZoom) currZoom = maxZoom;

        transform.position = new Vector3(0, currZoom, 0) + horzPanVector + vertPanVector;
    }

}
