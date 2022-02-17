using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public Transform paddleTransform;
    public Transform controllerTransform;
    public float clampX, clampY, clampZ;

    public Vector3 initialRotation;

    public Vector3 coefficient;

    private void Start()
    {
        initialRotation = paddleTransform.localRotation.eulerAngles;
    }

    void FixedUpdate()
    {
        Vector3 notClamped = new Vector3(
            (controllerTransform.localRotation.eulerAngles.x > 180 ? controllerTransform.localRotation.eulerAngles.x - 360 : controllerTransform.localRotation.eulerAngles.x) * coefficient.x,
            (controllerTransform.localRotation.eulerAngles.y > 180 ? controllerTransform.localRotation.eulerAngles.y - 360 : controllerTransform.localRotation.eulerAngles.y) * coefficient.y,
            (controllerTransform.localRotation.eulerAngles.z > 180 ? controllerTransform.localRotation.eulerAngles.z - 360 : controllerTransform.localRotation.eulerAngles.z) * coefficient.z);
        //Debug.Log("notClamped: " + notClamped.ToString("F4"));
        Vector3 newRotation = new Vector3(
            Mathf.Clamp(notClamped.x, initialRotation.x - clampX, initialRotation.x + clampX),
            Mathf.Clamp(notClamped.y, initialRotation.y - clampY, initialRotation.y + clampY),
            Mathf.Clamp(notClamped.z, initialRotation.z - clampZ, initialRotation.z + clampZ));
        //Debug.Log("Clamped: " + newRotation.ToString("F4"));

        paddleTransform.localEulerAngles = newRotation;
    }
}
