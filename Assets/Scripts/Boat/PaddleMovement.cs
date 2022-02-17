using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public Transform paddleTransform;
    public Transform controllerTransform;
    public float clampX, clampY, clampZ;

    private Vector3 initialRotation;

    public Vector3 coefficient;

    private void Start()
    {
        initialRotation = paddleTransform.localRotation.eulerAngles;
    }

    void FixedUpdate()
    {
        Vector3 newRotation = new Vector3(
            Mathf.Clamp(controllerTransform.localRotation.eulerAngles.x * coefficient.x, initialRotation.x - clampX, initialRotation.x + clampX),
            Mathf.Clamp(controllerTransform.localRotation.eulerAngles.y * coefficient.y, initialRotation.y - clampY, initialRotation.y + clampY),
            Mathf.Clamp(controllerTransform.localRotation.eulerAngles.z * coefficient.z, initialRotation.z - clampZ, initialRotation.z + clampZ));

        paddleTransform.localEulerAngles = newRotation;
    }
}
