﻿using UnityEngine;
using System.Collections;

public class CameraTopdown : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float smoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target == null)
            return;
        Vector3 goalPos = target.position + offset;
        goalPos.y = transform.position.y;
        transform.position = Vector3.SmoothDamp(transform.position, goalPos, ref velocity, smoothTime);
    }
}
