﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    Vector3 lastPanPosition;
    //Vector3 horzPanVector;
    Vector3 vertPanVector;
    float currZoom;
    bool lockedOn;
    Transform currentTarget;

    public float camSpeed;
    public float minZoom;
    public float maxZoom;
    public float upperBoundsX;
    public float lowerBoundsX;
    public float upperBoundsZ;
    public float lowerBoundsZ;
    public Vector3 origPosition;
    public Vector3 lockPosOffset;

    private void Start()
    {

        currZoom = 40f;
        lockedOn = false;
        //minZoom = 10f;
        //maxZoom = 25f;

        //camSpeed = 20f;

        Input.ResetInputAxes();
    }

    private void Update()
    {
        if(lockedOn && currentTarget != null)
        {
            LockOnTarget();
        } else if (Input.GetMouseButtonDown(1))
        {
            lastPanPosition = Input.mousePosition;
        } else if (Input.GetMouseButton(1))
        {
            PanCamera(Input.mousePosition);
        }

        //if (currZoom < minZoom) currZoom = minZoom;
        //else if (currZoom > maxZoom) currZoom = maxZoom;
    }

    void PanCamera(Vector3 newPanPosition)
    {
        Vector3 offset = GetComponent<Camera>().ScreenToViewportPoint(lastPanPosition - newPanPosition);
        Vector3 move = new Vector3(offset.x * camSpeed, 0, offset.y * camSpeed);

        transform.Translate(move, Space.World);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, lowerBoundsX, upperBoundsX);
        pos.z = Mathf.Clamp(transform.position.z, lowerBoundsZ, upperBoundsZ);
        transform.position = pos;
        origPosition = pos;

        lastPanPosition = newPanPosition;
    }

    /*float ZoomCamera(float offset, float speed)
    {
        //if (offset == 0)
        //{
        //    return 0;
        //}

        return Mathf.Clamp(offset * speed, minZoom, maxZoom);
    }*/

    public void LockOnTarget()
    {
        //Vector3 offset = new Vector3(0f, 48f, -20f);
        transform.position = currentTarget.position + lockPosOffset;
        //transform.LookAt(currentTarget);
    }

    public void SetLockOn(Transform newTarget)
    {
        currentTarget = newTarget;
        lockedOn = true;
    }

    public void StopLockOn()
    {
        currentTarget = null;
        lockedOn = false;
        transform.position = origPosition;
    }
}
