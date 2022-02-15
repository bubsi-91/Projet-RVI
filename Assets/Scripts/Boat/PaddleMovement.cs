using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public BoatController BoatController;
    public BoatController.PaddleOrientation PaddleOrientation;
    public Transform forwardTransform;

    public Transform paddleTransform;
    public Transform controllerTransform;
    public float clampX, clampY, clampZ;

    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;
    // Start is called before the first frame update
    void Start()
    {
        PrevPos = transform.position;
        NewPos = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 newRotation = new Vector3(
            Mathf.Clamp(controllerTransform.localRotation.eulerAngles.x, -clampX, clampX),
            Mathf.Clamp(controllerTransform.localRotation.eulerAngles.y, -clampY, clampY),
            Mathf.Clamp(controllerTransform.localRotation.eulerAngles.z, -clampZ, clampZ));

        paddleTransform.eulerAngles = newRotation;

        NewPos = transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time
        PrevPos = NewPos;  // update position for next frame calculation
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WaterMovement"))
        {
            //Debug.Log("Detected trigger enter for paddle! " + ObjVelocity.z);
            BoatController.AddForce(Vector3.Dot(ObjVelocity, forwardTransform.position.normalized) / -100);
        }
    }
}
