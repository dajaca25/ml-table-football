﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the attached object along the Y-axis with the defined speed
/// </summary>
public class DirectMoving : MonoBehaviour
{

    [Tooltip("Moving speed on Y axis in local space")]
    public float speed; //Normal downward speed.
    public float speedRight; //Normal rightward speed.

    //moving the object with the defined speed
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.Translate(Vector3.right * speedRight * Time.deltaTime);
    }
}